using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TestingAssigment1.Core.DomainService;
using TestingAssignment1.Core.Entity;

namespace TestingAssigment1.Infrastructure.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        private List<MovieRating> _movieRating = new List<MovieRating>();

        public MovieRatingRepository()
        {
            
        }

        public MovieRatingRepository(List<MovieRating> movieRatings )
        {
            _movieRating = movieRatings;
        }

        //method to add mock data to List
        public void Add(MovieRating movieRating)
        {
            _movieRating.Add(movieRating);
        }

        public int GetNumberOfReviewsFromReviewer(int reviewerId)
        {
            return _movieRating
                .Where(mr => mr.ReviewerId == reviewerId)
                .Count();
        }

        public double GetAverageRateGivenByReviewer(int reviewerId)
        {
            return _movieRating
                .Where(mr => mr.ReviewerId == reviewerId)
                .Select(mr => mr.Grade)
                .Average();
                
        }

        public int GetNumberOfRatesByReviewer(int reviewerId, int grade)
        {
            return _movieRating
                .Where(mr => mr.ReviewerId == reviewerId && mr.Grade == grade)
                .Count();
        }

        public int GetNumberOfReviews(int movieId)
        {
            return _movieRating.Where(mr => mr.MovieId == movieId).Count();
        }

        public double GetAverageRateOfMovie(int movieId)
        {
            return _movieRating.Where(mr => mr.MovieId == movieId).Select(mr => mr.Grade).DefaultIfEmpty(0).Average();
        }

        public int GetNumberOfRates(int movieId, int grade)
        {
            return _movieRating.Where(mr => mr.MovieId == movieId).Where(mr => mr.Grade == grade).Count();
        }

        //We order movieRatings by Grade from 5 to 1(OrderByDescending), 
        //we select to return MovieIds(list of int), only one of each id(Distinct) 
        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return _movieRating
                .OrderByDescending(mr => mr.Grade)
                .Select(mr => mr.MovieId)
                .Distinct()
                .ToList();
        }

        public IEnumerable<int> GetMostProductiveReviewers()
        {
            return _movieRating.GroupBy(mr => mr.ReviewerId).OrderBy(mr => mr.Count()).Select(mr => mr.Key);
        }

        public IEnumerable<int> GetTopRatedMovies()
        {
            return _movieRating.OrderBy(mr => mr.Grade).Select((mr => mr.MovieId)).Distinct();
        }

        //
        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _movieRating
                .Where(mr => mr.ReviewerId == reviewer)
                .OrderByDescending(mr => mr.Grade)
                .ThenBy(mr => mr.ReleaseDate)
                .Select(mr => mr.MovieId)
                .Distinct()
                .ToList();
        }

        public List<int> GetReviewersByMovie(int movieId)
        {
            return _movieRating
                .Where(mr => mr.MovieId == movieId)
                .OrderByDescending(mr => mr.Grade)
                .ThenBy(mr => mr.ReleaseDate)
                .Select(mr => mr.ReviewerId)
                .Distinct()
                .ToList();
        }
    }
}
