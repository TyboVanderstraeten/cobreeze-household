using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : EditableBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<HouseholdGroup> Households { get; }

        public User(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Households = new List<HouseholdGroup>();
        }
    }
}
