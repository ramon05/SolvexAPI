using FluentValidation;
using SolvexApi.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.Validations
{
	public class MemberValidator : AbstractValidator<MemberDto>
	{
		public MemberValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Member's Name is required");
			RuleFor(x => x.LastName)
				.NotEmpty()
				.WithMessage("Member's LastName is required");
			RuleFor(x => x.DocumentType)
				.NotEmpty()
				.WithMessage("Member's DocumentType is required");
			RuleFor(x => x.DocumentTypeValue)
				.NotEmpty()
				.WithMessage("Member's DocumentTypeValue is required");
			RuleFor(x => x.Gender)
				.NotEmpty()
				.WithMessage("Member's Gender is required");
			RuleFor(x => x.PhotoFileName)
				.NotEmpty()
				.WithMessage("Member's PhotoFileName is required");
		}
	}
}
