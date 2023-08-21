using System;
using System.Threading.Tasks;
using App.Application.Interfaces;
using App.Domain.Models;
using App.Infrastructure.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Admin.Controllers;

public class ContactsController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IContactsService _contactsService;

    public ContactsController(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        _contactsService = serviceProvider.GetRequiredService<IContactsService>();
    }

    // GET: Contacts
    public async Task<IActionResult> Index(string searchString)
    {
        if (string.IsNullOrEmpty(searchString))
        {
            return View(await Task.FromResult(_contactsService.Select(x => x)));
        }
        
        var list = await _contactsService.WhereAsync(x =>
            x.Email.Contains(searchString)
            || x.Name.Contains(searchString)
            || x.Surname.Contains(searchString)
            || x.Phone.Contains(searchString)
        );

        return View(list);
    }


    // GET: Contacts/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _contactsService == null)
        {
            return NotFound();
        }

        var contacts = await _contactsService.FirstOrDefaultAsync(m => m.Id == id);
        if (contacts == null)
        {
            return NotFound();
        }

        return View(contacts);
    }

    // GET: Contacts/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Contacts/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Phone,Name,Surname,Email")] Contacts contacts)
    {
        if (ModelState.IsValid)
        {
            await _contactsService.InsertAsync(contacts);

            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(contacts);
    }

    // GET: Contacts/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _contactsService == null)
        {
            return NotFound();
        }

        var contacts = await _contactsService.FirstOrDefaultAsync(x => x.Id == id);
        if (contacts == null)
        {
            return NotFound();
        }

        return View(contacts);
    }

    // POST: Contacts/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Phone,Name,Surname,Email")] Contacts contacts)
    {
        if (ModelState.IsValid)
        {
            try
            {
                contacts.Id = id;
                _contactsService.Update(contacts);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactsExists(contacts.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(contacts);
    }

    // GET: Contacts/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _contactsService == null)
        {
            return NotFound();
        }

        var contacts = await _contactsService.FirstOrDefaultAsync(m => m.Id == id);
        if (contacts == null)
        {
            return NotFound();
        }

        return View(contacts);
    }

    // POST: Contacts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_contactsService == null)
        {
            return Problem("Entity set 'AppDbContext.Contacts'  is null.");
        }

        var contacts = await _contactsService.FirstOrDefaultAsync(x => x.Id == id);
        if (contacts != null)
        {
            _contactsService.Delete(contacts);
        }

        await _unitOfWork.SaveAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ContactsExists(int id)
    {
        return (_contactsService?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}