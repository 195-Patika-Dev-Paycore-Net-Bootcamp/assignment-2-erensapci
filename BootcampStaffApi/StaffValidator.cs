using FluentValidation;
using System.Text.RegularExpressions;

namespace BootcampStaffApi
{
    //Validation class created using FluentValidation
    public class StaffValidator : AbstractValidator<Staff>
    {

        public StaffValidator()
        {
            //The part where the name is validated
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(4, 120).WithMessage("Name must to be valid");
            //The part where the Surname is validated
            RuleFor(x => x.Surname).NotNull().NotEmpty().Length(4, 120).WithMessage("Surname must to be valid");
            //The part where the Email is validated
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email must to be valid");
            //The part where the Phone number is validated
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("Phone Number is required.")
       .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
       .MaximumLength(20).WithMessage("PhoneNumber must not exceed 20 characters.");
            //The part where the Salary is validated
            RuleFor(x => x.Salary).NotNull().NotEmpty().GreaterThanOrEqualTo(2000).LessThanOrEqualTo(9000);
        }
    }
}
