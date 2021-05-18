using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Train_project.Models
{
    public class AdminLogin
    {
        [Key]
        public int admin_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
