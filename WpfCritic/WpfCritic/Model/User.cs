using System;
using System.Collections.Generic;

namespace WpfCritic.Model
{
    public class User : BaseType<User>
    {
        public string Name { get; set; }
        // и т.д.

        // все отзывы о фильмах этого пользователя
        public List<Review<Movie>> MovieReviews
        {
            get
            {
                var result = new List<Review<Movie>>();
                foreach (Review<Movie> movieReview in Review<Movie>.Items.Values)
                    if (movieReview.User.Id == this.Id)
                        result.Add(movieReview);
                return result;
            }
        }
        
        // все фильмы, о которых писал отзыв этот пользователь
        public List<Movie> Movies
        {
            get
            {
                var result = new List<Movie>();
                foreach (Review<Movie> movieReview in Review<Movie>.Items.Values)
                    if (movieReview.User.Id == this.Id)
                        result.Add(movieReview.Stuff);
                return result;
            }
        }

        // все отзывы об альбомах этого пользователя
        public List<Review<Album>> AlbumReviews
        {
            get
            {
                var result = new List<Review<Album>>();
                foreach (Review<Album> albumReview in Review<Album>.Items.Values)
                    if (albumReview.User.Id == this.Id)
                        result.Add(albumReview);
                return result;
            }
        }

        // все альбомы, о которых писал отзыв этот пользователь
        public List<Album> Albums
        {
            get
            {
                var result = new List<Album>();
                foreach (Review<Album> albumReview in Review<Album>.Items.Values)
                    if (albumReview.User.Id == this.Id)
                        result.Add(albumReview.Stuff);
                return result;
            }
        }

        // все отзывы об играх этого пользователя
        public List<Review<Game>> GameReviews
        {
            get
            {
                var result = new List<Review<Game>>();
                foreach (Review<Game> gameReview in Review<Game>.Items.Values)
                    if (gameReview.User.Id == this.Id)
                        result.Add(gameReview);
                return result;
            }
        }

        // все игры, о которых писал отзыв этот пользователь
        public List<Game> Games
        {
            get
            {
                var result = new List<Game>();
                foreach (Review<Game> gameReview in Review<Game>.Items.Values)
                    if (gameReview.User.Id == this.Id)
                        result.Add(gameReview.Stuff);
                return result;
            }
        }

        // все отзывы о сериалах этого пользователя
        public List<Review<TVSeries>> TVSeriesReviews
        {
            get
            {
                var result = new List<Review<TVSeries>>();
                foreach (Review<TVSeries> tvSeriesReview in Review<TVSeries>.Items.Values)
                    if (tvSeriesReview.User.Id == this.Id)
                        result.Add(tvSeriesReview);
                return result;
            }
        }

        // все сериалы, о которых писал отзыв этот пользователь
        public List<TVSeries> TVSeriess
        {
            get
            {
                var result = new List<TVSeries>();
                foreach (Review<TVSeries> tvSeriesReview in Review<TVSeries>.Items.Values)
                    if (tvSeriesReview.User.Id == this.Id)
                        result.Add(tvSeriesReview.Stuff);
                return result;
            }
        }

        public User(string name) : base()
        {
            Name = name;
        }

    }
}
