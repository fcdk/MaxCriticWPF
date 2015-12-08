using System;

namespace WpfCritic.Model
{
    public class GenreInBaseStuff<T> : BaseType<GenreInBaseStuff<T>>
        where T : BaseStuff<T>
    {
        // первичные ключи для связи м:м (между жанрами и контентом)
        private Guid _genreId;

        public Genre<T> Genre
        {
            get { return Genre<T>.Items[_genreId]; }
            set { _genreId = value.Id; }
        }

        private Guid _baseStuffId;

        public T Stuff
        {
            get { return BaseStuff<T>.Items[_baseStuffId]; }
            set { _baseStuffId = value.Id; }
        }

        public GenreInBaseStuff(Genre<T> genre, T stuff) : base()
        {
            Genre = genre;
            Stuff = stuff;
        }
    }
}