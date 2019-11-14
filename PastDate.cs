using System.ComponentModel.DataAnnotations;
using System;

namespace formsubmit.Models.Validators
{
	public class PastDateAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if((DateTime) value > DateTime.Now){
				return new ValidationResult("Date must be in the past!");
			}
			else{
				return ValidationResult.Success;
			}
		}
	}
}