using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Train_project.Models
{
    public class Schedule
    {
        [Key]
        public int Q_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Departure_date { get; set; }

        [DataType(DataType.Time)]
        public DateTime CheckIn_time { get; set; }

        [DataType(DataType.Time)]
        public DateTime Departure_time { get; set; }

        [DataType(DataType.Time)]
        public DateTime Estimated_ToA { get; set; }

        public int RouteR_id { get; set; } // Route id
        [ForeignKey("RouteR_id")]
        public virtual Route Route { get; set; } // Fk in route.cs

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
