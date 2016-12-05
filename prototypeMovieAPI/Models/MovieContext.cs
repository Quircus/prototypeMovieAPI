using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototypeMovieAPI.Models
{

    public class MovieContext : DbContext
    {
        public MovieContext() : base("Movie Project")               // is system ok with space in string?
        {
            Database.SetInitializer<MovieContext>(new CreateDatabaseIfNotExists<MovieContext>());
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
    }


}