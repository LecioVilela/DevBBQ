using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DevBBQ.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevBBQ.Infrastructure.Persistence
{
    public class DevBBQDbContext : DbContext
    {
        public DevBBQDbContext(DbContextOptions<DevBBQDbContext> options) : base(options)
        {

        }
        public DbSet<BBQ> BBQs { get; set; }
        public DbSet<BBQParticipants> BBQParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}