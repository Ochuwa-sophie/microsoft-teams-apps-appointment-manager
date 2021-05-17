using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class SendMail
    {
        private readonly IConfiguration _appSettings;

        //constructor
        public SendMail(IConfiguration appSettings)
        {
            _appSettings = appSettings;
        }

        //convert password to secure string
        private static SecureString ConvertTosecurestr(string password)
        {
            SecureString secureString = new SecureString();

            foreach (char c in password.ToCharArray())
            {
                secureString.AppendChar(c);
            }

            return secureString;
        }

        //method to send mail with graph api
        public async Task<bool> NewEmail(string to, string subject = "Infinion Bank OTP", string message = "")
        {
            string OTP = GenerateOTP.RandomNumber();
            
            string html;
            var tenantId = _appSettings["TenantId"];
            if (string.IsNullOrEmpty(message))
            {
                 html = "Please use the OTP code: <bold>" + OTP + "</bold> for your transaction";
            }
            else
            {
                html = message;
            }

            


            string authority = $"https://login.microsoftonline.com/{tenantId}";

            // The client ID of the app registered in Azure AD
            var clientId = _appSettings["ClientId"];

            var clientSecret = _appSettings["ClientSecret"];

            var scopes = "user.read mail.send";
            // The app registration should be configured to require access to permissions
            // sufficient for the Microsoft Graph API calls the app will be making, and
            // those permissions should be granted by a tenant administrator.
            var scopesarr = new string[] { scopes };

            var confidentialClient = PublicClientApplicationBuilder
                .Create(clientId)
                .WithAuthority(authority)
                .Build();
            string username = _appSettings["User"];
            SecureString secureString = ConvertTosecurestr(_appSettings["Password"]);

            // Build the Microsoft Graph client. As the authentication provider, set an async lambda
            // which uses the MSAL client to obtain an app-only access token to Microsoft Graph,
            // and inserts this access token in the Authorization header of each API request.

            var authResult = await confidentialClient
                        .AcquireTokenByUsernamePassword(scopesarr, username, secureString)
                        .ExecuteAsync();


            string auths = authResult.AccessToken;

            GraphServiceClient graphServiceClient =
                 new GraphServiceClient(
                    new DelegateAuthenticationProvider(
                        async (requestMessage) =>
                        { 
                        // Add the access token in the Authorization header of the API request.
                            requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                        })
                );


            if (to == null) return false;
            // Prepare the recipient list.

            List<Recipient> recipientList = new List<Recipient>()
            { new Recipient
            //var recipientList = recipients.Select(recipient => new Recipient
                {
                    EmailAddress = new EmailAddress

                    {
                        Address = to
                    }
                }
            };


            // Build the email message.
            var email = new Message
            {
                Body = new ItemBody
                {

                    Content = html,
                    ContentType = BodyType.Html,
                },
                Subject = subject,
                ToRecipients = recipientList
            };

            try
            {
                await graphServiceClient.Me.SendMail(email, true).Request().PostAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }

}
