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
    private readonly List<Movie> ListOfMovies = new List<Movie>();

        public bool CreateMovie(MovieCreate model)
        {
            Movie entity = new Movie
            {
                MovieId = model.MovieId,
                MovieTitle = model.MovieTitle,
                MovieReleaseYear = model.MovieReleaseYear,
                UserRating = model.UserRating
            };

            ListOfMovies.ToList().Add(entity);
            _dbContext.Movies.Add(entity);
            return _dbContext.SaveChanges() == 1;

        }
        // Get all
        public List<MovieDetails> GetAllMovies()
        {
            {
                var movieEntities = _dbContext.Movies.ToList();
                var transactionList = movieEntities.Select(t => new MovieDetails
                {
                    MovieTitle = t.MovieTitle,
                    MovieReleaseYear = t.MovieReleaseYear,
                    UserRating = t.UserRating,

                }).ToList();
                return transactionList;
            }
        }

        //Get (details by id)
        public MovieDetails GetMovieById(int movieId)
        {
            var movieEntities = _dbContext.Movies.Find(movieId);
            if (movieEntities == null)
                return null;

            var movieDetail = new MovieDetails
            {
                MovieTitle = movieEntities.MovieTitle,
                MovieReleaseYear = movieEntities.MovieReleaseYear,
                UserRating = movieEntities.UserRating,
            };
            return movieDetail;
        }
        //ArtItem Update
        public bool UpdateMovie(MovieUpdate model)
        {
            var movieEntity = _dbContext.Movies.SingleOrDefault(e => e.MovieId == model.MovieId);

            movieEntity.MovieId = model.MovieId;
            movieEntity.MovieTitle = model.MovieTitle;
            movieEntity.MovieReleaseYear = model.MovieReleaseYear;
            movieEntity.UserRating = model.UserRating;

        return _dbContext.SaveChanges() == 1;
        }

        //ArtItem Delete
        public bool MovieDelete(int id)
        {
            var movieEntity = _dbContext.Movies.SingleOrDefault(e => e.MovieId == id);

            _dbContext.Movies.Remove(movieEntity);
            return _dbContext.SaveChanges() == 1;

        }
    }
}
