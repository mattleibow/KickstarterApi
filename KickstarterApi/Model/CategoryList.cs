namespace KickstarterApi.Model
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CategoryList : HypermediaItem
    {
        [DataMember(Name = "categories")]
        public Category[] Categories { get; set; }

    }
}