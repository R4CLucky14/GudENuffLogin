using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GufENuffLogInApi.ViewModels
{
	public class DeleteAccountViewModel
	{
		[Required]
		public String Email { get; set; }
		[Required]
		public String Password { get; set; }
	}
}