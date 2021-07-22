using FluentValidation;
using SolvexApi.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.Validations
{
	public class DocumentValidator : AbstractValidator<DocumentDto>
	{
		public DocumentValidator()
		{
			RuleFor(x => x.FileName)
				.MinimumLength(10)
				.WithMessage("Document's length must be at least 10 characters")
				.NotEmpty()
				.WithMessage("Document's filename is required");
		}
	}
}
