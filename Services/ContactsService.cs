using ContactsApi.DTOs;
using ContactsApi.Models;
using ContactsApi.Repositories;

namespace ContactsApi.Services;
public class ContactsService : IContactsService
{
    private readonly IContactsRepository _repo;
    public ContactsService(IContactsRepository repo)
    {
        _repo = repo;
    }

    public async Task<Contact> CreateContactAsync(CreateContactsDto dto)
    {
        var now = DateTime.UtcNow;
        var loggedUser = "System";

        var contact = new Contact
        {
            Name = dto.Name,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            SecondPhoneNumber = dto.SecondPhoneNumber,
            Status = true,
            CreateAt = now,
            UpdatedAt = now,
            CreatedBy = loggedUser,
            UpdateBy = loggedUser

        };

        return await _repo.CreateContactAsync(contact);
    }

    public async Task<List<Contact>> GetAllContactsAsync()
    {
        var contacts = await _repo.GetAllContactsAsync();

        if (contacts == null || !contacts.Any())
            throw new Exception("There is not a contacts registers");

        return contacts;
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id) ?? throw new Exception("Contact Not Found");
    }

    public async Task<Contact> RemoveContactAsync(int id)
    {
        var existingContact = await _repo.GetByIdAsync(id) ?? throw new Exception("Contact Not Found");
        await _repo.SoftDeleteAsync(existingContact);
        return existingContact;
    }
}