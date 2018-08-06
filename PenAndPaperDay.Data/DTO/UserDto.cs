using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class UserDto : Mapping
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Games { get; set; }

        [DataMember]
        public IList<UserOnOfferedGameDto> UserOnOfferedGame { get; set; }
    }
}
