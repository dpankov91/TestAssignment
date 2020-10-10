using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingAssigment1.Core.ApplicationService;
using TestingAssigment1.Core.ApplicationService.Implementation;
using TestingAssigment1.Core.DomainService;
using TestingAssigment1.Infrastructure.Data;
using TestingAssignment1.Core.Entity;
using Xunit;

namespace XUnitTestMovieRating
{
    public class PerformanceTest
    {
        JsonReader jsReader = new JsonReader();
      
        IMovieRatingRepository mRepo ; 
        public PerformanceTest()
        {

            
            mRepo = new MovieRatingRepository(jsReader.GetData().ToList());
        }


        private void CheckPerformance(Action a, int ms)
        {
            DateTime start = DateTime.Now;
            a.Invoke();
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= ms);

        }
        [Fact]
        public void GetNumberOfReviewsFromReviewer()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(() => movieRatingService.GetNumberOfReviewsFromReviewer(1), 4000);
        }
        [Fact]
        public void GetAverageRateGivenByReviewer()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(() => movieRatingService.GetAverageRateGivenByReviewer(3), 4000);
        }
        [Fact]
        public void GetNumberOfRatesByReviewer()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(() => movieRatingService.GetNumberOfRatesByReviewer(1 , 4), 4000);
        }
        [Fact]
        public void GetNumberOfReviews()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(()=> movieRatingService.GetNumberOfReviews(1 ), 4000);
        }
        [Fact]
        public void GetAverageRateOfMovie()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(() => movieRatingService.GetAverageRateOfMovie(1) , 4000);
        }
        [Fact]
        public void GetNumberOfRates()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(() => movieRatingService.GetNumberOfRates(1 , 2),3000);
        }
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRates()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(()=> movieRatingService.GetMoviesWithHighestNumberOfTopRates(), 4000);

        }
        [Fact]
        public void GetMostProductiveReviewers()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(() => movieRatingService.GetMostProductiveReviewers() , 4000);
        }
        [Fact]
        public void GetTopRatedMovies()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(() => movieRatingService.GetTopRatedMovies(), 4000);
        }
        [Fact]
        public void GetTopMoviesByReviewer()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(() => movieRatingService.GetTopMoviesByReviewer(1), 4000);
        }
        [Fact]
        public void GetReviewersByMovie()
        {
            IMovieRatingService movieRatingService = new MovieRatingService(mRepo);
            CheckPerformance(() => movieRatingService.GetReviewersByMovie(1), 4000);
        }

      
    }
}

