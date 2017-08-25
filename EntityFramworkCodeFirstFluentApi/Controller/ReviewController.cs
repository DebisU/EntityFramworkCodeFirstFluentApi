using EntityFramworkCodeFirstFluentApi.Infrastructure;
using EntityFramworkCodeFirstFluentApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramworkCodeFirstFluentApi.Controller
{
    class ReviewController : IDbController<Review>
    {
        Context context;

        public ReviewController()
        {
            context = new Context();
        }

        public Review Create()
        {
            return new Review();
        }

        public Review Create(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
            return review;
        }

        public Review Delete(int id)
        {
            Review review = context.Reviews.Single(p => p.ReviewID == id);
            this.Delete(id, review);
            return review;
        }

        public Review Delete(int id, Review review)
        {
            Review prevReview = context.Reviews.Single(p => p.ReviewID == id);
            context.Reviews.Remove(prevReview);
            context.SaveChanges();
            return review;
        }

        public Review Details(int id)
        {
            Review review = context.Reviews.SingleOrDefault(b => b.ReviewID == id);

            if (review == null)
            {
                return new Review();
            }
            return review;
        }

        public Review Edit(int id)
        {
            Review book = context.Reviews.Single(p => p.ReviewID == id);
            if (book == null)
            {
                return new Review();
            }
            return book;
        }

        public Review Edit(int id, Review review)
        {
            Review prevReview = context.Reviews.Single(p => p.ReviewID == id);

            prevReview.ReviewID = review.ReviewID;
            prevReview.BookID = review.BookID;
            //prevReview.Book = review.Book;
            prevReview.ReviewText = review.ReviewText;

            context.SaveChanges();

            return review;
        }

        public List<Review> Index()
        {
            List<Review> reviews = context.Reviews.ToList();
            return reviews;
        }
    }
}
