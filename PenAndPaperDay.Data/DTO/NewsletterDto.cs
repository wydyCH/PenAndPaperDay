using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class NewsletterDto : Mapping
    {
        [DataMember]
        public string Email { get; set; }
    }
}
