using Microsoft.EntityFrameworkCore;
using PhantasyBot.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhantasyBot.DataAccess.Database.Contexts
{
    public class MainContext : DbContext
    {
        private const string DbFile = "phantasybot.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"DataSource={DbFile};");
        }

        public DbSet<CommandLogEntity> CommandLogs { get; set; }
    }
}
