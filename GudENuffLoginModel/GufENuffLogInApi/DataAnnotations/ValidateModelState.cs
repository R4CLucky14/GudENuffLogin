using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GufENuffLogInApi.Extensions;
using System.Web.Http.Filters;

namespace GufENuffLogInApi.DataAnnotations
{
	public class PasswordAttribute : ValidationAttribute
	{
		public override bool IsValid( object value )
		{
			var input = value.ToString();
			//The password must have digits, letters – at least one of which must be a capital, and symbols.  The allowable symbols are !, &, *,?.  

			if(input.HasDigits() && input.HasLetters() && input.HasCapital() && input.HasSymbols() && !input.HasIllegalCharacters())
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		protected override ValidationResult IsValid( object value, ValidationContext validationContext )
		{
			var input = value.ToString();
			//The password must have digits, letters – at least one of which must be a capital, and symbols.  The allowable symbols are !, &, *,?.  

			if ( input.HasDigits() && input.HasLetters() && input.HasCapital() && input.HasSymbols() )
			{
				return ValidationResult.Success;
			}
			else
			{
				return new ValidationResult("Incorrect password.");
			}
		}
	}
}