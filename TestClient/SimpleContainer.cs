namespace TestClient
{
    using DomainModel;
    using Neo4jPersistence;

    public sealed class SimpleContainer
    {
        private AnimalMapper mapsAnimals;
        private PetMapper mapsPets;
        private PersonMapper mapsPersons;

        public SimpleContainer()
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            mapsAnimals = new AnimalMapper();

            mapsPets = new PetMapper(animalMapper: mapsAnimals);

            mapsPersons = new PersonMapper(petMapper: mapsPets);
        }

        public AnimalMapper ResolveAnimalMapper()
        {
            return mapsAnimals;
        }

        public PetMapper ResolvePetMapper()
        {
            return mapsPets;
        }

        public PersonMapper ResolvePersonMapper()
        {
            return mapsPersons;
        }
    }
}
