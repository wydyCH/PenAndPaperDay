using System.ComponentModel.DataAnnotations.Schema;
using PenAndPaperDay.Data.Enum;

namespace PenAndPaperDay.Data.Entites
{
    [Table("UserOnOfferedGame")]
    public class UserOnOfferedGame : Entity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int OfferedGameId { get; set; }

        public OfferedGame OfferdGame { get; set; }

        public UserType UserType { get; set; }
    }
}
