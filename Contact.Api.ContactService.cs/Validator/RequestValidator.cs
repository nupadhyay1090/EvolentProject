using System;
using System.Collections.Generic;
using System.Text;
using Api.Contracts.Models;
using Api.Contracts.Error;
using System.Text.RegularExpressions;

namespace Api.ContactService.Validator
{
    public static class RequestValidator
    {
        public static void ValidateRequest(Contact contact)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = emailRegex.Match(contact.EmailID);

            if (!match.Success)
                throw ClientErrors.InvalidEmailId();

            if (contact.FirstName.Length > 50)
                throw ClientErrors.InvalidFirstName();

            if (contact.LastName.Length > 50)
                throw ClientErrors.InvalidLastName();
        }
    }
}
