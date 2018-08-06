using System;
using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class TimeRangeDto : Mapping
    {
        [DataMember]
        public DateTime From { get; set; }

        [DataMember]
        public DateTime Till { get; set; }
    }
}
