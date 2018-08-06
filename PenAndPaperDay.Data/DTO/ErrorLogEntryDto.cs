using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class ErrorLogEntryDto : Mapping
    {
        [DataMember]
        public DateTime TimeStamp { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string LogLevel { get; set; }

        [DataMember]
        public string Logger { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string StackTrace { get; set; }

        [DataMember]
        public string Machinename { get; set; }

        [DataMember]
        public string AppName { get; set; }

        [DataMember]
        public string TransactionId { get; set; }
    }
}
