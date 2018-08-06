using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class Mapping
    {
        [DataMember]
        public int Id { get; set; }
    }
}
