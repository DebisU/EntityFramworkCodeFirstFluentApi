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
        public virtual DbSet<Library> Libraries { get; set; }
        public Context()
            : base("name=BookDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetUpBookModel(modelBuilder);
            SetUpReviewModel(modelBuilder);
            SetUpLibraryModel(modelBuilder);

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
            modelBuilder.Entity<Book>().Property(r => r.LibraryId)
                        .HasColumnName("Library_Id");
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

        private void SetUpLibraryModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>().ToTable("library");
            modelBuilder.Entity<Library>().HasKey<int>(r => r.Id);
            modelBuilder.Entity<Library>().Property(r => r.Id)
                .HasColumnName("Id");
            modelBuilder.Entity<Library>().Property(r => r.Name)
                    .HasColumnName("Name");
            modelBuilder.Entity<Library>().Property(r => r.address)
                        .HasColumnName("address");

        }
    }
}
