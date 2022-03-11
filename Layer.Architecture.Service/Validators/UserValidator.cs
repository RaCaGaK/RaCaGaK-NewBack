using FluentValidation;
using Layer.Architecture.Domain.Entities;

namespace Layer.Architecture.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
           
        }
    }
}
