
namespace TestClient
{
    using DomainModel;
    using Neo4jPersistence;

    class Program
    {
        static void Main(string[] args)
        {
            var dogs = new Animal(familyName: "Canidae", trivialName: "dog");

            var cats = new Animal(familyName: "Felidae", trivialName: "cat");

            var cattle = new Animal(familyName: "Bovidae", trivialName: "cattle");

            var bandicoots = new Animal(familyName: "Peramelidae", trivialName: "bandicoots");

            var crashBanidcoot = new Pet(name: "Crash", whatAnimalItIs: bandicoots);

            var adam = new Person("Adam");

            var steve = new Person("Steve");

            adam.CaresFor(crashBanidcoot);

            steve.CaresFor(new Pet(name:"Rex", whatAnimalItIs:dogs));

            adam.CaresFor(new Pet(name:"Rex", whatAnimalItIs:dogs));

            var providesMappers = new SimpleContainer();
            
            providesMappers.ResolvePersonMapper().SaveItem(adam);

            providesMappers.ResolvePersonMapper().SaveItem(steve);
        }
    }
}
