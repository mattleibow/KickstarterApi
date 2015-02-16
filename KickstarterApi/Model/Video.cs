namespace KickstarterApi.Model
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Video
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "high")]
        public string High { get; set; }

        [DataMember(Name = "base")]
        public string Base { get; set; }

        [DataMember(Name = "webm")]
        public string WebM { get; set; }

        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "frame")]
        public string Frame { get; set; }
    }
}