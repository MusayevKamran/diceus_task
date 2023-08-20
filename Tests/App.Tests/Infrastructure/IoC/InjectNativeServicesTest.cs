using App.Infrastructure.CrossCutting.Identity.Authorization.Claims;
using App.Infrastructure.CrossCutting.IoC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace App.Tests.Infrastructure.IoC
{
    public class ServiceRegistrationTest
    {
        [Fact]
        public void RegisterServices_ShouldRegisterHttpContextAccessorNormally()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            InjectNativeServices.RegisterServices(services);
            var provider = services.BuildServiceProvider();

            // Assert
            var service = provider.GetRequiredService<IHttpContextAccessor>();
            Assert.NotNull(service);
            Assert.IsType<HttpContextAccessor>(service);
        }

        [Fact]
        public void RegisterServices_ShouldRegisterClaimsRequirementHandlerNormally()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            InjectNativeServices.RegisterServices(services);
            var provider = services.BuildServiceProvider();

            // Assert
            var service = provider.GetRequiredService<IAuthorizationHandler>();
            Assert.NotNull(service);
            Assert.IsType<ClaimsRequirementHandler>(service);
        }
    }
}