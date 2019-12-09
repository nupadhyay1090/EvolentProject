using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Api.Contracts.Models;
namespace Api.DAL
{
    public class ContactContext : DbContext 
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
