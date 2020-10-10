using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAssignment1.Core.Entity
{
    public class MovieRating
    {
        public int MovieId { get; set; }

        public int ReviewerId { get; set; }

        public int Grade { get; set; }

        public DateTime ReleaseDate { get; set; }

        public MovieRating(int movieId, int reviewerId, int grade, DateTime releaseDate)
        {
            MovieId = movieId;
            ReviewerId = reviewerId;
            Grade = grade;
            ReleaseDate = releaseDate;
        }
    }
}
