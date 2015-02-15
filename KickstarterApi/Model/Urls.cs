namespace KickstarterApi.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Urls
    {
        [DataMember(Name = "api")]
        public IDictionary<string, string> Api { get; set; }

        [DataMember(Name = "web")]
        public IDictionary<string, string> Web { get; set; }
    }
}