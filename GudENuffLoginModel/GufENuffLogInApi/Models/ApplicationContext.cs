using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GufENuffLogInApi.Models
{
	public class ApplicationContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationContext()
			: base( "DefaultConnection", throwIfV1Schema: false )
		{
		}

		public static ApplicationContext Create()
		{
			return new ApplicationContext();
		}
	}
}