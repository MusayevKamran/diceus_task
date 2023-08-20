using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using App.Infrastructure.CrossCutting.Identity.Context;
using App.Infrastructure.CrossCutting.Identity.Interfaces;
using App.Infrastructure.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure.CrossCutting.Identity.Services
{
    /// <summary>
    /// LoginService handles the operations such as Register, Login and RefreshToken.
    /// Implements the ILoginService.
    /// </summary>
    public class LoginService : ILoginService
    {
        // Managers for User and Role entities, IJwtFactory and AppIdentityDbContext
        private readonly IJwtFactory _jwtFactory;
        
        private readonly UserManager<Login> _loginManager;

        private readonly AppIdentityDbContext _context;

        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Initialization of services.
        /// </summary>
        public LoginService(IServiceProvider serviceProvider)
        {
            _jwtFactory = serviceProvider.GetRequiredService<IJwtFactory>();
            _loginManager = serviceProvider.GetRequiredService<UserManager<Login>>();
            _context = serviceProvider.GetRequiredService<AppIdentityDbContext>();
            _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        }

        /// <summary>
        /// Asynchronously registers a new user.
        /// </summary>
        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            var user = await _loginManager.FindByEmailAsync(email);
            if (user != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] {"User with this email address already exists"}
                };
            }

            var newLoginId = Guid.NewGuid();
            var newUser = new Login
            {
                Id = newLoginId.ToString(),
                Email = email,
                UserName = email
            };

            var createdUser = await _loginManager.CreateAsync(newUser, password);
            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }
            var a = await _jwtFactory.GenerateAuthenticationResultForUserAsync(newUser);
            return await _jwtFactory.GenerateAuthenticationResultForUserAsync(newUser);
        }

        /// <summary>
        /// Asynchronously logs in an existent user.
        /// </summary>
        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            var user = await _loginManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] {"User does not exist"}
                };
            }

            var userHasValidPassword = await _loginManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] {"User/password combination is wrong"}
                };
            }

            return await _jwtFactory.GenerateAuthenticationResultForUserAsync(user);
        }

        /// <summary>
        /// Asynchronously refreshes the authorization token.
        /// </summary>
        public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            var validatedToken = _jwtFactory.GetPrincipalFromToken(token);

            if (validatedToken == null)
            {
                return new AuthenticationResult {Errors = new[] {"Invalid Token"}};
            }

            var expiryDateUnix =
                long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return new AuthenticationResult {Errors = new[] {"This token hasn't expired yet"}};
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(x => x.Token == refreshToken);

            if (storedRefreshToken == null)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token does not exist"}};
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token has expired"}};
            }

            if (storedRefreshToken.Invalidated)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token has been invalidated"}};
            }

            if (storedRefreshToken.Used)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token has been used"}};
            }

            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthenticationResult {Errors = new[] {"This refresh token does not match this JWT"}};
            }

            storedRefreshToken.Used = true;
            _context.RefreshTokens.Update(storedRefreshToken);
            await _context.SaveChangesAsync();

            var user = await _loginManager.FindByIdAsync(validatedToken.Claims.Single(x => x.Type == "id").Value);
            return await _jwtFactory.GenerateAuthenticationResultForUserAsync(user);
        }
        
                /// <summary>
        /// Asynchronously refreshes the authorization token.
        /// </summary>
        public async Task<AuthenticationResult> GetTokenAsync()
        {
            return null;
        }
    }
}