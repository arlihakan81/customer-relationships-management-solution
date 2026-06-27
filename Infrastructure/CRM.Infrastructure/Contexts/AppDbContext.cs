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
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<LeadLabel> LeadLabels { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Pipeline> Pipelines { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealLineItem> DealLineItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CRMDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasQueryFilter(c => c.OrganizationId == _organizationService.GetCurrentOrganizationId() && !c.IsDeleted);
            modelBuilder.Entity<Contact>().HasQueryFilter(c => c.OrganizationId == _organizationService.GetCurrentOrganizationId() && !c.IsDeleted);
            modelBuilder.Entity<Lead>().HasQueryFilter(l => l.OrganizationId == _organizationService.GetCurrentOrganizationId() && !l.IsDeleted);
            modelBuilder.Entity<Source>().HasQueryFilter(ls => ls.OrganizationId == _organizationService.GetCurrentOrganizationId() && !ls.IsDeleted);
            modelBuilder.Entity<LeadLabel>().HasQueryFilter(ll => ll.OrganizationId == _organizationService.GetCurrentOrganizationId() && !ll.IsDeleted);
            modelBuilder.Entity<Label>().HasQueryFilter(l => l.OrganizationId == _organizationService.GetCurrentOrganizationId() && !l.IsDeleted); 
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.OrganizationId == _organizationService.GetCurrentOrganizationId() && !p.IsDeleted); 
            modelBuilder.Entity<Pipeline>().HasQueryFilter(p => p.OrganizationId == _organizationService.GetCurrentOrganizationId() && !p.IsDeleted); 
            modelBuilder.Entity<Stage>().HasQueryFilter(s => s.OrganizationId == _organizationService.GetCurrentOrganizationId() && !s.IsDeleted); 
            modelBuilder.Entity<Deal>().HasQueryFilter(d => d.OrganizationId == _organizationService.GetCurrentOrganizationId() && !d.IsDeleted); 
            modelBuilder.Entity<DealLineItem>().HasQueryFilter(di => di.OrganizationId == _organizationService.GetCurrentOrganizationId() && !di.IsDeleted); 

            modelBuilder.Entity<Company>().HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Company>().HasOne(c => c.ModifiedBy).WithMany().HasForeignKey(c => c.ModifiedById);
            modelBuilder.Entity<Company>().HasOne(c => c.DeletedBy).WithMany().HasForeignKey(c => c.DeletedById);
            modelBuilder.Entity<Company>().HasOne(c => c.Owner).WithMany(u => u.Companies).HasForeignKey(c => c.OwnerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>().HasOne(c => c.CreatedBy).WithMany().HasForeignKey(c => c.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Contact>().HasOne(c => c.ModifiedBy).WithMany().HasForeignKey(c => c.ModifiedById);
            modelBuilder.Entity<Contact>().HasOne(c => c.DeletedBy).WithMany().HasForeignKey(c => c.DeletedById);
            modelBuilder.Entity<Contact>().HasOne(c => c.Owner).WithMany(u => u.Contacts).HasForeignKey(c => c.OwnerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lead>().HasOne(l => l.CreatedBy).WithMany().HasForeignKey(l => l.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Lead>().HasOne(l => l.ModifiedBy).WithMany().HasForeignKey(l => l.ModifiedById);
            modelBuilder.Entity<Lead>().HasOne(l => l.DeletedBy).WithMany().HasForeignKey(l => l.DeletedById);

            modelBuilder.Entity<Source>().HasOne(ls => ls.CreatedBy).WithMany().HasForeignKey(ls => ls.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Source>().HasOne(ls => ls.ModifiedBy).WithMany().HasForeignKey(ls => ls.ModifiedById);
            modelBuilder.Entity<Source>().HasOne(ls => ls.DeletedBy).WithMany().HasForeignKey(ls => ls.DeletedById);

            modelBuilder.Entity<LeadLabel>().HasOne(ll => ll.CreatedBy).WithMany().HasForeignKey(ll => ll.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LeadLabel>().HasOne(ll => ll.ModifiedBy).WithMany().HasForeignKey(ll => ll.ModifiedById);
            modelBuilder.Entity<LeadLabel>().HasOne(ll => ll.DeletedBy).WithMany().HasForeignKey(ll => ll.DeletedById);

            modelBuilder.Entity<Label>().HasOne(l => l.CreatedBy).WithMany().HasForeignKey(l => l.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Label>().HasOne(l => l.ModifiedBy).WithMany().HasForeignKey(l => l.ModifiedById);
            modelBuilder.Entity<Label>().HasOne(l => l.DeletedBy).WithMany().HasForeignKey(l => l.DeletedById);            
            modelBuilder.Entity<Label>().HasMany(l => l.Leads).WithMany(l => l.Labels).UsingEntity<LeadLabel>();

            modelBuilder.Entity<Product>().HasOne(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasOne(p => p.ModifiedBy).WithMany().HasForeignKey(p => p.ModifiedById);
            modelBuilder.Entity<Product>().HasOne(p => p.DeletedBy).WithMany().HasForeignKey(p => p.DeletedById);

            modelBuilder.Entity<Pipeline>().HasOne(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Pipeline>().HasOne(p => p.ModifiedBy).WithMany().HasForeignKey(p => p.ModifiedById);
            modelBuilder.Entity<Pipeline>().HasOne(p => p.DeletedBy).WithMany().HasForeignKey(p => p.DeletedById);

            modelBuilder.Entity<Deal>().HasOne(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Deal>().HasOne(p => p.ModifiedBy).WithMany().HasForeignKey(p => p.ModifiedById);
            modelBuilder.Entity<Deal>().HasOne(p => p.DeletedBy).WithMany().HasForeignKey(p => p.DeletedById);

            modelBuilder.Entity<Stage>().HasOne(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Stage>().HasOne(p => p.ModifiedBy).WithMany().HasForeignKey(p => p.ModifiedById);
            modelBuilder.Entity<Stage>().HasOne(p => p.DeletedBy).WithMany().HasForeignKey(p => p.DeletedById);

            modelBuilder.Entity<DealLineItem>().HasOne(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DealLineItem>().HasOne(p => p.ModifiedBy).WithMany().HasForeignKey(p => p.ModifiedById);
            modelBuilder.Entity<DealLineItem>().HasOne(p => p.DeletedBy).WithMany().HasForeignKey(p => p.DeletedById);

            modelBuilder.Entity<Role>().HasData([
                new Role {
                    Id = 1,
                    Name = "Super Admin"
                },
                new Role {
                    Id = 2,
                    Name = "Admin"
                },
                new Role {
                    Id = 3,
                    Name = "User"
                }
                ]);
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity<Guid> && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity<Guid>)entry.Entity;
                var now = DateTime.Now;

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
