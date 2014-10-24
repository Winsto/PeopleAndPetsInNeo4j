namespace Neo4jPersistence
{
    using DomainModel;
    using Neo4jClient;
    using System.Collections.Generic;
    
    public class AnimalMapper:Neo4jMapper, Mapper<Animal>
    {
        public void SaveItem(Animal itemToSave)
        {
            var mergeParameters = new Dictionary<string, object>(2);

            mergeParameters["familyName"] = string.Copy(itemToSave.FamilyName);
            mergeParameters["trivialName"] = string.Copy(itemToSave.TrivialName);

            databaseConnection.Cypher.
                Merge("(:Animal {FamilyName:{familyName}, TrivialName:{trivialName}})").
                WithParams(mergeParameters).
                ExecuteWithoutResults();
        }

        protected override void SetupConstraints()
        {
            databaseConnection.Cypher.CreateUniqueConstraint("a:Animal", "a.FamilyName").ExecuteWithoutResults();
            databaseConnection.Cypher.CreateUniqueConstraint("a:Animal", "a.TrivialName").ExecuteWithoutResults();
        }
    }
}
