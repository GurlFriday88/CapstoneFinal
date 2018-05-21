using CapstoneData.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneData
{
    public class CapstoneContext : DbContext 
    {
        public CapstoneContext(DbContextOptions options) : base(options) { }

        public DbSet<Prefix> Prefixes { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderNote> ProviderNotes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MemoOption> MemoOptions { get; set; }
       


    }
}
