using System;
using System.Collections.Generic;
using System.Text;
using Api.Contracts.Models;
using Api.Contracts.Error;
namespace Api.ContactService.Validator
{
    public static class RequestValidator
    {
        public static void ValidateRequest(Contact contact)
        {
            if (contact.EmailID.Length > 3)
                throw ClientErrors.InvalidEmailId();

            if( contact.FirstName.Length > 49)
                throw ClientErrors.
        }
    }
}
