
namespace DomainModel
{
    public class Pet
    {
        private Animal whatAnimalItIs;
        private string whatWeCallIt;

        public Pet(string name, Animal whatAnimalItIs)
        {
            this.whatAnimalItIs = whatAnimalItIs;

            whatWeCallIt = name;
        }

        public Animal WhatAnimalIsIt { get { return whatAnimalItIs; } }

        public string Name { get { return whatWeCallIt; } }
    }
}
