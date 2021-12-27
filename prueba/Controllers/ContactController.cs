using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using prueba.Models;
namespace prueba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : Controller
    {

        private ContactsContext contactsContext;
        public ContactController(ContactsContext context)
        {
            contactsContext = context;
        }
        [HttpGet]
        public IEnumerable<Contacts> Get()
        {
            return contactsContext.ContactsSet.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Contacts> Get(int id) {
            var selectedContact = (from c in contactsContext.ContactsSet
                                  where c.Identificator == id
                                  select c).FirstOrDefault();
            return selectedContact;
                }
        [HttpPost]
        public IActionResult Post([FromBody] Contacts value) {
            Contacts newContact = value;
            contactsContext.ContactsSet.Add(newContact);
            contactsContext.SaveChanges();
            return Ok();
        }
        /*
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contacts value)
        {
            Contacts updatedContact = value;
            var selectedElement = contactsContext.ContactsSet.Find(updatedContact.Identificator);
            selectedElement.Nombre = value.Nombre;
            selectedElement.Email = value.Email;
            contactsContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var selectedElement = contactsContext.ContactsSet.Find(id);
            contactsContext.ContactsSet.Remove(selectedElement);
            contactsContext.SaveChanges();
        }*/
        ~ContactController()
        {
            contactsContext.Dispose();
        }
    }
}