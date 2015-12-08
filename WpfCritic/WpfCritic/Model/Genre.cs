using System;
using System.Collections.Generic;

namespace WpfCritic.Model
{
    public class Genre<T> : BaseType<Genre<T>>
        where T : BaseStuff<T>
    {
        public string Name { get; set; }
        // родительский жанр
        private Guid _baseGenreId;
        public Genre<T> BaseGenre
        {
            get { return Genre<T>.Items[_baseGenreId]; }
            set { _baseGenreId = value.Id; }
        }

        // все базовые жанры для этого жанра (при условии, что корень дерева жанров будет иметь значение _baseGenreId == null)
        public List<Genre<T>> AllBaseGenres
        {
            get
            {
                var result = new List<Genre<T>>();
                Genre<T> g = Genre<T>.Items[this._baseGenreId];
                while (g != null)
                {
                    result.Add(g);
                    g = Genre<T>.Items[g._baseGenreId];
                }
                return result;
            }
        }

        // все объекты GenreInBaseStuff<T>, в которых есть ссылка на данный жанр
        public List<GenreInBaseStuff<T>> GenreInBaseStuffs
        {
            get
            {
                var result = new List<GenreInBaseStuff<T>>();
                foreach (GenreInBaseStuff<T> genreInBaseStuff in GenreInBaseStuff<T>.Items.Values)
                    if (genreInBaseStuff.Genre.Id == this.Id)
                        result.Add(genreInBaseStuff);
                return result;
            }
        }

        // весь контент данного жанра
        public List<T> Stuffs
        {
            get
            {
                var result = new List<T>();
                foreach (GenreInBaseStuff<T> genreInBaseStuff in GenreInBaseStuff<T>.Items.Values)
                    if (genreInBaseStuff.Genre.Id == this.Id)
                        result.Add(genreInBaseStuff.Stuff);
                return result;
            }
        }

        public Genre(string name, Genre<T> baseGenre) : base()
        {
            Name = name;
            BaseGenre = baseGenre;
        }
    }
}
