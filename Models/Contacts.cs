using ContactsApi.AuditableModel;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Models;

public class Contact : BaseFullEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}