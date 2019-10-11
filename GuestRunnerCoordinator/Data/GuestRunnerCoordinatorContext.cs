using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GuestRunnerCoordinator.Models;

namespace GuestRunnerCoordinator.Models
{
    public class GuestRunnerCoordinatorContext : DbContext
    {
        public GuestRunnerCoordinatorContext (DbContextOptions<GuestRunnerCoordinatorContext> options)
            : base(options)
        {
        }

        public DbSet<GuestRunnerCoordinator.Models.Item> Item { get; set; }

        public DbSet<GuestRunnerCoordinator.Models.Check> Check { get; set; }

        public DbSet<GuestRunnerCoordinator.Models.CheckList> CheckList { get; set; }

        public DbSet<GuestRunnerCoordinator.Models.PaymentType> PaymentType { get; set; }

        public DbSet<GuestRunnerCoordinator.Models.Role> Role { get; set; }

        public DbSet<GuestRunnerCoordinator.Models.Category> Category { get; set; }
    }
}
