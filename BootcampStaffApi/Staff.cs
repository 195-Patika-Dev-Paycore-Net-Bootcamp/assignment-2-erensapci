using System;
using System.ComponentModel.DataAnnotations;

namespace BootcampStaffApi
{
    //The part where the properties are defined
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        //I did the DateTime validation specifically with the attribute.
        [Required(ErrorMessage ="Bithday cannot be empty")]
        [DataType(DataType.DateTime)]
        [Range(typeof(DateTime), "11-11-1945", " 10-10-2002")]
        public DateTime DateOfBirth { get; set; }
        
        //The part where the Email is validated with regular expression
        [RegularExpression(@"^[a-zA-Z0-9!@#\$%\^\&*\)\(+=_-]+$")]
        public string Email { get; set; }
        
        //The part where the Phone number is validated with regular expression
        [RegularExpression(@"^(\+[0-9]{9})$")]
        
        public string PhoneNumber { get; set; }
        
        public double Salary { get; set; }

    }
}
