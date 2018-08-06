using System.ComponentModel.DataAnnotations.Schema;

namespace PenAndPaperDay.Data.Entites
{
    [Table("OfferedGameOnTag")]
    public class OfferedGameOnTag : Entity
    {
        public int OfferedGameId { get; set; }

        public OfferedGame OfferedGame { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
