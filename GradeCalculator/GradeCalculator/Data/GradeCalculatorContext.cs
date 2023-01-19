using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GradeCalculator.Models;
using RegistrationLoginDemo.Models;

namespace GradeCalculator.Data
{
    public class GradeCalculatorContext : DbContext
    {
        public GradeCalculatorContext (DbContextOptions<GradeCalculatorContext> options)
            : base(options)
        {
        }

        public DbSet<GradeCalculator.Models.GCalculator> GCalculator { get; set; } = default!;

        public DbSet<RegistrationLoginDemo.Models.Registration> Registration { get; set; }

        public DbSet<RegistrationLoginDemo.Models.Login> Login { get; set; }

        public DbSet<GradeCalculator.Models.StudentLogin> StudentLogin { get; set; }
    }
}
