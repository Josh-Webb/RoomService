﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestRunnerCoordinator.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AccNum { get; set; }
        public int UserId { get; set; }
    }
}
