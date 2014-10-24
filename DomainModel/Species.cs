
namespace DomainModel
{
    public class Species
    {
        private string speciesCommonName;

        public Species(string commonName = "")
        {
            speciesCommonName = commonName;
        }

        public string CommonName { get { return speciesCommonName; } }
    }
}
