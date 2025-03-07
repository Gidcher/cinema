

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Data.Maps;

public class SessionMap
{
    public SessionMap(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey (t => t.Id);
        builder.HasOne(t => t.Movie).WithMany(t => t.Sessions);
        builder.HasOne(t => t.Hall).WithMany(t => t.Sessions);
        builder.Property(t => t.DateTime).IsRequired();
        builder.Property(t =>t.Format).IsRequired();
    }
}