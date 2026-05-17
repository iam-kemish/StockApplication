using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StockApplicationApi.Models.RefreshTokens
{
    internal sealed class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
           
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Token).HasMaxLength(200)
                   .IsRequired();

            builder.HasIndex(x => x.Token)
                   .IsUnique();


            builder.HasOne(x => x.AppUser)
                   .WithMany()
                   .HasForeignKey(x => x.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        } 
        

            }
            
        }
    
