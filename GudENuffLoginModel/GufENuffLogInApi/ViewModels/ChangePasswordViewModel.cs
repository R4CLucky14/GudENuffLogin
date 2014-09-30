using GufENuffLogInApi.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GufENuffLogInApi.ViewModels
{
	public class ChangePasswordViewModel
	{
		[Required]
		public String Username { get; set; }
		[Required]
		[Password]
		public String OldPassword { get; set; }
		[Required]
		[Password]
		public String NewPassword { get; set; }
	}
}