using System;
using System.Collections.Generic;
using System.Text;
using TestingAssignment1.Core.Entity;

namespace TestingAssigment1.Core.DomainService
{
    public interface IMovieRatingRepository
    {
        //1. On input N, what are the number of reviews from reviewer N?
        int GetNumberOfReviewsFromReviewer(int reviewerId);

        //2. On input N, what is the average rate that reviewer N had given?
        double GetAverageRateGivenByReviewer(int reviewerId);

        //3. On input N and G, how many times has reviewer N given a movie grade G?
        int GetNumberOfRatesByReviewer(int reviewerId, int grade);

        //4. On input N, how many have reviewed movie N?
        int GetNumberOfReviews(int movieId);

        //5. On input N, what is the average rate the movie N had received?
        double GetAverageRateOfMovie(int movieId);

        //6. On input N and G, how many times had movie N received grade G?
        int GetNumberOfRates(int movieId, int grade);

        //7. What is the id(s) of the movie(s) with the highest number of top rates(5)?
        List<int> GetMoviesWithHighestNumberOfTopRates();

        //8. What reviewer(s) had done most reviews?
        IEnumerable<int> GetMostProductiveReviewers();

        //9. On input N, what is top N of movies? The score of a movie is its average rate.
        IEnumerable<int> GetTopRatedMovies();

        //10. On input N, what are the movies that reviewer N has reviewed? The list should
        //be sorted decreasing by rate first, and date secondly.
        List<int> GetTopMoviesByReviewer(int reviewer);

        //11. On input N, what are the reviewers that have reviewed movie N? The list
        //should be sorted decreasing by rate first, and date secondly.
        List<int> GetReviewersByMovie(int movieId);
    }
}
