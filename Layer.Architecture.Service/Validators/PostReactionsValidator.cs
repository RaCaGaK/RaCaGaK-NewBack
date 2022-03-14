using FluentValidation;
using Layer.Architecture.Domain.Entities;

namespace Layer.Architecture.Service.Validators
{
    public class PostReactionsValidator : AbstractValidator<PostReaction>
    {
        public PostReactionsValidator()
        {

        }
    }
}