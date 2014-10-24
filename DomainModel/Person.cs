using System.Collections.Generic;

namespace DomainModel
{
    public class Person
    {
        private string name;
        private List<Pet> petsOwned = new List<Pet>();

        public Person(string name)
        {
            this.name = name;
        }

        public string Name { get { return name; } }

        public IEnumerable<Pet> Pets { get { return petsOwned.AsReadOnly(); } }

        public void CaresFor(Pet petCaredFor)
        {
            petsOwned.Add(petCaredFor);
        }
    }
}
