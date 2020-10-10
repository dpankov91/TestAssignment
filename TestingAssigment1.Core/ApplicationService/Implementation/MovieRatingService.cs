using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingAssigment1.Core.DomainService;
using TestingAssignment1.Core.Entity;

namespace TestingAssigment1.Core.ApplicationService.Implementation
{
    public class MovieRatingService : IMovieRatingService
    {
        private readonly IMovieRatingRepository _movieRatingRepo;

        public MovieRatingService(IMovieRatingRepository movieRatingRepository)
        {
            _movieRatingRepo = movieRatingRepository;
        }

        public double GetAverageRateOfMovie(int movieId)
        {
            return _movieRatingRepo.GetAverageRateOfMovie(movieId);
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _movieRatingRepo.GetTopMoviesByReviewer(reviewer);
        }

        public List<int> GetReviewersByMovie(int movieId)
        {
            return _movieRatingRepo.GetReviewersByMovie(movieId);
        }

        public double GetAverageRateGivenByReviewer(int reviewerId)
        {
            return _movieRatingRepo.GetAverageRateGivenByReviewer(reviewerId);
        }

        public int GetNumberOfRatesByReviewer(int reviewerId, int grade)
        {
            return _movieRatingRepo.GetNumberOfRatesByReviewer(reviewerId, grade);
        }

        public int GetNumberOfRates(int movieId, int grade)
        {
            return _movieRatingRepo.GetNumberOfRates(movieId, grade);
        }

        public int GetNumberOfReviews(int movieId)
        {
            return _movieRatingRepo.GetNumberOfReviews(movieId);
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return _movieRatingRepo.GetMoviesWithHighestNumberOfTopRates();
        }

        public int GetNumberOfReviewsFromReviewer(int reviewerId)
        {
            return _movieRatingRepo.GetNumberOfReviewsFromReviewer(reviewerId);
        }

        public List<int> GetTopRatedMovies()
        {
            return _movieRatingRepo.GetTopRatedMovies().ToList();
        }

        public List<int> GetMostProductiveReviewers()
        {
            return _movieRatingRepo.GetMostProductiveReviewers().ToList();
        }
    }
}
