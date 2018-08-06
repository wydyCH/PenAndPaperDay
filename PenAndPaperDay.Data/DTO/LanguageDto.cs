using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO
{
    [DataContract]
    public class LanguageDto : Mapping
    {
        [DataMember]
        public string TwoDigitSeoCode { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
