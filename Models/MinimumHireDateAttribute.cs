using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models
{
	public class MinimumHireDateAttribute : ValidationAttribute, IClientModelValidator
	{

		protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
		{
			if(value is DateTime)
			{
				DateTime dateToCheck = (DateTime)value;
				if (dateToCheck >= new DateTime(1995, 1 ,1))
				{
					return ValidationResult.Success!;	
				}
			}
			return new ValidationResult(GetMsg(ctx.DisplayName ?? "Date"));
		}

		public void AddValidation(ClientModelValidationContext ctx) {
			if (!ctx.Attributes.ContainsKey("data-val"))
				ctx.Attributes.Add("data-val", "true");
			ctx.Attributes.Add("data-val-minimumhiredate-hiredate",
				"1/1/1995");
			ctx.Attributes.Add("data-val-minimumage",
				GetMsg(ctx.ModelMetadata.DisplayName ?? ctx.ModelMetadata.Name ?? "Date"));
		}

		private string GetMsg(string name) =>
			base.ErrorMessage ?? $"{name} must be on or after 1/1/1995 ";

	}
}
