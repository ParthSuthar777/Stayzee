﻿using Microsoft.EntityFrameworkCore;
using Stayzee.Domain.Entities;

namespace Stayzee.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Villa> Villas { get; set; }

    }
}
