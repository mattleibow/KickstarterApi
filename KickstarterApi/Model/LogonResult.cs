namespace KickstarterApi.Model
{
    using System.Runtime.Serialization;

    [DataContract]
    class LogonResult
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
