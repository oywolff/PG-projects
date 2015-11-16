using System.Data.Entity;

namespace Kampanjer.Models
{
    public class KampanjeContext : DbContext 
    {
        public KampanjeContext() : base("Kampanje_db")
        {
        }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<ItemKeyword> ItemKeywords { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
    }
}