using App.Domain.Base;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Contexts
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {
            
        }

        public DbSet<Person> People { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Bütün dəyişikliklərin izlənildiyi entity-ləri əldə edir
            var entities = ChangeTracker.Entries<BaseEntity>();

            // Hər bir entity-i yoxlayır
            foreach (var entity in entities)
            {
                // Entity əlavə edildikdə (yeni yaradıldıqda)
                if (entity.State == EntityState.Added)
                {
                    // Yaradılma tarixini təyin edir
                    entity.Entity.CreatedDate = DateTime.UtcNow.AddHours(4);
                }
                // Entity dəyişdirildikdə
                else if (entity.State == EntityState.Modified)
                {
                    // Sonuncu dəyişiklik tarixini təyin edir
                    entity.Entity.LastModifiedDate = DateTime.UtcNow.AddHours(4);
                }
            }

            // Bütün dəyişiklikləri verilənlər bazasına tətbiq edir
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
