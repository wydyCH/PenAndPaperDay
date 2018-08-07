using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class UserOnTimeRangeDto : Mapping
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public UserDto User { get; set; }

        [DataMember]
        public int TimeRangeId { get; set; }

        [DataMember]
        public TimeRangeDto TimeRange { get; set; }
    }
}
