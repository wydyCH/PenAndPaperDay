using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO.RestDto
{
    [DataContract]
    public class UserOnTimeRangeResult
    {
        [DataMember]
        public UserOnTimeRangeForm UserOnTimeRangeForm { get; set; }
    }

    [DataContract]
    public class UserOnTimeRangeForm
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public Dictionary<string, string> TimeRanges { get; set; }
    }
}
