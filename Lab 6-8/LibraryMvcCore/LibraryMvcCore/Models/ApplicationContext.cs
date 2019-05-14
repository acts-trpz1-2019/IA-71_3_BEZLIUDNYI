using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<TextBook> TextBooks { get; set; }
        public DbSet<AudioBook> AudioBooks { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<TitledInfo> TitledInfoSet { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BookGenre>()
                .HasKey(bc => new { bc.BookId, bc.GenreId });
            builder.Entity<BookGenre>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bc => bc.BookId);
            builder.Entity<BookGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.BookGenres)
                .HasForeignKey(bc => bc.GenreId);

            builder.Entity<TitledInfo>()
                .HasOne(t => t.Description)
                .WithMany(d => d.TitledInfoList);

            builder.Entity<SubscriptionType>().HasIndex(s => s.Name).IsUnique();
            builder.Entity<Genre>().HasIndex(g => g.Name).IsUnique();
            builder.Entity<Description>().HasIndex(g => g.TargetName).IsUnique();
            builder.Entity<TitledInfo>().Property(t => t.ContentBlocks).HasConversion(
                    v => string.Join('|', v),
                    v => v.Split('|', StringSplitOptions.RemoveEmptyEntries)).HasColumnName("ContentBlocks");
        }
    }
}
