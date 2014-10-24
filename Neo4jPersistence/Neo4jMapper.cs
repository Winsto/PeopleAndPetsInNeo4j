namespace Neo4jPersistence
{
    using Neo4jClient;
    
    public abstract class Neo4jMapper
    {
        protected GraphClient databaseConnection;

        public Neo4jMapper()
        {
            databaseConnection = DatabaseHelper.ConnectToDatabase();

            SetupConstraints();
        }

        protected abstract void SetupConstraints();
    }
}
