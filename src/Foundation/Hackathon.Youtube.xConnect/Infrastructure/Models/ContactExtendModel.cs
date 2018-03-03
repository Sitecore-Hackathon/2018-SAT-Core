using Hackathon.Youtube.xConnect.Infrastructure.Facets;
using Sitecore.XConnect;
using Sitecore.XConnect.Schema;

namespace Hackathon.Youtube.xConnect.Infrastructure.Models
{
    public class ContactExtendModel
    {
        public static XdbModel Model { get; } = BuildModel();

        private static XdbModel BuildModel()
        {
            var builder = new XdbModelBuilder("ContactExtendModel", new XdbModelVersion(1, 0));
            builder.ReferenceModel(Sitecore.XConnect.Collection.Model.CollectionModel.Model);
            builder.DefineFacet<Contact, CustomFacet>(CustomFacet.DefaultFacetKey);

            return builder.BuildModel();
        }
    }
}