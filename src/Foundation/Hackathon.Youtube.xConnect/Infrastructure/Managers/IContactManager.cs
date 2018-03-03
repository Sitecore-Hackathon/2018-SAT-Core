namespace Hackathon.Youtube.xConnect.Infrastructure.Managers
{
    public interface IContactManager
    {
        void CreateContact(string firstName, string lastName, string email, string dateOfBirth, string gender, string country);
    }
}