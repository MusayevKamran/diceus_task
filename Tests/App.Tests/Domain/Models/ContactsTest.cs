using App.Domain.Models;

namespace App.Tests.Domain.Models
{
    public class ContactsTest
    {
        [Fact]
        public void Contacts_Constructor_SetsValuesCorrectly()
        {
            // Arrange
            var userId = 1;
            var phone = "123456789";
            var name = "John";
            var surname = "Doe";
            var email = "john.doe@example.com";

            // Act
            var contact = new Contacts(userId, phone, name, surname, email);

            // Assert
            Assert.Equal(userId, contact.UserId);
            Assert.Equal(phone, contact.Phone);
            Assert.Equal(name, contact.Name);
            Assert.Equal(surname, contact.Surname);
            Assert.Equal(email, contact.Email);
        }
    }
}