namespace KickstarterApi.Model
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CategoryReference
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}