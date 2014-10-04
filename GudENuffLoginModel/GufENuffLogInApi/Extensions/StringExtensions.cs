using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GufENuffLogInApi.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Checks to see if a String contains digits
		/// </summary>
		/// <param name="value">The String</param>
		/// <returns>Returns true if the String contains at least 1 numerical digit</returns>
		public static Boolean HasDigits( this String value )
		{
			return Regex.IsMatch( value, "[0-9]+" );
		}
		/// <summary>
		/// Checks to see if a String has alphabetical characters.
		/// </summary>
		/// <param name="value">The String</param>
		/// <returns>Returns true if the string contains at least 1 alphabetical character.</returns>
		public static Boolean HasLetters( this String value )
		{
			return Regex.IsMatch(value, "[a-z, A-Z]+");
		}
		/// <summary>
		/// Checks to see if a String has at least 1 capital alphabetical character.
		/// </summary>
		/// <param name="value">The String</param>
		/// <returns>Returns true if the string contains at least 1 capital alphabetical character.</returns>
		public static Boolean HasCapital( this String value )
		{
			return Regex.IsMatch(value, "[A-Z]+");
		}
		/// <summary>
		/// Checks to see if a String has acceptable symbols.
		/// </summary>
		/// <param name="value">The String</param>
		/// <returns>Returns true if at least one accepted symbol appears.</returns>
		public static Boolean HasSymbols( this String value )
		{
			return Regex.IsMatch(value, "[&!*?]+");
		}
		/// <summary>
		/// Checks to see if a String has Illegal (Unacceptable) characters.
		/// </summary>
		/// <param name="value">The String</param>
		/// <returns>Returns true is at least one illegal character is found.</returns>
		public static Boolean HasIllegalCharacters( this String value)
		{
			return Regex.IsMatch( value, "[^a-zA-Z_0-9_&!*?]+" );
		}
	}
}