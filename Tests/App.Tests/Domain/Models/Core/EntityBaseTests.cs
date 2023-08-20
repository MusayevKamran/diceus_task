using App.Domain.Models.Core;

namespace App.Tests.Domain.Models.Core
{
    public class EntityBaseTests
    {
        [Fact]
        public void IdPropertySetsAndGetsValue()
        {
            // Arrange
            var entity = new EntityBase();
            var expectedId = 1;

            // Act
            entity.Id = expectedId;
            var actualId = entity.Id;

            // Assert
            Assert.Equal(expectedId, actualId);
        }
    }
}