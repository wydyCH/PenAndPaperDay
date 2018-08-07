using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PenAndPaperDay.Data.DTO.RestDto
{
    [DataContract]
    public class OfferedGameResult
    {
        [DataMember]
        public OfferedGameForm OfferedGameForm { get; set; }
    }

    public class OfferedGameForm
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Duration { get; set; }

        [DataMember]
        public string MinSize { get; set; }

        [DataMember]
        public string MaxSize { get; set; }

        [DataMember]
        public string LanguageCode { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string GameType { get; set; }

        [DataMember]
        public string GameMasterCode { get; set; }

        [DataMember]
        public Dictionary<string, string> Tags { get; set; }
    }
}
