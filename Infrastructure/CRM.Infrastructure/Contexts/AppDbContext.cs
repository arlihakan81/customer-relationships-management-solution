using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Contexts
{
    public class AppDbContext(IOrganizationService organizationService = null!) : DbContext
    {
        private readonly IOrganizationService _organizationService = organizationService;

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Lead> Leads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CRMDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasQueryFilter(c => c.OrganizationId == _organizationService.GetCurrentOrganizationId() && !c.IsDeleted);
            modelBuilder.Entity<Contact>().HasQueryFilter(c => c.OrganizationId == _organizationService.GetCurrentOrganizationId() && !c.IsDeleted);
            modelBuilder.Entity<Lead>().HasQueryFilter(c => c.OrganizationId == _organizationService.GetCurrentOrganizationId() && !c.IsDeleted);

            modelBuilder.Entity<Customer>().HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasOne(c => c.ModifiedBy).WithMany().HasForeignKey(c => c.ModifiedById);
            modelBuilder.Entity<Customer>().HasOne(c => c.DeletedBy).WithMany().HasForeignKey(c => c.DeletedById);

            modelBuilder.Entity<Contact>().HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Contact>().HasOne(c => c.ModifiedBy).WithMany().HasForeignKey(c => c.ModifiedById);
            modelBuilder.Entity<Contact>().HasOne(c => c.DeletedBy).WithMany().HasForeignKey(c => c.DeletedById);

            modelBuilder.Entity<Lead>().HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Lead>().HasOne(c => c.ModifiedBy).WithMany().HasForeignKey(c => c.ModifiedById);
            modelBuilder.Entity<Lead>().HasOne(c => c.DeletedBy).WithMany().HasForeignKey(c => c.DeletedById);
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity<Guid> && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity<Guid>)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = now;
                    if (!_organizationService.IsAuthenticated())
                        await base.SaveChangesAsync(cancellationToken); // Save changes to generate IDs for new entities
                    entity.OrganizationId = _organizationService.GetCurrentOrganizationId();
                    entity.CreatedById = _organizationService.GetAuthenticatedUserId();
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedAt = now;
                    if (!_organizationService.IsAuthenticated())
                        await base.SaveChangesAsync(cancellationToken); // Save changes to generate IDs for existing entities
                    entity.ModifiedById = _organizationService.GetAuthenticatedUserId();
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entity.DeletedAt = now;
                    if (!_organizationService.IsAuthenticated())
                        await base.SaveChangesAsync(cancellationToken); // Save changes to generate IDs for existing entities
                    entity.DeletedById = _organizationService.GetAuthenticatedUserId();
                }

            }

            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
