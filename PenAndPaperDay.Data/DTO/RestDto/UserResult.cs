using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PenAndPaperDay.Data.DTO.RestDto
{
    [DataContract]
    public class UserResult
    {
        [DataMember]
        public UserForm UserForm { get; set; }
    }

    [DataContract]
    public class UserForm
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Notes { get; set; }
    }
}
