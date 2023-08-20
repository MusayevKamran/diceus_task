using App.Domain.Models;

namespace App.Tests.Domain.Models;

public class UserTest
{
    [Fact]
    public void CreateUser_HasCorrectValues()
    {
        // Arrange
        var loginId = "login123";
        var firstName = "John";
        var lastName = "Doe";
        var email = "john.doe@example.com";
        var phoneNumber = "123-456-7890";
        var dateOfBirth = new DateTime(2000, 1, 1);
        int? genderMale = 1;
        int? nativeCountryId = 10;
        bool isActive = true;
        bool isDirector = false;
        var dateCreated = DateTime.Now;
        var dateModified = DateTime.Now;

        // Act
        var user = new User(loginId, firstName, lastName, email, phoneNumber, dateOfBirth, genderMale, nativeCountryId, isActive, isDirector, dateCreated, dateModified);

        // Assert
        Assert.Equal(loginId, user.LoginId);
        Assert.Equal(firstName, user.Firstname);
        Assert.Equal(lastName, user.Lastname);
        Assert.Equal(email, user.Email);
        Assert.Equal(phoneNumber, user.PhoneNumber);
        Assert.Equal(dateOfBirth, user.DateOfBirth);
        Assert.Equal(genderMale, user.IsGenderMale);
        Assert.Equal(nativeCountryId, user.NativeCountryId);
        Assert.Equal(isActive, user.IsActive);
        Assert.Equal(isDirector, user.IsDirector);
        Assert.Equal(dateCreated, user.DateCreated);
        Assert.Equal(dateModified, user.DateModified);
    }

    [Fact]
    public void DefaultConstructor_WorksProperly()
    {
        // Act
        var user = new User();

        // Assert
        Assert.NotNull(user);
    }
}