using EntityFramworkCodeFirstFluentApi.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkCodeFirstFluentApi
{
    class Context : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public Context()
            : base("name=BookDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetUpBookModel(modelBuilder);
            SetUpReviewModel(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SetUpBookModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("books");
            modelBuilder.Entity<Book>().HasKey<int>(b => b.BookID);
            modelBuilder.Entity<Book>().Property(b => b.BookID)
                .HasColumnName("BookID");
            modelBuilder.Entity<Book>().Property(b => b.BookName)
                    .HasColumnName("BookName");
            modelBuilder.Entity<Book>().Property(b => b.ISBN)
                        .HasColumnName("ISBN");
        }

        private void SetUpReviewModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().ToTable("review");
            modelBuilder.Entity<Review>().HasKey<int>(r => r.ReviewID);
            modelBuilder.Entity<Review>().Property(r => r.ReviewID)
                .HasColumnName("ReviewID");
            modelBuilder.Entity<Review>().Property(r => r.BookID)
                    .HasColumnName("BookID");
            modelBuilder.Entity<Review>().Property(r => r.ReviewText)
                        .HasColumnName("ReviewText");
        }
    }
}
