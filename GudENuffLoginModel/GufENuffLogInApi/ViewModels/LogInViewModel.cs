using GufENuffLogInApi.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GufENuffLogInApi.ViewModels
{
	/// <summary>
	/// A View Model for Logging In a User
	/// </summary>
	public class LogInViewModel
	{
		/// <summary>
		/// The Username / Email of the User Account
		/// </summary>
		[Required]
		public String Email { get; set; }
		/// <summary>
		/// The Password of the User Account
		/// </summary>
		[Required]
		[Password]
		public String Password { get; set; }
	}
}