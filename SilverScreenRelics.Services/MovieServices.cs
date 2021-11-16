using ScreenRelics.Data;
using SilverScreenRelics.Data.Entities;
using SilverScreenRelics.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverScreenRelics.Services
{
    public class MovieServices
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        //Movie Create
        public bool CreateMovie(MovieCreate model)
        {
            Movie entity = new Movie
            {
                MovieId = model.MovieId,
                MovieTitle = model.MovieTitle,
                MovieReleaseYear = model.MovieReleaseYear,
                UserRating = model.UserRating,

    };

            _dbContext.Movies.Add(entity);
            return _dbContext.SaveChanges() == 1;

        }
        // Movie Get all
        public List<MovieDetails> GetAllMovies()
        {
            {
                var movieEntities = _dbContext.Movies.ToList();
                var movies = movieEntities.Select(m => new MovieDetails
                {
                    MovieTitle = m.MovieTitle,
                    MovieReleaseYear = m.MovieReleaseYear,
                    UserRating = m.UserRating,

                }).ToList();
                return movies;
            }
        }

        //Movie Get (details by id)
        public MovieDetails GetMovieById(int movieId)
        {
            var movieEntity = _dbContext.Movies.Find(movieId);
            if (movieEntity == null)
                return null;

            var movieDetail = new MovieDetails
            {
                MovieTitle = movieEntity.MovieTitle,
                MovieReleaseYear = movieEntity.MovieReleaseYear,
                UserRating = movieEntity.UserRating,
            };  

            return movieDetail;
        }
        //Movie Update
        public bool UpdateMovie(MovieUpdate model)
        {
            var movieEntity = _dbContext.Movies.SingleOrDefault(m => m.MovieId == model.MovieId);

            movieEntity.MovieId = model.MovieId;
            movieEntity.MovieTitle = model.MovieTitle;
            movieEntity.MovieReleaseYear = model.MovieReleaseYear;
            movieEntity.UserRating = model.UserRating;

            return _dbContext.SaveChanges() == 1;
        }

        //Movie Delete
        public bool DeleteMovie(int id)
        {
            var movieEntity = _dbContext.Movies.SingleOrDefault(m => m.MovieId == id);

            _dbContext.Movies.Remove(movieEntity);
            return _dbContext.SaveChanges() == 1;

        }
    }
}
