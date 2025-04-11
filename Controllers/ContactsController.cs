using ContactsApi.DTOs;
using ContactsApi.Models;
using ContactsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers;
[ApiController]
[Route("contacts/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactsService _service;

    public ContactsController(IContactsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Contact>>> GetAllContactsAsync()
    {
        try
        {
            var contacts = await _service.GetAllContactsAsync();
            return Ok(contacts);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetByIdAsync(int id)
    {
        try
        {
            var contacts = await _service.GetByIdAsync(id);
            return Ok(contacts);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Contact>> CreateContact([FromBody] CreateContactsDto dto)
    {
        var newContact = await _service.CreateContactAsync(dto);
        return CreatedAtAction(nameof(CreateContact), new { id = newContact.Id }, newContact);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var deleted = await _service.RemoveContactAsync(id);
            return Ok(deleted);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}