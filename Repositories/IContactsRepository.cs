using ContactsApi.Models;

namespace ContactsApi.Repositories;

public interface IContactsRepository
{
    Task<Contact> CreateContactAsync(Contact contact);
    Task<List<Contact>> GetAllContactsAsync();
    Task<Contact?> GetByIdAsync(int id);
    Task SoftDeleteAsync(Contact contact);
}