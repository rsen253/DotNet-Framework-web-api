using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.API.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int Age => CalculateAge(DOB);

        private int CalculateAge(DateTime dob)
        {
            var age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age))
                age--;

            return age;
        }
    }
}