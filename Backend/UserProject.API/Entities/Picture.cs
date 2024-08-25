using System.Text.Json.Serialization;

namespace UserProject.API.Entities
{
    public class Picture : Entity
    {
        public Picture(string? thumbnail, string? medium, string? large)
        {
            Thumbnail = thumbnail;
            Medium = medium;
            Large = large;
        }

        public Picture() { }
        public string? Thumbnail { get; set; }
        public string? Medium { get; set; }
        public string? Large { get; set; }

        [JsonIgnore]
        public virtual User? User { get; set; }
        public int UserId { get; set; }
    }
}
