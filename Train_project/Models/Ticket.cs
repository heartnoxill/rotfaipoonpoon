using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Train_project.Models
{
    public class Ticket
    {
        [Key]
        public int T_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime date_issued { get; set; }

        public int PassengerP_id { get; set; } // Passenger id
        [ForeignKey("PassengerP_id")]
        public virtual Passenger Passenger { get; set; } // Fk in Passenger.cs

        public int TrainTR_id { get; set; } // Train id
        [ForeignKey("TrainTR_id")]
        public virtual Train Train { get; set; } // Fk in Train

        public int ClassC_id { get; set; } // Class id
        [ForeignKey("ClassC_id")]
        public virtual Class Class { get; set; } // Fk in class

        public int RouteR_id { get; set; } // Route id
        [ForeignKey("RouteR_id")]
        public virtual Route Route { get; set; } // Fk in Route.cs

        public int? ScheduleQ_id { get; set; } // Q_id (schedule id)
        [ForeignKey("ScheduleQ_id")]
        public virtual Schedule Schedule { get; set; } // Fk in schedule.cs

        public int PromotionPromotion_id { get; set; } // promotion id
        [ForeignKey("PromotionPromotion_id")]
        public virtual Promotion Promotion { get; set; } // Fk in Promotion
        
    }
}
