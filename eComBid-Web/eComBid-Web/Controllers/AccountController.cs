using eComBid_Web.BL;
using eComBid_Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace eComBid_Web.Controllers
{
    public class AccountController : baseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Get for login
        /// </summary>
        /// <returns>login view</returns>
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            return View();
        }

        #region External Provider Logins

        // POST: /Account/ExternalLogin
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider)
        {
            string returnUrl = Url.Action("Index", "Test", null);

            return new ChallengeResult(provider,
                Url.Action("ExternalLoginCallbackreturn", "Index",
                new { returnUrl = returnUrl }));
        }

        public async Task<ActionResult> ExternalLoginCallbackreturn(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
                returnUrl = "~/";

            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
                return RedirectToAction("Login");

            // AUTHENTICATED!
            var providerKey = loginInfo.Login.ProviderKey;

            //TODO: check if user exists otherwise create a new account for him
            //var user = Pet2Share_API.Service.AccountManagement.Login(providerKey, "");
            //// Aplication specific code goes here.
            //var userBus = new busUser();
            //var user = userBus.ValidateUserWithExternalLogin(providerKey);
            //if (user == null)
            //{
            //    return RedirectToAction("LogOn", new
            //    {
            //        message = "Unable to log in with " + loginInfo.Login.LoginProvider +
            //                  ". " + userBus.ErrorMessage
            //    });
            //}

            // store on AppUser
            AppUserState appUserState = new AppUserState();
           // appUserState.FromUser(user);

            // write the authentication cookie
            IdentitySignin(appUserState, providerKey, isPersistent: true);

            return Redirect(returnUrl);
            // return  RedirectToAction("ExternalLoginCallback", "Index", new { returnUrl = returnUrl });
        }

        #region NotUsed/TobeRemoved
        //// GET: /Account/ExternalLoginCallback
        //[AllowAnonymous]
        //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //    if (string.IsNullOrEmpty(returnUrl))
        //        returnUrl = "~/";

        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        //    if (loginInfo == null)
        //        return RedirectToAction("Login");

        //    // AUTHENTICATED!
        //    var providerKey = loginInfo.Login.ProviderKey;


        //    var user = Pet2Share_API.Service.AccountManagement.Login(providerKey, "");
        //    //// Aplication specific code goes here.
        //    //var userBus = new busUser();
        //    //var user = userBus.ValidateUserWithExternalLogin(providerKey);
        //    //if (user == null)
        //    //{
        //    //    return RedirectToAction("LogOn", new
        //    //    {
        //    //        message = "Unable to log in with " + loginInfo.Login.LoginProvider +
        //    //                  ". " + userBus.ErrorMessage
        //    //    });
        //    //}

        //    // store on AppUser
        //    AppUserState appUserState = new AppUserState();
        //    appUserState.FromUser(user);

        //    // write the authentication cookie
        //    IdentitySignin(appUserState, providerKey, isPersistent: true);

        //    return Redirect(returnUrl);
        //}

        // Initiate oAuth call for external Login
        // GET: /Account/ExternalLinkLogin
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLinkLogin(string provider)
        {
            var id = Request.Form["Id"];

            // create an empty AppUser with a new generated id
            AppUserState.UserId = id;
            AppUserState.Name = "";
            IdentitySignin(AppUserState, null);

            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action("ExternalLinkLoginCallback"), AppUserState.UserId);
        }

        // oAuth Callback for external login
        // GET: /Manage/LinkLogin
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> ExternalLinkLoginCallback()
        {
            //// Handle external Login Callback
            //var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, AppUserState.UserId);
            //if (loginInfo == null)
            //{
            //    IdentitySignout(); // to be safe we log out
            //    return RedirectToAction("Register", new { message = "Unable to authenticate with external login." });
            //}

            //// Authenticated!
            //string providerKey = loginInfo.Login.ProviderKey;
            //string providerName = loginInfo.Login.LoginProvider;

            //// Now load, create or update our custom user

            //// normalize email and username if available
            //if (string.IsNullOrEmpty(AppUserState.Email))
            //    AppUserState.Email = loginInfo.Email;
            //if (string.IsNullOrEmpty(AppUserState.Name))
            //    AppUserState.Name = loginInfo.DefaultUserName;
            //Pet2Share_API.Domain.User result;
            //if (!Pet2Share_API.Service.AccountManagement.IsExistingUser(loginInfo.Email))
            //{
            //    result = new Pet2Share_API.Domain.User(new Pet2Share_API.Domain.User() { Email = loginInfo.Email });
            //}

            //result = Pet2Share_API.Service.AccountManagement.RegisterNewUser(loginInfo.Email, "", loginInfo.DefaultUserName, "", loginInfo.Email, null);



            //// update the actual identity cookie
            //AppUserState.FromUser(result);
            //IdentitySignin(AppUserState, loginInfo.Login.ProviderKey);

            return RedirectToAction("Index", "Test");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExternalUnlinkLogin()
        //{
        //    var userId = AppUserState.UserId;
        //    var user = busUser.Load(userId);
        //    if (user == null)
        //    {
        //        ErrorDisplay.ShowError("Couldn't find associated User: " + busUser.ErrorMessage);
        //        return RedirectToAction("Register", new { id = userId });
        //    }
        //    user.OpenId = string.Empty;
        //    user.OpenIdClaim = string.Empty;

        //    if (busUser.Save())
        //        return RedirectToAction("Register", new { id = userId });

        //    return RedirectToAction("Register", new { message = "Unable to unlink OpenId. " + busUser.ErrorMessage });
        //}



        // **** Helpers 

        // Used for XSRF protection when adding external logins

        #endregion

        private const string XsrfKey = "EcomBid_$31!.2*#";

        public class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                    properties.Dictionary[XsrfKey] = UserId;

                var owin = context.HttpContext.GetOwinContext();
                owin.Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion

        #region IdentitySignIn/SignOut
        public void IdentitySignin(AppUserState appUserState, string providerKey = null, bool isPersistent = false)
        {
            var claims = new List<Claim>();

            // create required claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUserState.UserId));
            claims.Add(new Claim(ClaimTypes.Name, appUserState.Name));

            // custom – my serialized AppUserState object
            claims.Add(new Claim("userState", appUserState.ToString()));

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, identity);
        }

        public void IdentitySignout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                                            DefaultAuthenticationTypes.ExternalCookie);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        #endregion

    }
}