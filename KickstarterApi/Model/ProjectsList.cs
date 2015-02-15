namespace KickstarterApi.Model
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ProjectsList : HypermediaItem
    {
        [DataMember(Name = "projects")]
        public Project[] Projects { get; set; }
    }
}