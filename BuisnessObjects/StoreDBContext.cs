using Microsoft.EntityFrameworkCore;

namespace BusinessObjects
{
    public partial class StoreDBContext : DbContext
    {


        public virtual DbSet<Book> Books { get; private set; } = null!;
        public virtual DbSet<User> Users { get; private set; } = null!;
        public virtual DbSet<Role> Roles { get; private set; } = null!;

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {

                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Password)
                      .HasColumnType("character varying")
                      .HasColumnName("password");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employee_fk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Rolename)
                    .HasColumnType("character varying")
                    .HasColumnName("rolename");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
