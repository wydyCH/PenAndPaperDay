using System.ComponentModel.DataAnnotations.Schema;

namespace PenAndPaperDay.Data.Entites
{
    [Table("Language")]
    public class Language : Entity
    {
        public string TwoDigitSeoCode { get; set; }

        public string Name { get; set; }
    }
}
