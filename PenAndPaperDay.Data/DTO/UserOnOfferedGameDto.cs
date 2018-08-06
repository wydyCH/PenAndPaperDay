using System.Runtime.Serialization;
using PenAndPaperDay.Data.Enum;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class UserOnOfferedGameDto : Mapping
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public UserDto User { get; set; }

        [DataMember]
        public int OfferedGameId { get; set; }

        [DataMember]
        public OfferedGameDto OfferdGame { get; set; }

        [DataMember]
        public UserType UserType { get; set; }
    }
}
