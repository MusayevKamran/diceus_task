using System;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Interfaces;
using App.Domain.Models;
using App.Infrastructure.CrossCutting.Identity.Interfaces;
using App.Infrastructure.CrossCutting.Identity.ViewModels.InputModels;
using App.Infrastructure.CrossCutting.Identity.ViewModels.OutputModels;
using App.Infrastructure.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace App.Api.Controllers
{
    /// <summary>
    /// AccountController handles the user authentication procedures such as Register/Login/Token refresh operations.
    /// </summary>
    public class AccountController : ApiController
    {
        private readonly ILoginService _loginManager;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// AccountController's constructor initializes the login and user services.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public AccountController(IServiceProvider serviceProvider)
        {
            _loginManager = serviceProvider.GetRequiredService<ILoginService>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }
        
        /// <summary>
        /// Register endpoint accepts user registration requests.
        /// </summary>
        /// <param name="registerUserInputModel">Input model for registration</param>
        /// <returns>User's Authentication info if successful, otherwise the errors</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserInputModel registerUserInputModel)
        {
            var authResponse = await _loginManager.RegisterAsync(registerUserInputModel.Email, registerUserInputModel.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedOutputModel()
                {
                    Errors = authResponse.Errors
                });
            }

            var user = new User()
            {
                Email = registerUserInputModel.Email,
                LoginId = authResponse.LoginId.ToLower()
            };
             await _unitOfWork.Context.Users.AddAsync(user);
             await _unitOfWork.SaveAsync();

            var response = new AuthSuccessOutputModel()
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken,
                ExpiresIn = authResponse.ExpiresIn
            };
            return Ok(new AuthOutputModel<AuthSuccessOutputModel>(response));

        }
        
        /// <summary>
        /// Login endpoint handles user login requests.
        /// </summary>
        /// <param name="request">Input model for login</param>
        /// <returns>User's Authentication info if successful, otherwise the errors</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginInputModel request)
        {
            var authResponse = await _loginManager.LoginAsync(request.Email, request.Password);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedOutputModel()
                {
                    Errors = authResponse.Errors
                });
            }

            var response = new AuthSuccessOutputModel()
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken,
                ExpiresIn = authResponse.ExpiresIn
            };
            return Ok(new AuthOutputModel<AuthSuccessOutputModel>(response));

        }
        
        /// <summary>
        /// Refresh token endpoint. Refreshes the authentication token if it is expired.
        /// </summary>
        /// <param name="request">Input model for refresh token</param>
        /// <returns>New Authentication info if successful, otherwise the errors</returns>
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenInputModel request)
        {
            var authResponse = await _loginManager.RefreshTokenAsync(request.Token, request.RefreshToken);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedOutputModel()
                {
                    Errors = authResponse.Errors
                });
            }

            var response = new AuthSuccessOutputModel()
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken,
                ExpiresIn = authResponse.ExpiresIn
            };
            return Ok(new AuthOutputModel<AuthSuccessOutputModel>(response));
        }
        
    }
}