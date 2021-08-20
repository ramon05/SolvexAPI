using FluentValidation;
using GenericApi.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
	public class WorkShopMemberValidator : AbstractValidator<WorkShopMemberDto>
	{
		public WorkShopMemberValidator()
		{
			RuleFor(x => x.Role)
					.NotNull()
					.WithMessage("Member's Role is required");
		}
	}
}
