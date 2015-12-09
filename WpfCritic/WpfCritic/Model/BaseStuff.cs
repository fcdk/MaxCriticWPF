using System;
using System.Collections.Generic;
using System.Drawing;

namespace WpfCritic.Model
{
    public class BaseStuff<T> : IStuff
        where T : BaseStuff<T>
    {
        public Guid Id { get; set; }
        private static Dictionary<Guid, T> _items = new Dictionary<Guid, T>();
        public static Dictionary<Guid, T> Items { get { return _items; } }

        //общие характеристики для фильмов, игр, музыки и сериалов
        public DateTime ReleaseDate { get; set; }
        public string Company { get; set; }
        public string Poster { get; set; }

        //все оценки контента
        public List<Review<T>> Reviews
        {
            get
            {
                var result = new List<Review<T>>();
                foreach (Review<T> review in Review<T>.Items.Values)
                    if (review.Stuff.Id == this.Id)
                        result.Add(review);
                return result;
            }
        }
        
        //все юзеры, которые давали оценку контенту
        public List<User> UsersThatRated
        {
            get
            {
                var result = new List<User>();
                foreach (Review<T> review in Review<T>.Items.Values)
                    if (review.Stuff.Id == this.Id)
                        result.Add(review.User);
                return result;
            }
        }

        // все объекты GenreInBaseStuff<T>, в которых есть ссылка на данный контент
        public List<GenreInBaseStuff<T>> GenreInBaseStuffs
        {
            get
            {
                var result = new List<GenreInBaseStuff<T>>();
                foreach (GenreInBaseStuff<T> genreInBaseStuff in GenreInBaseStuff<T>.Items.Values)
                    if (genreInBaseStuff.Stuff.Id == this.Id)
                        result.Add(genreInBaseStuff);
                return result;
            }
        }

        // все жанры этого контента
        public List<Genre<T>> Genres
        {
            get
            {
                var result = new List<Genre<T>>();
                foreach (GenreInBaseStuff<T> genreInBaseStuff in GenreInBaseStuff<T>.Items.Values)
                    if (genreInBaseStuff.Stuff.Id == this.Id)
                        result.Add(genreInBaseStuff.Genre);
                return result;
            }
        }

        public BaseStuff()
        {
            ReleaseDate = DateTime.Today;
            Company = string.Empty;
            Poster = string.Empty;
            Id = Guid.NewGuid();
            Items.Add(Id, (T)this);
        }

        public BaseStuff(DateTime releaseDate, string company, string poster)
        {
            ReleaseDate = releaseDate;
            Company = company;
            Poster = poster;
            Id = Guid.NewGuid();
            Items.Add(Id, (T)this);
        }
    }
}
