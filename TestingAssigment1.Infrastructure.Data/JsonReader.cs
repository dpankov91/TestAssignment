using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using TestingAssignment1.Core.Entity;

namespace TestingAssigment1.Infrastructure.Data
{
    public class JsonReader
	{
        
        private const string filePath = @"..\..\..\..\movieRatings.json";


        public IEnumerable<MovieRating> GetData()
        {
            IEnumerable<MovieRating> movieRatings = JsonConvert.DeserializeObject<IEnumerable<MovieRating>>(File.ReadAllText(filePath));
            return movieRatings;
        }
    }
}

