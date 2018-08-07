using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PenAndPaperDay.Data.Entites
{
    [Table("User")]
    public class User : Entity
    {
        public string Code { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public ICollection<UserOnOfferedGame> UserOnOfferedGame { get; } = new List<UserOnOfferedGame>();
    }
}
