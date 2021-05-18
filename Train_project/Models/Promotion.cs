using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Train_project.Models
{
    public class Promotion
    {
        [Key]
        public int Promotion_id { get; set; }

        public float Discount_percent { get; set; }

        [DataType(DataType.Date)]
        public DateTime Start_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Expiration_date { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
