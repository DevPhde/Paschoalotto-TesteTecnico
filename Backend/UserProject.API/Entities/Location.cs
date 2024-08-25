using System.Text.Json.Serialization;

namespace UserProject.API.Entities
{
    public class Location : Entity
    {
        public Location(string? streetName, int? streetNumber, string? city, string? state, string? country, int? postCode, float? latitude, float? longitude, string? timezoneOffset, string? timezoneDescription)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            City = city;
            State = state;
            Country = country;
            PostCode = postCode;
            Latitude = latitude;
            Longitude = longitude;
            TimezoneOffset = timezoneOffset;
            TimezoneDescription = timezoneDescription;
        }

        public Location() { }

        public string? StreetName { get; set; }
        public int? StreetNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int? PostCode { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string? TimezoneOffset { get; set; }
        public string? TimezoneDescription { get; set; }

        [JsonIgnore]
        public virtual User? User { get; set; }
        public int UserId { get; set; }
    }
}
