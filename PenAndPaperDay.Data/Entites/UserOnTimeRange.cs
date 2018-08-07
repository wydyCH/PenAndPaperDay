using System.ComponentModel.DataAnnotations.Schema;

namespace PenAndPaperDay.Data.Entites
{
    [Table("UserOnTimeRange")]
    public class UserOnTimeRange : Entity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int TimeRangeId { get; set; }

        public TimeRange TimeRange { get; set; }
    }
}
