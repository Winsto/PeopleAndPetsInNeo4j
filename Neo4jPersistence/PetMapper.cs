namespace Neo4jPersistence
{
    using DomainModel;
    using System;
    using System.Collections.Generic;

    public sealed class PetMapper : Neo4jMapper, Mapper<Pet>
    {
        private Mapper<Animal> animalMapper;

        public PetMapper(Mapper<Animal> animalMapper)
        {
            if (animalMapper == null)
                throw new ArgumentException("Must have an animalMapper");

            this.animalMapper = animalMapper;
        }

        protected override void SetupConstraints()
        {
            // No Constraints needed for Pets.
        }

        public void SaveItem(Pet itemToSave)
        {
            animalMapper.SaveItem(itemToSave.WhatAnimalIsIt);

            databaseConnection.Cypher.
                Merge("(:Pet {Name:{petName}})").
                WithParam("petName",itemToSave.Name).
                ExecuteWithoutResults();

            databaseConnection.Cypher.
                Match("(pet:Pet), (animalFamily:Animal)").
                Where<Pet>(pet => pet.Name == itemToSave.Name).
                AndWhere<Animal>(animalFamily => animalFamily.TrivialName == itemToSave.WhatAnimalIsIt.TrivialName).
                Merge("(pet)-[:IsMemberOf]->(animalFamily)").
                ExecuteWithoutResults();


        }
    }
}
