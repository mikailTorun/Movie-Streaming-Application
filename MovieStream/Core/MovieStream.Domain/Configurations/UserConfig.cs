using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStream.Domain.Entities.Identity;

namespace MovieStream.Domain.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<MovieStreamUser>
    {
        public void Configure(EntityTypeBuilder<MovieStreamUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Ignore(x => x.Fullname);
        }
    }
}
