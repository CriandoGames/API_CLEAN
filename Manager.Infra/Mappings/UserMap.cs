using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Manager.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .IsRequired()                                       
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("name")
                   .HasColumnType("varchar(50)");

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(180)
                   .HasColumnName("email")
                   .HasColumnType("varchar(180)");

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(120)
                   .HasColumnName("password")
                   .HasColumnType("varchar(120)");


        }
    }
}
