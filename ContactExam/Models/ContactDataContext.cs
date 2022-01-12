using Microsoft.EntityFrameworkCore;

namespace ContactExam.Models
{
    public class ContactDataContext : DbContext
    {
        public ContactDataContext(DbContextOptions<ContactDataContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
