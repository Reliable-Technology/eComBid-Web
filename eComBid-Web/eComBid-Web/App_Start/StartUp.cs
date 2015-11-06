using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;

namespace eComBid_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login")
            });


            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // App.Secrets is application specific and holds values in CodePasteKeys.json
            // Values are NOT included in repro – auto-created on first load
   //         if (!string.IsNullOrEmpty(BLAuth.GoogleClientId))
   //         {
   //             app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
   //             {
   //                 ClientId = BLAuth.GoogleClientId,
   //                 ClientSecret = BLAuth.GoogleClientSecret,
   //                 CallbackPath = new PathString("/Index/ExternalLoginCallback")
   //             }
   //);
   //         }

   //         if (!string.IsNullOrEmpty(BLAuth.TwitterConsumerKey))
   //         {
   //             app.UseTwitterAuthentication(
   //                 consumerKey: BLAuth.TwitterConsumerKey,
   //                 consumerSecret: BLAuth.TwitterConsumerSecret);
   //         }

   //         if (!string.IsNullOrEmpty(BLAuth.FacebookAppId))
   //         {
   //             app.UseFacebookAuthentication(
   //                 appId: BLAuth.FacebookAppId,
   //                 appSecret: BLAuth.FacebookAppSecret);
   //         }

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}