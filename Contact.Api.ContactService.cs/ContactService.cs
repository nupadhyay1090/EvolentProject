using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Contracts.Interfaces;
using Api.Contracts.Models;

namespace Api.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IDAL _dataLayer;

        public ContactService(IDAL dataLayer)
        {
            this._dataLayer = dataLayer;
        }

        public List<Contact> GetContacts()
        {
            return _dataLayer.GetContacts();
        }

        public void AddNewContact(Contact contact)
        {
            _dataLayer.AddNewContact(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _dataLayer.UpdateContact(contact);
        }
        public void DeactivateContact(int id)
        {
            _dataLayer.DeactivateContact(id);
        }

        public void ReactivateContact(int id)
        {
            _dataLayer.ReactivateContact(id);
        }
        
        public void DeleteContact(int id)
        {
            _dataLayer.DeleteContact(id);
        }
    }
}
