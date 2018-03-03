using Sitecore.XConnect;

namespace Hackathon.Youtube.xConnect.Infrastructure.Facets
{
    [FacetKey(DefaultFacetKey)]
    public class CustomFacet: Facet
    {
        public const string DefaultFacetKey = "CustomFacet";

        public string FacetValue { get; private set; }

        private CustomFacet() { }

        public CustomFacet(string facetValue)
        {
            this.FacetValue = facetValue;
        }
    }
}