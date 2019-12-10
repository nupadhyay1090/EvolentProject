using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Contracts.Interfaces;
using Api.Contracts.Models;
using System.Linq;
using Api.Contracts.Error;
namespace Api.DAL
{
    public class DAL : IDAL
    {
        private readonly ContactContext _contactContext;
        private readonly bool _isMockEnable;

        public DAL(ContactContext context,bool isMockEnable=false)
        {
            this._contactContext = context;
            this._isMockEnable = isMockEnable;

        }
        public void AddNewContact(Contact contact)
        {
            _contactContext.Add(contact);
            this._contactContext.SaveChanges();
        }

        public void DeactivateContact(int id)
        {
            if (IsIDValid(id))
            {
                var contact = _contactContext.Contacts.Find(id);

                contact.ContactStatus = "Inactive";
                _contactContext.Update(contact);
                _contactContext.SaveChanges();
            }
        }

        public void DeleteContact(int id)
        {
            if (IsIDValid(id))
            {
                var contact = _contactContext.Contacts.Where(c => c.ID == id).First();
                _contactContext.Remove(contact);
                _contactContext.SaveChanges();
            }
        }

        public List<Contact> GetContacts()
        {
            if (_isMockEnable)
                return GetMockContacts();
            return _contactContext.Contacts.ToList();
        }

        public void ReactivateContact(int id)
        {
            if (IsIDValid(id))
            {
                _contactContext.Contacts.FindAsync(id).Result.ContactStatus = "Active";
                _contactContext.SaveChanges();
            }
        }

        public void UpdateContact(Contact contact)
        {
            _contactContext.Update(contact);
            _contactContext.SaveChanges();
        }

        #region private helper methods
        private List<Contact> GetMockContacts()
        {
            var listOfMockContacts = new List<Contact>();
            var mockContact1 = new Contact() { ID = 1, FirstName = "Nishnat", LastName = "Upadhyay", PhoneNumber = "123-321", EmailID = "nupadhyay@gmail.com", ContactStatus = Constants.Active };
            var mockContact2 = new Contact() { ID = 2, FirstName = "Nilabh", LastName = "Chaturvedi", PhoneNumber = "123-321", EmailID = "nchaturvedi@gmail.com", ContactStatus = Constants.Active };
            listOfMockContacts.Add(mockContact1);
            listOfMockContacts.Add(mockContact2);
            return listOfMockContacts;
        }

        private bool IsIDValid(int id)
        {
            if (!_contactContext.Contacts.Any(c => c.ID == id))
                throw ClientErrors.InvalidId();
            else
                return true;
        }
        #endregion

    }
}
