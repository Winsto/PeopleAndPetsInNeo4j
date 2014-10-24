namespace Neo4jPersistence
{
    public interface Mapper<T>
    {
        void SaveItem(T itemToSave);
    }
}
