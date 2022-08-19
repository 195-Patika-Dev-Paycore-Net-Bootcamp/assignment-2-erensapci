using FluentValidation;
using System.Text.RegularExpressions;

namespace BootcampStaffApi
{
    public class StaffValidator : AbstractValidator<Staff>
    {

        public StaffValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(4, 120).WithMessage("Name must to be valid");
            RuleFor(x => x.Surname).NotNull().NotEmpty().Length(4, 120).WithMessage("Surname must to be valid");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email must to be valid");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("Phone Number is required.")
       .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
       .MaximumLength(20).WithMessage("PhoneNumber must not exceed 20 characters.")
       .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");
            RuleFor(x => x.Salary).NotNull().NotEmpty().GreaterThanOrEqualTo(2000).LessThanOrEqualTo(9000);
        }
    }
}
