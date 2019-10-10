using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRunnerCoordinator.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Quantity { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
    }
}
