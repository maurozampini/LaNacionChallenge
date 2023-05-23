using LaNacionChallenge.Models;

namespace LaNacionChallenge.Repositories
{
    public interface IContactsCollection
    {
        Task InsertContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(string id);
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContactById(string id);
        Task<Contact> GetContactByEmailOrPhone(string emailOrPhone);
        Task<List<Contact>> GetContactByStateOrCity(string address);
    }
}
