using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class TagDto : Mapping
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Symbol { get; set; }
    }
}
