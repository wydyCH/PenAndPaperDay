using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO.RestDto
{
    [DataContract]
    public class TagResult
    {
        [DataMember]
        public TagForm TagForm { get; set; }
    }

    [DataContract]
    public class TagForm
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Symbol { get; set; }
    }
}
