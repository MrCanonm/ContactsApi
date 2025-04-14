namespace ContactsApi.DTOs;
public class CreateContactsDto
{
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public string? SecondPhoneNumber { get; set; }
}