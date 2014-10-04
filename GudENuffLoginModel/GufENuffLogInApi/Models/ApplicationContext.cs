using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GufENuffLogInApi.Models
{
	/// <summary>
	/// The Context For Connecting to the Database
	/// </summary>
	public class ApplicationContext : IdentityDbContext<ApplicationUser>
	{
		/// <summary>
		/// Default Constructor for Application Context
		/// </summary>
		public ApplicationContext()
			: base( "DefaultConnection", throwIfV1Schema: false )
		{
		}

		/// <summary>
		/// Returns a new Application Context
		/// </summary>
		/// <returns>A new Application Context</returns>
		public static ApplicationContext Create()
		{
			return new ApplicationContext();
		}
	}
}