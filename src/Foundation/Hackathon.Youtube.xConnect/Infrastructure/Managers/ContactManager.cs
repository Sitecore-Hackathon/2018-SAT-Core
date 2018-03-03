using Hackathon.Youtube.xConnect.Infrastructure.Facets;
using Sitecore.Diagnostics;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;
using System;

namespace Hackathon.Youtube.xConnect.Infrastructure.Managers
{
    public class ContactManager : IContactManager
    {
        public void CreateContact(string firstName, string lastName, string email, DateTime birthDate, string gender, string country)
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
                        FirstName = firstName,
                        LastName = lastName,
                        Gender = gender,
                        Birthdate = birthDate
                    }; 

                    client.SetFacet(contact, PersonalInformation.DefaultFacetKey, personalInfoFacet);

                    // Facet without a reference, using default key
                    var emails = new EmailAddressList(new EmailAddress("myrtle@test.test", true), "Home");

                    client.SetFacet(contact, EmailAddressList.DefaultFacetKey, emails);

                    AddressList addresses = new AddressList(new Address() { CountryCode = country  }, "Home");

                    client.SetFacet(contact, AddressList.DefaultFacetKey, addresses);

                    var customFacet = new CustomFacet("Test value");

                    client.SetFacet(contact, CustomFacet.DefaultFacetKey, customFacet);

                    // Submits the batch, which contains two operations
                    client.Submit();
                }
                catch (XdbExecutionException ex)
                {
                    // Manage exception
                }
            }
        }

        public Contact GetContactByIdentifier(string identifier)
        {
            Assert.ArgumentNotNullOrEmpty(identifier, nameof(identifier));

            using (var client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var reference = new IdentifiedContactReference("youtube", identifier);

                    var contact = client.Get<Contact>(reference, new ContactExpandOptions() { });

                    return contact;
                }
                catch (XdbExecutionException ex)
                {
                    // Manage exceptions
                    throw;
                }
            }            
        }
    }
}