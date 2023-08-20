using App.Domain.Models.Core;

namespace App.Domain.Models
{
    /// <summary>
    /// Represents a Contacts class which inherits from EntityBase.
    /// </summary>
    public class Contacts : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Contacts"/> class.
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="phone">Phone number of user</param>
        /// <param name="name">First name of user</param>
        /// <param name="surname">Last name of user</param>
        /// <param name="email">Email of user</param>    
        public Contacts(int userId, string phone, string name, string surname, string email)
        {
            UserId = userId;
            Phone = phone;
            Name = name;
            Surname = surname;
            Email = email;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Contacts"/> class.
        /// </summary>
        public Contacts() { }

        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of user
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the first name of user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name of user
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the email of user
        /// </summary>
        public string Email { get; set; }
    }
}