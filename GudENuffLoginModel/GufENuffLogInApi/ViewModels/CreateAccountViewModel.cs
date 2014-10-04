using GufENuffLogInApi.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GufENuffLogInApi.ViewModels
{
	/// <summary>
	/// A View Model for creating a new Account.
	/// </summary>
	public class CreateAccountViewModel
	{
		/// <summary>
		/// The Email Address for the Account.
		/// </summary>
		[Required]
		public String Email { get; set; }
		/// <summary>
		/// A properly formatted password for the Account.
		/// </summary>
		[Required]
		[Password]
		public String Password { get; set; }
		/// <summary>
		/// A properly formatted password, matching the Password.
		/// </summary>
		[Required]
		[Compare("Password")]
		public String ConfirmPassword { get; set; }
	}
}