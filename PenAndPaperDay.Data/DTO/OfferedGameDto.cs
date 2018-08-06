using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class OfferedGameDto : Mapping
    {
        public OfferedGameDto()
        {
            UserOnOfferedGame = new List<UserOnOfferedGameDto>();
            OfferedGameOnTag = new List<OfferedGameOnTagDto>();
        }

        [DataMember]
        public int Duration { get; set; }

        [DataMember]
        public int Size { get; set; }

        [DataMember]
        public int LanguageId { get; set; }

        [DataMember]
        public LanguageDto Language { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public IList<UserOnOfferedGameDto> UserOnOfferedGame { get; set; }

        [DataMember]
        public IList<OfferedGameOnTagDto> OfferedGameOnTag { get; set; }
    }
}
