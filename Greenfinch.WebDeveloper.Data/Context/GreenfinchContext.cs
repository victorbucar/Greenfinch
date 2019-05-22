using Greenfinch.WebDeveloper.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Greenfinch.WebDeveloper.Data.Context
{
    public class GreenfinchContext : DbContext
    {
        public GreenfinchContext(DbContextOptions<GreenfinchContext> options): base(options)
        {
        }

        public DbSet<Newsletter> Newsletter { get; set; }
    }
}
