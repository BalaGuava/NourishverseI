using MongoDB.Driver;
using GameSharedModels;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
//the sample of link to game shared models
    public IMongoCollection<Tool> Tools => _database.GetCollection<Tool>("Tools");
    public IMongoCollection<Metrical> Metricals => _database.GetCollection<Metrical>("Metricals");
}
