using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(x => x.UserId);
            entity.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Email).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Phone).HasMaxLength(20);
            entity.Property(x => x.RoleId).IsRequired();
            entity.Property(x => x.Username).IsRequired().HasMaxLength(50);
            entity.Property(x => x.Password).IsRequired().HasMaxLength(255);
            entity.Property(x => x.DateCreate).IsRequired();
            entity.Property(x => x.DateUpdate);
            entity.Property(x => x.DateDelete);

            entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(x => x.Email).IsUnique();
            entity.HasIndex(x => x.Username).IsUnique();
        }
    }
}