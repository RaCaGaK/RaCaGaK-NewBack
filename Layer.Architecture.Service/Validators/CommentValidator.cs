using FluentValidation;
using Layer.Architecture.Domain.Entities;

namespace Layer.Architecture.Service.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {

        }
    }
}