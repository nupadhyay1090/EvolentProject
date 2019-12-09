using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Contracts.Interfaces;
using Api.Contracts.Models;
using System.Linq;
namespace Api.DAL
{
    public class DAL : IDAL
    {
        private readonly ContactContext _contactContext;
        public DAL(ContactContext context)
        {
            this._contactContext = context;

        }
        public void AddNewContact(Contact contact)
        {
            _contactContext.Add(contact);
            this._contactContext.SaveChanges();
        }

        public void DeactivateContact(int id)
        {
            var contact =  _contactContext.Contacts.Find(id);
            contact.ContactStatus = "Inactive";
            _contactContext.Update(contact);
            _contactContext.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var contact = _contactContext.Contacts.Where(c => c.ID == id).First();
            _contactContext.Remove(contact);
            _contactContext.SaveChanges();
        }

        public List<Contact> GetContacts()
        {
            return _contactContext.Contacts.ToList();
        }

        public void ReactivateContact(int id)
        {
            _contactContext.Contacts.FindAsync(id).Result.ContactStatus = "Active";
            _contactContext.SaveChanges();

        }

        public void UpdateContact(Contact contact)
        {
            _contactContext.Update(contact);
            _contactContext.SaveChanges();
        }
    }
}
