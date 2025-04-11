using ContactsApi.DTOs;
using ContactsApi.Models;

namespace ContactsApi.Services;

public interface IContactsService
{
    Task<Contact> CreateContactAsync(CreateContactsDto dto);
    Task<List<Contact>> GetAllContactsAsync();
    Task<Contact?> GetByIdAsync(int id);
    Task<Contact> RemoveContactAsync(int id);
}
