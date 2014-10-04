using GufENuffLogInApi.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GufENuffLogInApi.ViewModels
{
	/// <summary>
	/// A View Model for changing passwords.
	/// </summary>
	public class ChangePasswordViewModel
	{
		/// <summary>
		/// The User Name / Email of the User Account
		/// </summary>
		[Required]
		public String Username { get; set; }
		/// <summary>
		/// The Current / Old Password of the User Account
		/// </summary>
		[Required]
		[Password]
		public String OldPassword { get; set; }
		/// <summary>
		/// The Desired / New Password of the User Account
		/// </summary>
		[Required]
		[Password]
		public String NewPassword { get; set; }
	}
}