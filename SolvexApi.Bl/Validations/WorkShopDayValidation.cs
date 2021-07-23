using FluentValidation;
using SolvexApi.Bl.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Bl.Validations
{
	public class WorkShopDayValidator : AbstractValidator<WorkShopDayDto>
	{
		public WorkShopDayValidator()
		{
			RuleFor(x => x.Day)
					.NotEmpty()
					.WithMessage("WorkShop's Day is required");
			RuleFor(x => x.Mode)
					.NotEmpty()
					.WithMessage("WorkShop's Mode is required");
			RuleFor(x => x.ModeLocation)
					.NotEmpty()
					.WithMessage("WorkShop's ModeLocation is required");
			RuleFor(x => x.StartHour)
					.NotEmpty()
					.WithMessage("WorkShop's StartHour is required");

		}
	}
}
