namespace KickstarterApi.Model
{
    using System.Runtime.Serialization;

    [DataContract]
    public class HypermediaItem : IHypermediaItem
    {
        [DataMember(Name = "urls")]
        public Urls Urls { get; set; }
    }
}