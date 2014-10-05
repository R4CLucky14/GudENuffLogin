using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GufENuffLogInApi.Extensions;
using System.Web.Http.Filters;

namespace GufENuffLogInApi.DataAnnotations
{
	/// <summary>
	/// Password Attribute checks if the field is a properly formatted string.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
	public class PasswordAttribute : ValidationAttribute
	{
		/// <summary>
		/// Checks to see if the Password is a properly formatted string.
		/// </summary>
		/// <param name="value">The String</param>
		/// <returns>Returns true if the String has digits, letters, capital letters, and accepted symbols, with not illegal characters.</returns>
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
		/// <summary>
		/// Checks to see if the Password is a properly formatted string.
		/// </summary>
		/// <param name="value">The String</param>
		/// <param name="validationContext">The Validation Context</param>
		/// <returns>Returns a Successful Validation Result if the String has digits, letters, capital letters, and accepted symbols, with not illegal characters.</returns>
		protected override ValidationResult IsValid( object value, ValidationContext validationContext )
		{
			var input = value.ToString();
			//The password must have digits, letters – at least one of which must be a capital, and symbols.  The allowable symbols are !, &, *,?.  

			if ( input.HasDigits() && input.HasLetters() && input.HasCapital() && input.HasSymbols() && !input.HasIllegalCharacters() )
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