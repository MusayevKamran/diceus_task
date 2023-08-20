using System;
using App.Domain.Models.Core;

namespace App.Domain.Models
{
    /// <summary>
    /// Represents a User entity.
    /// Inherits from EntityBase.
    /// </summary>
    public class User : EntityBase
    {
        /// <summary>
        /// Overloaded constructor that initializes the User entity with its properties.
        /// </summary>
        public User(string loginId, string firstname, string lastname, string email, string phoneNumber, DateTime? dateOfBirth, int? isGenderMale, int? nativeCountryId, bool isActive, bool isDirector, DateTime? dateCreated, DateTime? dateModified)
        {
            LoginId = loginId;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            IsGenderMale = isGenderMale;
            NativeCountryId = nativeCountryId;
            IsActive = isActive;
            IsDirector = isDirector;
            DateCreated = dateCreated;
            DateModified = dateModified;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public User() { }

        /// <summary>
        /// Represents the login Id of the user.
        /// </summary>
        public virtual string LoginId { get; set; }
        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        public virtual string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public virtual string Lastname { get; set; }

        /// <summary>
        /// Gets or sets the email address of the person.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the person.
        /// </summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the person.
        /// </summary>
        public virtual DateTime? DateOfBirth { get; set; }

         /// <summary>
        /// Gets or sets the gender of the person. Value 1 indicates male, 0 indicates female.
        /// </summary>
        public virtual int? IsGenderMale { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the native country of the person.
        /// </summary>
        public virtual int? NativeCountryId { get; set; }

         /// <summary>
        /// Indicates whether the person's account is active.
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// Indicates whether the person is a director.
        /// </summary>
        public virtual bool IsDirector { get; set; }

        /// <summary>
        /// Gets or sets the date when the record was created.
        /// </summary>
        public virtual DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date when the record was last modified.
        /// </summary>
        public virtual DateTime? DateModified { get; set; }
    }
}
