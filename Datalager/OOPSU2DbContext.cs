using Microsoft.EntityFrameworkCore;
using OOSU2_VT26_Grupp_07.Entiteter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOSU2_VT26_Grupp_07.Datalager
{
    public class OOPSU2DbContext : DbContext
    {
        public DbSet<Medlem> Medlemmar { get; set; }
        public DbSet<Bokning> Bokningar { get; set; }
        public DbSet<Personal> Personaler { get; set; }
        public DbSet<Resurs> Resurser { get; set; }
        public DbSet<Utrustning> Utrustningar { get; set; }
        public DbSet<Betalning> Betalningar { get; set; }

        // 👇 Enda konstruktorn
        public OOPSU2DbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=sqlutb4-db.hb.se,56077;" +
                "Database=oosu2607;" +
                "User Id=oosu2607;" +
                "Password=JGK356;" +
                "TrustServerCertificate=True;"
            );
        }

        // Förhindrar dubbelbokning av samma resurs/utrustning
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bokning>()
                .HasIndex(b => new { b.ResursID, b.Datum, b.Starttid, b.Sluttid })
                .IsUnique();            
            
            //base.OnModelCreating(modelBuilder);


        }
    }
}
