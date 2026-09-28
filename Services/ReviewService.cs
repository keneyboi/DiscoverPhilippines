using DiscoverPhilippines.Models;

namespace DiscoverPhilippines.Services
{
    public class ReviewService
    {
        private readonly List<Review> reviews = new();

        private int nextId = 1;

        public List<Review> GetAllReviews()
        {
            return reviews;
        }

        public IEnumerable<Review> GetReviewsByDestination(string destination)
        {
            return reviews.Where(review =>
                review.Destination.Equals(
                    destination,
                    StringComparison.OrdinalIgnoreCase
                )
            );
        }

        public void AddReview(
            string destination,
            int rating,
            string comment
        )
        {
            reviews.Add(
                new Review
                {
                    Id = nextId++,
                    Destination = destination,
                    Rating = rating,
                    Comment = comment
                }
            );
        }

        public void RemoveReview(int id)
        {
            var review = reviews.FirstOrDefault(r => r.Id == id);

            if (review != null)
            {
                reviews.Remove(review);
            }
        }
    }
}