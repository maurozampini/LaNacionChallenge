using LaNacionChallenge.Helpers;
using LaNacionChallenge.Models;
using LaNacionChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LaNacionChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactsCollection _contactCollection;

        public ContactsController(IContactsCollection contactCollection)
        {
            _contactCollection = contactCollection;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            return Ok(await _contactCollection.GetAllContacts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("Id", "El Id no puede estar vacío");
            }

            return Ok(await _contactCollection.GetContactById(id));
        }

        [HttpGet()]
        [Route("search")]
        public async Task<IActionResult> GetContactByEmailOrPhone(string emailOrPhone)
        {
            if (string.IsNullOrEmpty(emailOrPhone))
            {
                ModelState.AddModelError("emailOrPhone", "El campo no puede estar vacío");
            }

            return Ok(await _contactCollection.GetContactByEmailOrPhone(emailOrPhone));
        }

        [HttpGet]
        [Route("address/{address}")]
        public async Task<IActionResult> GetContactByStateOrCity(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                ModelState.AddModelError("Address", "La dirección no puede estar vacía");
            }

            return Ok(await _contactCollection.GetContactByStateOrCity(address.ToUpper()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            ValidationsHelper.ValidateModel(ModelState, contact);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactCollection.InsertContact(contact);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] Contact contact, string id)
        {
            if (contact == null)
            {
                return BadRequest();
            }

            ValidationsHelper.ValidateModel(ModelState, contact);

            contact.Id = id;
            await _contactCollection.UpdateContact(contact);
            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactCollection.DeleteContact(id);
            return NoContent();
        }
    }
}
