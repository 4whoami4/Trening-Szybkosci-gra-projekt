using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Clicky_Game_WPF_MOO_ICT.Entities
{
    public class ClickyGameDbContext : DbContext
    {
        public string DbPath
        {
            get
            {
                var folder = Environment.SpecialFolder.MyDocuments;
                var path = Environment.GetFolderPath(folder);
                return Path.Combine(path, "ClickyGame.db");
            }
        }

        public DbSet<Score> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>(mb =>
            {
                mb.HasKey(s => s.Id);
            });
        }
    }
}
