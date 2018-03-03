namespace Hackathon.Accounts.Infrastructure
{
    public interface IAccountManager
    {
        void Register(string firstName, string lastName, string email, string password, string dateOfBirth, string gender, string country);
        void Login(string email, string password);
    }
}