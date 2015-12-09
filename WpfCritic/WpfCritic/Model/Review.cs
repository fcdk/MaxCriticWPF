using System;

namespace WpfCritic.Model
{
    public class Review<T> : BaseType<Review<T>>
        where T : BaseStuff<T>
    {
        public byte Point { get; set; }
        public DateTime DateReview { get; set; }
        public string Opinion { get; set; }
        // и т.д.

        // первичные ключи для связи м:м (между юзерами и контентом)
        private Guid _userId;
        public User User
        {
            get { return User.Items[_userId]; }
            set { _userId = value.Id; }
        }

        private Guid _baseStuffId;
        public T Stuff
        {
            get { return BaseStuff<T>.Items[_baseStuffId]; }
            set { _baseStuffId = value.Id; }
        }

        public Review(User user, T stuff, byte point, DateTime dateReview, string opinion) : base()
        {
            User = user;
            Stuff = stuff;
            Point = point;
            DateReview = dateReview;
            Opinion = opinion;
        }

    }
}
