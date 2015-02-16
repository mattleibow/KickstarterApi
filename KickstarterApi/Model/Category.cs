namespace KickstarterApi.Model
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Category : HypermediaItem
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "position")]
        public int Position { get; set; }

        [DataMember(Name = "projects_count")]
        public int ProjectCount { get; set; }

        [DataMember(Name = "parent_id")]
        public long ParentId { get; set; }

        [DataMember(Name = "parent")]
        public CategoryReference Parent { get; set; }
    }
}