using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie(){Taitel = "Spider-Man: Far From Home", RilisDet = new DateTime(2019, 7,2)},
                new Movie(){Taitel = "Moana", RilisDet = new DateTime(2016, 11,23)},
                new Movie(){Taitel = "Inception", RilisDet = new DateTime(2010,7,16)}
            };
        }
    }
}
