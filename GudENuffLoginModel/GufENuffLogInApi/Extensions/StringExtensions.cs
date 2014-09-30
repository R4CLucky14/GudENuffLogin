using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GufENuffLogInApi.Extensions
{
	public static class StringExtensions
	{
		public static Boolean HasDigits( this String value )
		{
			return Regex.IsMatch( value, "[0-9]+" );
		}
		public static Boolean HasLetters( this String value )
		{
			return Regex.IsMatch(value, "[a-z, A-Z]+");
		}
		public static Boolean HasCapital( this String value )
		{
			return Regex.IsMatch(value, "[A-Z]+");
		}
		public static Boolean HasSymbols( this String value )
		{
			return Regex.IsMatch(value, "[&!*?]+");
		}
		public static Boolean HasIllegalCharacters( this String value)
		{
			return Regex.IsMatch( value, "[^a-zA-Z_0-9_&!*?]+" );
		}
	}
}