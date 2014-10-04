using GufENuffLogInApi.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace GufENuffLogInApi.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	/// <summary>
	/// The User Account for Application Users.
	/// </summary>
	public class ApplicationUser : IdentityUser
	{
		/// <summary>
		/// Returns the User Identity.
		/// </summary>
		/// <param name="manager">The Application's User Manager</param>
		/// <param name="authenticationType">The Type of Authenitcation being used</param>
		/// <returns>The User Identity</returns>
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync( UserManager<ApplicationUser> manager, string authenticationType )
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync( this, authenticationType );
			// Add custom user claims here
			return userIdentity;
		}

		public ApplicationUser()
		{

		}
		/// <summary>
		/// Populates the Email field of a new User.
		/// </summary>
		/// <param name="model">The Create Account View Model to be converted to a User</param>
		public ApplicationUser(CreateAccountViewModel model)
			: base(model.Email)
		{
			this.Email = model.Email;
		}
	}
}