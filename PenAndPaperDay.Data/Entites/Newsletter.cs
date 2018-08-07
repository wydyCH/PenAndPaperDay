using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PenAndPaperDay.Data.Entites
{
    [Table("Newsletter")]
    public class Newsletter : Entity
    {
        public string Email { get; set; }
    }
}
