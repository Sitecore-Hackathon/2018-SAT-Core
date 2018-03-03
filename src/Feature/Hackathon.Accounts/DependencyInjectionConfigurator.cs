using Hackathon.Accounts.Controllers;
using Hackathon.Accounts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Hackathon.Accounts
{
    public class DependencyInjectionConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<AccountController>();
            serviceCollection.AddSingleton<IAccountManager, AccountManager>();
        }
    }
}