using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO.RestDto
{
    [DataContract]
    public class ContactUsResult
    {
        [DataMember]
        public ContactUsForm ContactUsForm { get; set; }
    }

    [DataContract]
    public class ContactUsForm
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Text { get; set; }
    }
}
