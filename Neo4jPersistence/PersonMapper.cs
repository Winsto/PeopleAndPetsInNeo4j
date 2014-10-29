namespace Neo4jPersistence
{
    using DomainModel;
    using System;

    public sealed class PersonMapper : Neo4jMapper, Mapper<Person>
    {
        private Mapper<Pet> petMapper;

        public PersonMapper(Mapper<Pet> petMapper)
        {
            if (petMapper == null)
                throw new ArgumentException("Must have an petMapper");

            this.petMapper = petMapper;
        }

        protected override void SetupConstraints()                                                                      
        {
            databaseConnection.Cypher.CreateUniqueConstraint("p:Person", "p.Name").ExecuteWithoutResults();
        }

        public void SaveItem(Person itemToSave)
        {
            databaseConnection.Cypher.
                Merge("(:Person {Name:{name}})").
                WithParam("name", itemToSave.Name).
                ExecuteWithoutResults();

            foreach (Pet petToSave in itemToSave.Pets)
            {
                petMapper.SaveItem(petToSave);

                databaseConnection.Cypher.
                    Match("(person:Person), (pet:Pet)").
                    Where<Person>(person => person.Name == itemToSave.Name).
                    AndWhere<Pet>(pet => pet.Name == petToSave.Name).
                    AndWhere(" not (:Person)-[:CaresFor]-(pet)").
                    Merge("(person)-[:CaresFor]->(pet)").
                    ExecuteWithoutResults();

            }
        }
    }
}
