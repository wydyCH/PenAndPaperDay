using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PenAndPaperDay.Data.Entites
{
    [Table("OfferedGame")]
    public class OfferedGame : Entity
    {
        public int Duration { get; set; }

        public int Size { get; set; }

        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }

        public string Description { get; set; }

        public ICollection<UserOnOfferedGame> UserOnOfferedGame { get; set; } = new List<UserOnOfferedGame>();

        public ICollection<OfferedGameOnTag> OfferedGameOnTag { get; set; } = new List<OfferedGameOnTag>();
    }
}
