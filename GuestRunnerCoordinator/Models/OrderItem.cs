using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRunnerCoordinator.Models
{
    public class OrderItem
    {
        public int ChequeId { get; set; }
        
        public int ItemId { get; set; }
    }
}
