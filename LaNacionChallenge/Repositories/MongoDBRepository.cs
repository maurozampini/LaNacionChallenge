using MongoDB.Driver;

namespace LaNacionChallenge.Repositories
{
    public class MongoDBRepository
    {
        MongoClient client;
        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient($"mongodb+srv://{Environment.GetEnvironmentVariable("USER")}:{Environment.GetEnvironmentVariable("PASSWORD")}@cluster0.grrs5yu.mongodb.net/?retryWrites=true&w=majority");
            db = client.GetDatabase("LaNacionChallenge");
        }
    }
}
