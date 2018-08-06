using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PenAndPaperDay.Data.Entites
{
    [Table("ErrorLogEntries")]
    public class ErrorLogEntry : Entity
    {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string LogLevel { get; set; }
        public string Logger { get; set; }
        public string UserId { get; set; }
        public string StackTrace { get; set; }
        public string Machinename { get; set; }
        public string AppName { get; set; }
        public string TransactionId { get; set; }
    }
}
