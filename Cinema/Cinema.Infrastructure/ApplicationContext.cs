using Cinema.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Infrastructure;

public class ApplicationContext : DbContext
{
    public DbSet<Movie> Movies { get; private set; }
    public DbSet<Hall> Halls { get; private set; }
    public DbSet<Seat> Seats { get; private set; }
    public DbSet<Session> Sessions { get; private set; }
    public DbSet<Ticket> Tickets { get; private set; }
    public DbSet<User> Users { get; private set; }
    
    /*
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
    {
            
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    */
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;" +
                                 "Port=5432;" +
                                 "Database=cinema;" +
                                 "Username=postgres;" +
                                 "Password=1");
        /*var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        optionsBuilder.UseNpgsql(connectionString);*/
       
        /*optionsBuilder.UseNpgsql(_config.GetSection("DatabaseConfig")["pg_db"]);*/
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}