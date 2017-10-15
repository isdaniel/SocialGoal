using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialGoal
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            var authenticationOptions = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "224284763432-2j56vo40p59ehlu4uun9kresn2imvf3e.apps.googleusercontent.com",
                ClientSecret = "f7luE6I7uHFqGbhWOvKyfIlJ",
            };

            authenticationOptions.Scope.Add("profile");
            // [END configure_google_auth_scopes]

            authenticationOptions.Provider = new GoogleOAuth2AuthenticationProvider()
            {
                // [START read_google_profile_image_url]
                // After OAuth authentication completes successfully,
                // read user's profile image URL from the profile
                // response data and add it to the current user identity
                OnAuthenticated = context =>
                {
                    var profileUrl = context.User["image"]["url"].ToString();
                    context.Identity.AddClaim(new Claim(ClaimTypes.Uri, profileUrl));
                    return Task.FromResult(0);
                }
                // [END read_google_profile_image_url]
            };
            app.UseGoogleAuthentication(authenticationOptions);
            //app.UseGoogleAuthentication();
        }
    }
}