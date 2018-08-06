using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PenAndPaperDay.Data.DTO.RestDto
{
    [DataContract]
    public class TimeRangeResultDto
    {
        [DataMember]
        public TimeRangeForm TimeRangeForm { get; set; }
    }

    [DataContract]
    public class TimeRangeForm
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string From { get; set; }

        [DataMember]
        public string Till { get; set; }
    }
}
