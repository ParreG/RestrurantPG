using Microsoft.EntityFrameworkCore;
using RestrurantPG.Models;

namespace RestrurantPG.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminInvite> AdminInvites { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminEntity = modelBuilder.Entity<Admin>();
            var adminInviteEntity = modelBuilder.Entity<AdminInvite>();
            var tableEntity = modelBuilder.Entity<Table>();
            var dishEntity = modelBuilder.Entity<Dish>();
            var orderItemEntity = modelBuilder.Entity<OrderItem>();
            var orderEntity = modelBuilder.Entity<Order>();
            var bookingEntity = modelBuilder.Entity<Booking>();


            // för Admin
            adminEntity
                .HasIndex(a => a.UserName)
                .IsUnique();

            adminEntity
                .HasIndex(a => a.Email)
                .IsUnique();

            adminEntity
                .Property(a => a.Role)
                .HasConversion<string>(); // sparar enum som string

            adminEntity
                .HasMany(a => a.CreatedInvites)
                .WithOne(aI => aI.CreatedByAdmin)
                .HasForeignKey(aI => aI.AdminId_Fk)
                .OnDelete(DeleteBehavior.Restrict);

            adminEntity
                .HasData(new Admin
                {
                    Admin_Id = 1,
                    UserName = "ParGit99",
                    Email = "Parman.gitijah@yahoo.com",
                    PasswordHash = "$2a$11$VA0.5ZyTnOGfuSBhoJjYyO0FBlZpE8T8d5GN0QORxl4vJSVBci1ke",
                    Role = AdminRole.SuperAdmin
                });

            // Admin Invite
            adminInviteEntity
                .HasIndex(aI => aI.InviteCode) 
                .IsUnique();


            // För table
            tableEntity
                .HasIndex(t => t.Number)
                .IsUnique();


            // för Dish
            dishEntity
                .Property(d => d.Price)
                .HasColumnType("decimal(10,2)");


            // För Order
            orderEntity
                .Property(o => o.TotalCost)
                .HasColumnType("decimal(10,2)");

            orderEntity
                .HasOne<Booking>()
                .WithMany()
                .HasForeignKey(o => o.BookingId_Fk)
                .OnDelete(DeleteBehavior.Restrict);

            // För OrderItem
            orderItemEntity
                .Property(oI => oI.ItemPrice)
                .HasColumnType("decimal(10,2)");

            orderItemEntity
                .HasOne<Order>()
                .WithMany()
                .HasForeignKey(oI => oI.OrderId_Fk)
                .OnDelete(DeleteBehavior.Restrict);

            orderItemEntity
                .HasOne<Dish>()
                .WithMany()
                .HasForeignKey(oI => oI.DishId_Fk)
                .OnDelete(DeleteBehavior.Restrict);

            // För bokningar 
            bookingEntity
                .HasOne(b => b.Guest)   
                .WithMany()
                .HasForeignKey(b => b.GuestId_Fk)
                .OnDelete(DeleteBehavior.Restrict);

            bookingEntity
                .HasOne(b => b.Table)    
                .WithMany()
                .HasForeignKey(b => b.TableId_Fk)
                .OnDelete(DeleteBehavior.Restrict);

            bookingEntity
                .HasIndex(b => new {b.TableId_Fk, b.BookingStart});
        }
    }
}
