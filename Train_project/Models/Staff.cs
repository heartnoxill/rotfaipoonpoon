using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Train_project.Models
{
    public class Staff
    {
        [Key]
        public int ST_id { get; set; }
        public string ST_fname { get; set; }
        public string ST_lname { get; set; }
        public string ST_resp { get; set; }

        [DataType(DataType.Date)]
        public DateTime ST_DOB { get; set; }

        public int TrainTR_id { get; set; } // Train PK
        [ForeignKey("TrainTR_id")]
        public virtual Train Train { get; set; } // Fk in Train.cs
    }
}
