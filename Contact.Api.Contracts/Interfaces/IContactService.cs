using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using  Api.Contracts.Models;

namespace Api.Contracts.Interfaces
{
    public interface IContactService
    {
        List<Contact> GetContacts ();

        void UpdateContact(Contact contact);

        void AddNewContact(Contact contact);

        void DeleteContact(int id);

        void DeactivateContact(int id);
        void ReactivateContact(int id);

    }
}
