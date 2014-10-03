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
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

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
		public IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.Current.GetOwinContext().Authentication;
			}
		}

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }


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

		[Route( "Change" )]
		[HttpPost]
		[Authorize]
		public async Task<IHttpActionResult> Change( ChangePasswordViewModel model )
		{
			if ( ModelState.IsValid )
			{
				var user = await UserManager.FindAsync( model.Username, model.OldPassword );

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
