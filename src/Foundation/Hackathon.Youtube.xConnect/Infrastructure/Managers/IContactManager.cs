using Sitecore.XConnect;
using System;

namespace Hackathon.Youtube.xConnect.Infrastructure.Managers
{
    public interface IContactManager
    {
        void CreateContact(string firstName, string lastName, string email, DateTime birthDate, string gender, string country);
        Contact GetContactByIdentifier(string identifier);
    }
}