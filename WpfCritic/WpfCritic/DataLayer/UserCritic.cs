using System;
using System.Data;

namespace WpfCritic.DataLayer
{
    [TableName("UserCritic")]
    [IdColumnName("UserId")]
    [NameColumnName("Username")] // поиск по имени юзера в классе Entity будет по его никнейму
    public class UserCritic : Entity<UserCritic>
    {
        public string Username
        {
            get { return Row["Username"].ToString(); }
            set { Row["Username"] = value; }
        }
        public string Name
        {
            get { return Row["Name"].ToString(); }
            set { Row["Name"] = value; }
        }
        public string Surname
        {
            get { return Row["Surname"].ToString(); }
            set { Row["Surname"] = value; }
        }
        public DateTime? DateOfBirth
        {
            get { return Row["DateOfBirth"].Equals(DBNull.Value) ? default(DateTime?) : (DateTime)Row["DateOfBirth"]; }
            set { Row["DateOfBirth"] = value; }
        }
        public GenderType? Gender
        {
            get { return Row["Gender"].Equals(DBNull.Value) ? default(GenderType?) : (GenderType)Enum.Parse(typeof(GenderType), Row["Gender"].ToString()); }
            set { Row["Gender"] = value; }
        }
        public string Country
        {
            get { return Row["Country"].ToString(); }
            set { Row["Surname"] = value; }
        }
        public string PublicationCompany
        {
            get { return Row["PublicationCompany"].ToString(); }
            set { Row["PublicationCompany"] = value; }
        }
        public UserCritic.Role UserRole
        {
            get { return (UserCritic.Role)Enum.Parse(typeof(UserCritic.Role), Row["UserRole"].ToString()); }
            set { Row["UserRole"] = value; }
        }
        public string Email
        {
            get { return Row["Email"].ToString(); }
            set { Row["Email"] = value; }
        }
        public byte[] Image
        {
            get { return Row["Image"].Equals(DBNull.Value) ? null : (byte[])Row["Image"]; }
            set { Row["Image"] = value; }
        }

        public UserCritic(DataRow row) : base(row) { }
        public UserCritic(string username, string name, string surname, DateTime? dateOfBirth, GenderType? gender, string country,
        string publicationCompany, UserCritic.Role userRole, string email, byte[] image) : base()
        {
            Username = username;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Country = country;
            PublicationCompany = publicationCompany;
            UserRole = userRole;
            Email = email;
            Image = image;
        }

        public enum GenderType { Male, Female }
        public enum Role { Admin, User, Critic }
    }
}
