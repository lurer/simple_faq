using s198599_mappe3.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace s198599_mappe3.Models
{
    public class DataContext : DbContext
    {

        public DataContext() : base("DataContext")
        {
            //Database.CreateIfNotExists();
            Database.SetInitializer<DataContext>(new FaqSeedInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }


        public DbSet<DbQuestion> Questions { get; set; }
        public DbSet<DbCategory> Category { get; set; }


        public override int SaveChanges()
        {
            var addedAuditedEntities = ChangeTracker.Entries<IAuditedEntity>()
                .Where(p => p.State == EntityState.Added)
                .Select(p => p.Entity);

            var modifiedAuditedEntities = ChangeTracker.Entries<IAuditedEntity>()
              .Where(p => p.State == EntityState.Modified)
              .Select(p => p.Entity);

            var now = DateTime.UtcNow;

            foreach (var added in addedAuditedEntities)
            {
                added.CreatedAt = now;
                added.LastModifiedAt = now;

            }

            foreach (var modified in modifiedAuditedEntities)
            {
                modified.LastModifiedAt = now;

            }
            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {

                //e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
            }
            return 0;
        }

    }




}