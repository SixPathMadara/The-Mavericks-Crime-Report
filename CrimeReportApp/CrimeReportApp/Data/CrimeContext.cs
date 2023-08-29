using Microsoft.EntityFrameworkCore;

namespace CrimeReportApp.Data
{
    //DatabaseContext probably should refactor it to database context.
    public class CrimeContext : DbContext
    {
        
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CrimeEntity> CrimeReports { get; set; }
    public DbSet<TypeEntity> CrimeTypes { get; set; }
    public DbSet<AttachmentEntity> Attachments { get; set;  }
    public DbSet<NotificationEntity> Notifications { get; set; }
    public DbSet<UserNotificationEntity> UserNotifications { get; set; }
    public CrimeContext(DbContextOptions<CrimeContext> options) : base(options)
    {
    }

    // Additional configuration and relationships

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            // Configure relationships, constraints, and additional configurations here
            //relationships
         modelBuilder.Entity<UserEntity>()
         .HasMany(u => u.Crimes)
         .WithOne(c => c.User)
         .HasForeignKey(c => c.UserID);

         modelBuilder.Entity<CrimeEntity>()
                .HasOne(c => c.User)
                .WithMany(u => u.Crimes)
                .HasForeignKey(c => c.UserID);

         modelBuilder.Entity<CrimeEntity>()
                .HasOne(c => c.crimeType)
                .WithMany(t => t.Crimes)
                .HasForeignKey(c => c.TypeID);

         modelBuilder.Entity<TypeEntity>()
                .HasMany(t => t.Crimes)
                .WithOne(c => c.crimeType)
                .HasForeignKey(c => c.TypeID);
        modelBuilder.Entity<AttachmentEntity>()
           .HasOne(a => a.Crime)
           .WithMany(c => c.Attachments)
           .HasForeignKey(a => a.ReportID);
        
        modelBuilder.Entity<NotificationEntity>()
            .HasMany(n => n.UserNotifications)
            .WithOne(un => un.Notification)
            .HasForeignKey(un => un.NotificationID);
         //Primary keys
         modelBuilder.Entity<UserEntity>().HasKey(u => u.UserID);
         modelBuilder.Entity<CrimeEntity>().HasKey(c => c.ReportID);
         modelBuilder.Entity<TypeEntity>().HasKey(ct => ct.TypeID);
         modelBuilder.Entity<AttachmentEntity>().HasKey(a => a.AttachmentID);
         modelBuilder.Entity<NotificationEntity>().HasKey(n => n.NotificationID);
         modelBuilder.Entity<UserNotificationEntity>().HasKey(un => un.UserNotificationID);
        }

    }
}
