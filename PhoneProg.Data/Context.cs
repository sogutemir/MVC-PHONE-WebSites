using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using PhoneProg.Data.Migrations;
using PhoneProg.Data.Models;

namespace PhoneProg.Data
{
    public class Context:DbContext
    {

        public Context() : base("Context")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>("Context"));

        }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Telefonlar> Telefonlar { get; set; }

        public DbSet<Uyeler> Uyeler { get; set; }

        public DbSet<Dukkanlar> Dukkanlar { get; set; }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefonlar>()
                .HasMany(t => t.Kategoriler)
                .WithMany(k => k.Telefonlar)
                .Map(m =>
                {
                    m.ToTable("TelefonlarKategoriler");
                    m.MapLeftKey("TelefonlarId");
                    m.MapRightKey("KategoriId");
                });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }





    }
}
