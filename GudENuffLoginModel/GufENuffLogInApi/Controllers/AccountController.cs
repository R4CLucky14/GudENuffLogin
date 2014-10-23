using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using GufENuffLogInApi.Models;
using GufENuffLogInApi.Providers;
using GufENuffLogInApi.Results;
using GufENuffLogInApi.ViewModels;
using System.Net;
using System.Web.Security;
using GufENuffLogInApi.DataAnnotations;

namespace GufENuffLogInApi.Controllers
{
	/// <summary>
	/// Allows the creation, deletion, and modifying of User Accounts, along with logging in.
	/// </summary>
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
		private ApplicationContext db;

        public AccountController()
        {
			ApplicationContext db = new ApplicationContext();
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat, ApplicationContext db)
        {
            UserManager = userManager;
			AccessTokenFormat = accessTokenFormat;
			this.db = db;
        }

		/// <summary>
		/// Returns the User Manager
		/// </summary>
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
		/// <summary>
		/// Returns the Context's Authenitcation Manager.
		/// </summary>
		public IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.Current.GetOwinContext().Authentication;
			}
		}

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

		/// <summary>
		/// Returns an Ok result - used to ensure the API Connection is working
		/// </summary>
		/// <returns>Ok result</returns>
		[HttpGet]
		public IHttpActionResult Status()
		{
			return Ok();
		}

		/// <summary>
		/// Logs a user in using External Bearer Token.
		/// </summary>
		/// <param name="model">A View Model containing information to log a user in.</param>
		/// <returns>Returns an Ok statement if successfully authenticated. Otherwise, it will return Unauthorized if the combination was bad, and a Bad Request if the View Model data was improperly formatted.</returns>
		[Route( "Login" )]
		[HttpPost]
		public async Task<IHttpActionResult> Login( LogInViewModel model )
		{
			if ( ModelState.IsValid )
			{
				var user = await UserManager.FindAsync( model.Email, model.Password );

				if ( user != null )
				{
					await this.SignInAsync( user, true );
					return Ok();
				}
				else
				{
					//We were passed incorrect user information. We will return an unauthorized result.
					return Unauthorized();
				}
			}
			else
			{
				return BadRequest("Incomplete User Information");
			}
		}
		
		/// <summary>
		/// Creates a new User Account. 
		/// </summary>
		/// <param name="model">A ViewModel containing information to create a user account.</param>
		/// <returns>Returns an Ok statement if the account was created and logged in. Returns a Bad Request if the </returns>
		[Route( "Create" )]
		[HttpPost]
		public async Task<IHttpActionResult> Create( CreateAccountViewModel model )
		{
			if ( ModelState.IsValid )
			{
				var userExists = await UserManager.Users.AnyAsync( c => c.UserName == model.Email );
				if ( userExists )
				{
					//User is already created. Return a bad request (can't create duplicate usernames)
					return BadRequest( "UserName already Used" );
				}
				else
				{
					//User does not exist. Create user.

					var user = new ApplicationUser( model );
					var success = await UserManager.CreateAsync( user, model.Password );
					if ( success.Succeeded )
					{
						await this.SignInAsync( user, true );
						return Ok();
					}
					else
					{
						//return bad request.
						return BadRequest( success.Errors.ToString() );
					}
				}
			}
			else
			{
				return BadRequest( "Incomplete User Information" );
			}
		}

		/// <summary>
		/// Allows the modification of a password.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route( "Change" )]
		[HttpPost]
		//[Authorize]
		public async Task<IHttpActionResult> Change( ChangePasswordViewModel model )
		{
			if ( ModelState.IsValid )
			{
				var user = await UserManager.FindAsync( model.Email, model.OldPassword );

				if ( user != null )
				{
					var result = await UserManager.ChangePasswordAsync( user.Id, model.OldPassword, model.NewPassword );
					if ( result.Succeeded )
					{
						await this.SignInAsync( user, true );
						return Ok();
					}
					else
					{
						return BadRequest( "Problem Changing Account. Please check user information and try again." );
					}
				}
				else
				{
					//We were passed incorrect user information. We will return an unauthorized result.
					return Unauthorized();
				}
			}
			else
			{
				return BadRequest("Incomplete User Information");
			}
		}

		/// <summary>
		/// Allows the user to delete his/her account.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Route( "Change" )]
		[HttpPost]
		public async Task<IHttpActionResult> Delete ( DeleteAccountViewModel model )
		{
			if ( ModelState.IsValid )
			{
				var user = await UserManager.Users.FirstOrDefaultAsync( c => c.UserName == model.Email );

				if ( user != null )
				{
					//User Exists - Delete User
					db.Users.Remove( user );
					return Ok();
				}
				else
				{
					//User does not exist.
					return BadRequest( "User does not exist" );				
				}
			}
			else
			{
				//Improper model provided
				return BadRequest( "Incomplete User Information" );
			}
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UserManager.Dispose();
            }

            base.Dispose(disposing);
        }
		private async Task SignInAsync(ApplicationUser user, bool isPersistent)
		{
			AuthenticationManager.SignOut( DefaultAuthenticationTypes.ExternalBearer );
			var identity = await UserManager.CreateIdentityAsync( user, DefaultAuthenticationTypes.ExternalBearer );
			AuthenticationManager.SignIn( new AuthenticationProperties() { IsPersistent = isPersistent }, identity );
		}
	}
}
