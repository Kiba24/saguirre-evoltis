using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidation() 
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(v => v.Name).NotNull().WithMessage("Name can not be null");
            RuleFor(v => v.LastName).NotEmpty().WithMessage("Lastname can not be empty");
            RuleFor(v => v.LastName).NotNull().WithMessage("Lastname can not be null");
            RuleFor(v => v.Email).NotEmpty().WithMessage("Email can not be empty");
            RuleFor(v => v.Email).NotNull().WithMessage("Email can not be null");
            RuleFor(v => v.Email).EmailAddress().WithMessage("Please enter a valid email address");
            RuleFor(v => v.Name).MinimumLength(3).WithMessage("Name length must have at least 3 characters");
            RuleFor(v => v.Name).MaximumLength(50).WithMessage("Name length must have 50 characters maximum");
        }
    }
}
