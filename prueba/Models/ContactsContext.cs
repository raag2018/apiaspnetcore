using Microsoft.EntityFrameworkCore;
namespace prueba.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Contacts> ContactsSet { get; set; }
    }
}