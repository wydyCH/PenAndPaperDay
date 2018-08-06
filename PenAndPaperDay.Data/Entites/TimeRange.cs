using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.Entites
{
    [Table("TimeRange")]
    public class TimeRange : Entity
    {
        public DateTime From { get; set; }

        public DateTime Till { get; set; }
    }
}
