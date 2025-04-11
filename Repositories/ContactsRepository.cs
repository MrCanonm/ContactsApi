using ContactsApi.Data;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Repositories;
public class ContactsRepository : IContactsRepository
{
    private readonly AppDbContext _context;

    public ContactsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Contact> CreateContactAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<List<Contact>> GetAllContactsAsync()
    {
        return await _context.Contacts
        .Where(c => c.Status)
        .ToListAsync();
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        return await _context.Contacts.FirstOrDefaultAsync(c => c.Status && c.Id == id);
    }

    public async Task SoftDeleteAsync(Contact contact)
    {
        contact.Status = false;
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
    }
}