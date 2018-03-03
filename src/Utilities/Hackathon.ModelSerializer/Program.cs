using Hackathon.Youtube.xConnect.Infrastructure.Models;
using System.IO;

namespace Hackathon.ModelSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = Sitecore.XConnect.Serialization.XdbModelWriter.Serialize(ContactExtendModel.Model);

            File.WriteAllText(ContactExtendModel.Model.FullName + ".json", model);
        }
    }
}
