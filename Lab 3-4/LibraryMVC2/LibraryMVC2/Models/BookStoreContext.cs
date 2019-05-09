using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Models
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<TextBook> TextBooks { get; set; }
        public DbSet<AudioBook> AudioBooks { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<TitledInfo> TitledInfoSet { get; set; }
        public DbSet<Description> Descriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasMany(g => g.Books)
                .WithMany(b => b.Genres)
                .Map(t => t.MapLeftKey("GenreId")
                .MapRightKey("BookId")
                .ToTable("GenreBook"));
        }
    }
}