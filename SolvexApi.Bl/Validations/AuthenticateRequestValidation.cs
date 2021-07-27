using FluentValidation;
using GenericApi.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    class AuthenticateRequestValidation : AbstractValidator<AuthenticateRequestDto>
    {
        public AuthenticateRequestValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Username is required")
                .MaximumLength(8)
                .WithMessage("Password's length must be at least 8 characters");
        }
    }
}
