namespace ContactsApi.DTOs;
public class CreateContactsDto
{
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }

}