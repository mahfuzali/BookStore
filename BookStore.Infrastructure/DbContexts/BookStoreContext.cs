using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.Infrastructure.DbContexts
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Author a1 = new Author()
            {
                Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                FirstName = "Harper",
                LastName = "Lee",
                DateOfBirth = new DateTime(1926, 4, 28),
            };
            Author a2 = new Author()
            {
                Id = Guid.Parse("f27f4118-6ce2-413c-8869-8d30eaa81ba5"),
                FirstName = "William",
                LastName = "Shakespeare",
                DateOfBirth = new DateTime(1564, 4, 26),
            };

            Book b1 = new Book()
            {
                Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                Title = "To Kill a Mockingbird",
                Description = "Scout Finch lives with her brother, Jem, and their widowed father, Atticus, in the sleepy Alabama town of Maycomb. Maycomb is suffering through the Great Depression, but Atticus is a prominent lawyer and the Finch family is reasonably well off in comparison to the rest of society.",
                AuthorId = a1.Id
            };

            Book b2 = new Book()
            {
                Id = Guid.Parse("4ae2a995-59f8-4f43-986d-54c681eaab97"),
                Title = "Romeo and Juliet",
                Description = "An age-old vendetta between two powerful families erupts into bloodshed. A group of masked Montagues risk further conflict by gatecrashing a Capulet party. A young lovesick Romeo Montague falls instantly in love with Juliet Capulet, who is due to marry her father's choice, the County Paris.",
                AuthorId = a2.Id
            };

            modelBuilder.Entity<Author>().HasData(
                a1,
                a2
            );

            modelBuilder.Entity<Book>().HasData(
                b1,
                b2
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}