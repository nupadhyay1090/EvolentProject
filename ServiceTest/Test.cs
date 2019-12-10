using System;
using System.Collections.Generic;
using System.Text;
using Api.ContactService;
using Xunit;
using Api.DAL;
using Microsoft.EntityFrameworkCore;
namespace ServiceTest
{
    public class Test
    {
        [Fact]
        public void GetContacts_Success()
        {
            ContactService service = new ContactService(new DAL(new ContactContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ContactContext>())));
            var mockDbContextOptions = new DbContextOptions<ContactContext>();
            var mockContactContext = new ContactContext(mockDbContextOptions);
            var mockDAL = new DAL(mockContactContext,true);
            var mockContactService = new ContactService(mockDAL);

            var mockContacts = mockContactService.GetContacts();
            Assert.True(mockContacts.Count > 0);
        }
    
    }
}
