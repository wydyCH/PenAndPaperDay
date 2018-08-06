using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO
{
    public class OfferedGameOnTagDto : Mapping
    {
        [DataMember]
        public int TagId { get; set; }

        [DataMember]
        public TagDto Tag { get; set; }

        [DataMember]
        public int OfferedGameId { get; set; }

        [DataMember]
        public OfferedGameDto OfferdGame { get; set; }
    }
}
