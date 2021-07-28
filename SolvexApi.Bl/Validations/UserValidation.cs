using FluentValidation;
using GenericApi.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
	public class UserValidator : AbstractValidator<UserDto>
	{
		public UserValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("User's Name is required");
			RuleFor(x => x.LastName)
				.NotEmpty()
				.WithMessage("User's LastName is required");
			RuleFor(x => x.DocumentType)
				.NotEmpty()
				.WithMessage("User's DocumentType is required");
			RuleFor(x => x.DocumentTypeValue)
				.NotEmpty()
				.WithMessage("User's DocumentTypeValue is required");
			RuleFor(x => x.Gender)
				.NotEmpty()
				.WithMessage("User's Gender is required");
			RuleFor(x => x.UserName)
				.NotEmpty()
				.WithMessage("User's UserName is required");
			RuleFor(x => x.Password)
				.NotEmpty()
				.WithMessage("User's Password is required");
			    
		}
	}
}
