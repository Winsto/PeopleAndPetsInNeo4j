namespace Neo4jPersistence
{
    using Neo4jClient;
    using System;

    public static class DatabaseHelper
    {
        private static GraphClient db;

        static DatabaseHelper()
        {
            db = new GraphClient(new Uri("http://localhost:7474/db/data"));
            db.Connect();
        }

        public static GraphClient ConnectToDatabase()
        {
            return db;
        }
    }
}
