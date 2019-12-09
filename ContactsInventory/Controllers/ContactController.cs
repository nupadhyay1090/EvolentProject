using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Contracts.Models;
using Api.Contracts.Interfaces;
namespace ContactsInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;
        public ContactController(IContactService service)
        {
            this._service = service;
        }
        // GET: api/Contact
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result =  _service.GetContacts();
            return Ok(result);
        }

        // POST: api/Contact
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Contact contact)
        {
            _service.AddNewContact(contact);
            return Ok();
        }

        // PUT: api/Contact/5
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Contact contact)
        {
            _service.UpdateContact(contact);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteContact(id);
            return Ok();
        }

        [HttpGet("Deactivate/{id}")]
        public IActionResult Deactivate(int id)
        {
            _service.DeactivateContact(id);
            return Ok();
        }

        [HttpGet("Reactivate/{id}")]
        public IActionResult Reactivate(int id)
        {
            _service.ReactivateContact(id);
            return Ok();
        }
    }
}
