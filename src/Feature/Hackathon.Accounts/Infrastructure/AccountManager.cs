using Hackathon.Youtube.xConnect.Infrastructure.Managers;
using System;
using System.Web.Security;

namespace Hackathon.Accounts.Infrastructure
{
    public class AccountManager : IAccountManager
    {
        private static string Domain = "extranet";

        public void Register(string firstName, string lastName, string email, string password, string dateOfBirth, string gender, string country)
        {
            var userName = string.Format(@"{0}\{1}", Domain, email);

            try
            {
                if (!Sitecore.Security.Accounts.User.Exists(userName))
                {
                    Membership.CreateUser(userName, password, email);

                    // Edit the profile information
                    Sitecore.Security.Accounts.User user = Sitecore.Security.Accounts.User.FromName(userName, true);
                    Sitecore.Security.UserProfile userProfile = user.Profile;
                    userProfile.FullName = string.Format("{0} {1}", firstName, lastName);

                    // TODO: set dOb gender country to contact in xDb
                    var contactManager = new ContactManager();

                    contactManager.CreateContact(firstName, lastName, email, DateTime.Parse(dateOfBirth), gender, country);
                }
            }
            catch (Exception ex)
            {
                // log error
            }
        }

        public void Login(string email, string password)
        {
            try
            {
                Sitecore.Security.Domains.Domain domain = Sitecore.Context.Domain;
                string domainUser = domain.Name + @"\" + email;
                if (Sitecore.Security.Authentication.AuthenticationManager.Login(domainUser, password))
                {
                    Sitecore.Web.WebUtil.Redirect("/");
                }
                else
                {
                    throw new System.Security.Authentication.AuthenticationException(
                    "Invalid username or password.");
                }
            }
            catch (System.Security.Authentication.AuthenticationException)
            {
      
            }

        }
    }
}