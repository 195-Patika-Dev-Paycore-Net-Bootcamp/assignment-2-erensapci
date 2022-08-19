using System;
using System.ComponentModel.DataAnnotations;

namespace BootcampStaffApi
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required(ErrorMessage ="Bithday cannot be empty")]
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime), "11-11-1945", " 10-10-2002")]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }

    }
}
