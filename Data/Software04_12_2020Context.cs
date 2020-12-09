using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Software04._12._2020.Models;

namespace Software04._12._2020.Data
{
    public class Software04_12_2020Context : DbContext
    {
        public Software04_12_2020Context (DbContextOptions<Software04_12_2020Context> options)
            : base(options)
        {
        }

        public DbSet<Software04._12._2020.Models.Module> Module { get; set; }
    }
}
