using FIT.Data;
using FIT.Data.IspitIB210181;
using Microsoft.EntityFrameworkCore;

using System.Configuration;

namespace FIT.Infrastructure
{
    public class DLWMSDbContext : DbContext
    {
        private readonly string dbPutanja;

        public DLWMSDbContext()
        {
            dbPutanja = ConfigurationManager.
                ConnectionStrings["DLWMSBaza"].ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(dbPutanja);
        }
    
        public DbSet<Student> Studenti { get; set; }
        public DbSet<SemestriIB210181> Semestri { get; set; }
        public DbSet<PredmetiIB210181> Predmeti { get; set; }
        public DbSet<PolozeniPredmetiIB210181> PolozeniPredmeti { get; set; }
        public DbSet<DrzaveIB210181> DrzaveIB210181 { get; set; }
        public DbSet<GradoviIB210181> GradoviIB210181{ get; set; }

    }
}