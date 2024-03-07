using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStream.Domain.Entities;

namespace MovieStream.Domain.Configurations
{
    public class UserMarkedMoviesConfig : IEntityTypeConfiguration<UserMarkedMovie>
    {
        public void Configure(EntityTypeBuilder<UserMarkedMovie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MovieStreamUserId).IsRequired();
            builder.Property(x => x.MovieId).IsRequired();
        }
    }
}
