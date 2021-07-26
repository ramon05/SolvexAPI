using FluentValidation;
using GenericApi.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
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
			RuleFor(x => x.ContentType)
				.NotEmpty()
				.WithMessage("Document's filename is required");
			RuleFor(x => x.OriginalName)
				.NotEmpty()
				.WithMessage("Document's OriginalName is required");
		}
	}
}
