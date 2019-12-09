using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Contracts.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactStatus { get; set; }
    }
}
