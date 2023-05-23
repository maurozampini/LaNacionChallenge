using LaNacionChallenge.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LaNacionChallenge.Repositories
{
    public class ContactsCollection : IContactsCollection
    {
        internal MongoDBRepository _repository = new();
        private IMongoCollection<Contact> Collection;

        public ContactsCollection()
        {
            Collection = _repository.db.GetCollection<Contact>("Contacts");
        }

        public async Task DeleteContact(string id)
        {
            var filter = Builders<Contact>.Filter.Eq(p => p.Id, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Contact> GetContactByEmailOrPhone(string emailOrPhone)
        {
            return await Collection.FindAsync(x => x.PersonalPhoneNumber == emailOrPhone || x.Email == emailOrPhone).Result.FirstAsync();
        }

        public async Task<List<Contact>> GetContactByStateOrCity(string address)
        {
            return await Collection.FindAsync(x => x.Address.ToUpper().Contains(address)).Result.ToListAsync();
        }

        public async Task<Contact> GetContactById(string id)
        {
            Contact asd = await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
            return asd;
        }

        public async Task InsertContact(Contact contact)
        {
            await Collection.InsertOneAsync(contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            var filter = Builders<Contact>.Filter.Eq(p => p.Id, contact.Id);
            await Collection.ReplaceOneAsync(filter, contact);
        }
    }
}
