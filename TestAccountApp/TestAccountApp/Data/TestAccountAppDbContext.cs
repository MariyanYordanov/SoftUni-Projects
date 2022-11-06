using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestAccountApp.Data.Entities;

namespace TestAccountApp.Data
{
    public class TestAccountAppDbContext : IdentityDbContext<MyUser>
    {
        public TestAccountAppDbContext(DbContextOptions<TestAccountAppDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        private MyUser GuestUser { get; set; } = null!;

        private Board OpenBoard { get; set; } = null!;

        private Board InProgressBoard { get; set; } = null!;

        private Board DoneBoard { get; set; } = null!;


        public DbSet<Board> Boards { get; set; } = null!;

        public DbSet<MyTask> Tasks { get; set; } = null!;

        public DbSet<MyUser> MyUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MyTask>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(k => k.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder.Entity<MyUser>().HasData(this.GuestUser);

            SeedBoards();
            builder.Entity<Board>().HasData(this.OpenBoard, this.InProgressBoard, this.DoneBoard);

            builder.Entity<MyTask>()
                .HasData(new MyTask()
                {
                    Id = 1,
                    Title = "Prepare for ASP.NET Core Fundamentals Exam",
                    Description = "Learn ASP.NET Core Identity",
                    CreatedOn = DateTime.UtcNow.AddMonths(-1),
                    BoardId = this.OpenBoard.Id,
                    OwnerId = this.GuestUser.Id
                },
                new MyTask()
                {
                    Id = 2,
                    Title = "Improve EF Core skills",
                    Description = "Learn using EF Core and MS SQL Server Managment Studio",
                    CreatedOn = DateTime.UtcNow.AddMonths(-5),
                    BoardId = this.OpenBoard.Id,
                    OwnerId = this.GuestUser.Id
                },
                new MyTask()
                {
                    Id = 3,
                    Title = "Improve ASP.NET Core skills",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.UtcNow.AddDays(-10),
                    BoardId = OpenBoard.Id,
                    OwnerId = GuestUser.Id
                },
                new MyTask()
                {
                    Id = 4,
                    Title = "Prepare for C# Fundamentals Exam",
                    Description = "Prepare by solving old Mid and Final Exams",
                    CreatedOn = DateTime.UtcNow.AddMonths(-5),
                    BoardId = this.OpenBoard.Id,
                    OwnerId = this.GuestUser.Id
                });

            base.OnModelCreating(builder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            GuestUser = new MyUser()
            {
                UserName = "GuestName",
                NormalizedUserName = "GUESTNAME",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Fname",
                LastName = "Lname"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "password");
        }

        private void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }
    }
}