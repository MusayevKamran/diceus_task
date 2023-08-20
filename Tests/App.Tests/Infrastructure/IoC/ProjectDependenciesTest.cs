using App.Application.Configurations;
using App.Infrastructure.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace App.Tests.Infrastructure.IoC;

public class ProjectDependenciesTests
{
    // Test checks if RegisterServices method from InjectNativeServices is invoked
    [Fact]
    public void AddProjectSetup_Should_Call_RegisterServices_For_InjectNativeServices()
    {
        // Arrange
        var servicesMock = new Mock<IServiceCollection>();
        
        // Act
        ProjectDependencies.AddProjectSetup(servicesMock.Object);
        
        // Assert
        // Here, specify the real name of the RegisterServices method from the InjectNativeServices class
        servicesMock.Verify(s => s.Add(It.Is<ServiceDescriptor>(sd => sd.ServiceType == typeof(InjectNativeServices))), Times.Once);
    }

    // Test checks if RegisterServices method from ApplicationLayerConfiguration is invoked
    [Fact]
    public void AddProjectSetup_Should_Call_RegisterServices_For_ApplicationLayerConfiguration()
    {
        // Arrange
        var servicesMock = new Mock<IServiceCollection>();

        // Act
        ProjectDependencies.AddProjectSetup(servicesMock.Object);
        
        // Assert
        // Here, specify the real name of the RegisterServices method from the ApplicationLayerConfiguration class
        servicesMock.Verify(s => s.Add(It.Is<ServiceDescriptor>(sd => sd.ServiceType == typeof(ApplicationLayerConfiguration))), Times.Once);
    }
}