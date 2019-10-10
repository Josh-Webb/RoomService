using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRunnerCoordinator.Models
{
    public class CheckList
    {
        [Key]
        public int ChecklistId { get; set; }
        public int Runner { get; set; }
        public Boolean Completed { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
