using System.Text.Json.Serialization;

namespace UserProject.API.Entities
{
    public class Login : Entity
    {
        public Login(Guid? uuid, string? username, string? password, string? salt, string? md5, string? sha1, string? sha256)
        {
            this.uuid = uuid;
            Username = username;
            Password = password;
            Salt = salt;
            Md5 = md5;
            Sha1 = sha1;
            Sha256 = sha256;
        }
        public Login() { }

        public Guid? uuid { get; set; }
        public string? Username { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? Salt { get; set; } = string.Empty;
        public string? Md5 { get; set; } = string.Empty;
        public string? Sha1 { get; set; } = string.Empty;
        public string? Sha256 { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual User? User { get; set; }
        public int UserId { get; set; }
    }
}
