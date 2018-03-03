using System.Threading.Tasks;
using System.Web;
using Google.Apis.Util.Store;

namespace Hackathon.Website.Services
{
    public class CustomDataStore : IDataStore
    {
        public async Task StoreAsync<T>(string key, T value)
        {
            await Task.Run(() =>
            {
                HttpContext.Current.Session[key] = value;
            });
        }

        public Task DeleteAsync<T>(string key)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            return (T) await Task.Run(() => { return HttpContext.Current.Session[key] ?? default(T); });
        }

        public Task ClearAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}