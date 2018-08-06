using System.ComponentModel.DataAnnotations.Schema;

namespace PenAndPaperDay.Data.Entites
{
    [Table("Tag")]
    public class Tag : Entity
    {
        public string Name { get; set; }

        public string Symbol { get; set; }
    }
}
