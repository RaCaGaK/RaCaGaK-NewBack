﻿using FluentValidation;
using Layer.Architecture.Domain.Entities;

namespace Layer.Architecture.Service.Validators
{
    public class MsgsValidator : AbstractValidator<Msg>
    {
        public MsgsValidator()
        {

        }
    }
}