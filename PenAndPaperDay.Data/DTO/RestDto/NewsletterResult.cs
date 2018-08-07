using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO.RestDto
{
    [DataContract]
    public class NewsletterResult
    {
        [DataMember]
        public NewsletterForm NewsletterForm { get; set; }
    }

    [DataContract]
    public class NewsletterForm
    {
        [DataMember]
        public string Email { get; set; }
    }
}
