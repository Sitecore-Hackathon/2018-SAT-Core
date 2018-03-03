using Sitecore.Diagnostics;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;

namespace Hackathon.Youtube.xConnect.Infrastructure.Managers
{
    public class ContactManager : IContactManager
    {
        public void CreateContact(string firstName, string lastName, string email, string dateOfBirth, string gender, string country)
        {
            using (var client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var contact = new Sitecore.XConnect.Contact(new ContactIdentifier("youtube", email, ContactIdentifierType.Known));
                    
                    client.AddContact(contact); // Extension found in Sitecore.XConnect.Operations

                    // Facet with a reference object, key is specified
                    PersonalInformation personalInfoFacet = new PersonalInformation()
                    {
                        FirstName = "Myrtle",
                        LastName = "McSitecore"
                    };

                    var reference = new FacetReference(contact, PersonalInformation.DefaultFacetKey);

                    client.SetFacet(contact, PersonalInformation.DefaultFacetKey, personalInfoFacet);

                    // Facet without a reference, using default key
                    var emails = new EmailAddressList(new EmailAddress("myrtle@test.test", true), "Home");

                    client.SetFacet(contact, EmailAddressList.DefaultFacetKey, emails);

                    AddressList addresses = new AddressList(new Address() { CountryCode = country  }, "Home");

                    client.SetFacet(contact, AddressList.DefaultFacetKey, addresses);

                    // TODO: Add custom facets for storing gender and dateofBirth

                    // Submits the batch, which contains two operations
                    client.Submit();
                }
                catch (XdbExecutionException ex)
                {
                    // Manage exception
                }
            }
        }

        public void GetContactByIdentifier(string identifier)
        {
            Assert.ArgumentNotNullOrEmpty(identifier, nameof(identifier));

            using (var client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var reference = new IdentifiedContactReference("youtube", identifier);

                    var contact = client.Get<Contact>(reference, new ContactExpandOptions() { });
                }
                catch (XdbExecutionException ex)
                {
                    // Manage exceptions
                }
            }
        } 
    }
}