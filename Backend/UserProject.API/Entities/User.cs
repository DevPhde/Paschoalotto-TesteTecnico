using System.Text.Json.Serialization;

namespace UserProject.API.Entities
{
    public class User : Entity
    {

        public string? IdName { get; set; }
        public string? IdValue { get; set; }
        public string? Gender { get; set; }
        public string? Title { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirthday { get; set; }
        public int? Age { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public int? AgeRegistration {  get; set; }
        public string? Phone { get; set; }
        public string? Cell { get; set; }
        public string? Nat { get; set; }


        public virtual Login? Login { get; set; }
        [JsonIgnore]
        public int LoginId { get; set; }
        public Location? Location { get; set; }
        [JsonIgnore]
        public int LocationId { get; set; }
        public Picture? Picture { get; set; }
        [JsonIgnore]
        public int PictureId { get; set; }



        public User(string? idName, string? idValue, string? gender,string? title, string? fullName, string? email, DateTime? dateOfBirthday, int? age, DateTime? registeredDate,int? ageRegistration, string? phone, string? cell, string? nat, Login? login, Location? location, Picture? picture)
        {
            IdName = idName;
            IdValue = idValue;
            Gender = gender;
            Title = title;
            FullName = fullName;
            Email = email;
            DateOfBirthday = dateOfBirthday;
            Age = age;
            RegisteredDate = registeredDate;
            AgeRegistration = ageRegistration;
            Phone = phone;
            Cell = cell;
            Nat = nat;
            Login = login;
            Location = location;
            Picture = picture;
        }
        public User() { }
    }
}
