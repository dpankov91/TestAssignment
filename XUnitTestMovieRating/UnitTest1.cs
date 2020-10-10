using System;
using System.Collections.Generic;
using System.Linq;
using TestingAssigment1.Core.ApplicationService;
using TestingAssigment1.Core.ApplicationService.Implementation;
using TestingAssigment1.Core.DomainService;
using TestingAssigment1.Infrastructure.Data;
using TestingAssignment1.Core.Entity;
using Xunit;

namespace XUnitTestMovieRating
{
    public class UnitTest1
    {
        JsonReader jsReader = new JsonReader();

        IMovieRatingRepository mRepo;
        public UnitTest1()
        {


            mRepo = new MovieRatingRepository(jsReader.GetData().ToList());
        }


        [Theory]
        [InlineData(2, 2)]
        [InlineData(1, 1)]
        [InlineData(3, 2)]
        public void GetNumberOfReviewsFromReviewerTest(int reviewerId, int numberOfReviews)
        {
            //Creating object of MovieRatingRepository class to call methods.
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();

            //Adding movie rating objects to list. This is mock data. (movieId, reviewerId, grade, releaseDate)
            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 3, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 3, 4, DateTime.Now));

            //Creating object of MovieRatingService class to call methods.
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);

            //Creating variable what will return actual number of reviews
            int actual = movieRatingService.GetNumberOfReviewsFromReviewer(reviewerId);

            //Creating variable what will return expected number of reviews
            int expected = numberOfReviews;

            //Checking if expected and actual variables match
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 4.5)]
        [InlineData(1, 3.5)]
        [InlineData(3, 3.0)]
        public void GetAverageRateGivenByReviewer(int reviewerId, double averageRate)
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();

            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 3, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 3, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 4, DateTime.Now));

            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);

            double actual = movieRatingService.GetAverageRateGivenByReviewer(reviewerId);

            double expected = averageRate;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 5, 1)]
        [InlineData(2, 4, 1)]
        [InlineData(3, 3, 4)]
        public void GetCountOfGradesGivenByReviewer(int reviewerId, int grade, int amountOfGrades)
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();
            
            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 3, 3, DateTime.Now));

            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);

            double actual = movieRatingService.GetNumberOfRatesByReviewer(reviewerId, grade);

            double expected = amountOfGrades;

            Assert.Equal(expected, actual);
        }

        //4

        //[Fact]
        //public void getCountOfMovieReviewers(int movieId)
        //{
        //    Mock<IMovieRatingRepository> m = new Mock<IMovieRatingRepository>();
        //    MovieRating[] retMovieRatings = {new MovieRating {ReviewerId = 1, MovieId = 2, Grade = 3, ReleaseDate = DateTime.Now},
        //         new MovieRating {ReviewerId = 2, MovieId = 1, Grade = 2, ReleaseDate = DateTime.Now}
        //    };

        //    m.Setup(m => m.getCountOfMovieReviewers()).Returns(() => retMovieRatings);

        //    MovieRatingService mService = new MovieRatingService(m.Object);
        //    int actualResult = mService.getCountOfMovieReviewers(2);
        //    Assert.True(actualResult == 1);
        //}

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 2)]
        [InlineData(3, 2)]

        public void GetNumberOfReviews(int movieId, int countOfReviewers)
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();

            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 3, 3, DateTime.Now));

            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);
            int actualResult = movieRatingService.GetNumberOfReviews(movieId);
            double expectedResult = countOfReviewers;
            Assert.Equal(expectedResult, actualResult);

        }

        //n5
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 3.5)]
        [InlineData(3, 2.5)]
        public void GetAverageRateOfMovie(int movieId, double averageRating)
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();

            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 2, 2, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);
            double actualResult = movieRatingService.GetAverageRateOfMovie(movieId);
            double expectedResult = averageRating;
            Assert.Equal(expectedResult, actualResult);
        }

        //n6
        [Theory]
        [InlineData(1, 3 , 1)]
        [InlineData(2, 3, 1)]
        [InlineData(3, 2 , 1)]
        public void GetNumberOfRates(int movieId, int grade , int count)
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();

            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 2, 2, DateTime.Now));

            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);
            double actualResult = movieRatingService.GetNumberOfRates(movieId , grade);
            double expectedResult = count;
            Assert.Equal(expectedResult, actualResult);
        }

        //n7
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRatesTest()
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();
            //movieId, reviewerId, grade, realease
            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 3, 5, DateTime.Now));

            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);

            List<int> actual = movieRatingService.GetMoviesWithHighestNumberOfTopRates();

            List<int> expected = new List<int>{1, 3 , 2, 4};

            Assert.Equal(expected, actual);
        }
        //n8    

        [Fact]
        public void GetMostProductiveReviewers()
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();
            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 3, 5, DateTime.Now));

            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);

            List<int> actual = movieRatingService.GetMostProductiveReviewers();

            List<int> expected = new List<int> {2,1,3};

            Assert.Equal(expected, actual);
        }

        //n9
            [Fact]
        public void GetTopRatedMovies()
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();
            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 3, 5, DateTime.Now));

            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);

            List<int> actual = movieRatingService.GetMostProductiveReviewers();

            List<int> expected = new List<int> { 2 , 1 , 3 };

            Assert.Equal(expected, actual);
        }

        // n10
        [Fact]
        public void GetTopMoviesByReviewerTest()
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();
            //movieId, reviewerId, grade, realease
            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 3, 1, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 3, 4, DateTime.Now.AddDays(1)));
            movieRatingRepo.Add(new MovieRating(3, 3, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 5, DateTime.Now.AddDays(1)));
            movieRatingRepo.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 1, 5, DateTime.Now));

            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);

            List<int> actual = movieRatingService.GetTopMoviesByReviewer(3);

            List<int> expected = new List<int> { 3, 4, 1 };

            Assert.Equal(expected, actual);
        }

        // n11
        [Fact]
        public void GetReviewersByMovieTest()
        {
            MovieRatingRepository movieRatingRepo = new MovieRatingRepository();
            //movieId, reviewerId, grade, realease
            movieRatingRepo.Add(new MovieRating(1, 2, 5, DateTime.Now.AddDays(3)));
            movieRatingRepo.Add(new MovieRating(1, 3, 3, DateTime.Now.AddDays(1)));
            movieRatingRepo.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(4, 3, 3, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(3, 1, 5, DateTime.Now));
            movieRatingRepo.Add(new MovieRating(1, 1, 3, DateTime.Now.AddDays(5)));
            movieRatingRepo.Add(new MovieRating(3, 3, 5, DateTime.Now));

            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepo);

            List<int> actual = movieRatingService.GetReviewersByMovie(1);

            List<int> expected = new List<int> { 2, 3, 1 };

            Assert.Equal(expected, actual);
        }
    }
}
