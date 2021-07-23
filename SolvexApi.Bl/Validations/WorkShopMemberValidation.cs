using FluentValidation;
using SolvexApi.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.Validations
{
	public class WorkShopMemberValidator : AbstractValidator<WorkShopMemberDto>
	{
		public WorkShopMemberValidator()
		{
			RuleFor(x => x.Role)
					.NotEmpty()
					.WithMessage("Member's Role is required");
			RuleFor(x => x.WorkShopId)
					.NotEmpty()
					.WithMessage("Member's WorkShopId is required");
			RuleFor(x => x.MemberId)
					.NotEmpty()
					.WithMessage("Member's MemberId is required");
		}
	}
}
