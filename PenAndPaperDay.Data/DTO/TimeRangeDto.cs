using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class TimeRangeDto : Mapping
    {
        public TimeRangeDto()
        {
            UserOnTimeRange = new List<UserOnTimeRangeDto>();
        }

        [DataMember]
        public DateTime From { get; set; }

        [DataMember]
        public DateTime Till { get; set; }

        [DataMember]
        public IList<UserOnTimeRangeDto> UserOnTimeRange { get; set; }
    }
}
