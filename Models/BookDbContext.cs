using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineBookManagementSystem.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext() : base("BookConnection") { }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookType> BookTypes { get; set; }

        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasRequired(b => b.BookType)
                .WithMany()
                .HasForeignKey(b => b.bookType_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Author)
                .WithMany()
                .HasForeignKey(b => b.Author_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.Publisher_id)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}