
namespace DomainModel
{
    public class Pet
    {
        private Species whatAnimalItIs;
        private string whatWeCallIt;

        public Pet(string name, Species whatAnimalItIs)
        {
            this.whatAnimalItIs = whatAnimalItIs;

            whatWeCallIt = name;
        }

        public Species WhatIsIt { get { return whatAnimalItIs; } }

        public string Name { get { return whatWeCallIt; } }
    }
}
