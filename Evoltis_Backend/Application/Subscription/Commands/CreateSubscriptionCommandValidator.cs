using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Subscription.Commands
{
    public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
    {
        public CreateSubscriptionCommandValidator() {
            RuleFor(s => s.CreateSubscriptionDto.Price).NotEmpty().WithMessage("Price can not be empty");
            RuleFor(s => s.CreateSubscriptionDto.Price).NotNull().WithMessage("Price can not be null");
            RuleFor(s => s.CreateSubscriptionDto.Price).InclusiveBetween(1,999).WithMessage("Price must be between 1 and 999");
            RuleFor(s => s.CreateSubscriptionDto.PlanName).NotNull().WithMessage("Plan name can not be null");
            RuleFor(s => s.CreateSubscriptionDto.PlanName).NotEmpty().WithMessage("Plan name can not be empty");
            RuleFor(s => s.CreateSubscriptionDto.UserId).NotNull().WithMessage("User Id can not be null");
            RuleFor(s => s.CreateSubscriptionDto.UserId).NotEmpty().WithMessage("User Id can not be empty");
            RuleFor(s=> s.CreateSubscriptionDto.EndDate).GreaterThan(DateTime.Now.AddDays(1)).WithMessage("End date must be greater than a day");
        }
    }
}
