using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRunnerCoordinator.Models
{
    public class Check
    {
        [Key]
        public int CheckId { get; set; }
        public int UserId { get; set; }
        public DateTime OpenTime { get; set; }
        public Boolean Closed { get; set; }
        public int PaymentTypeId { get; set; }
        public string Room { get; set; }
    }
}
