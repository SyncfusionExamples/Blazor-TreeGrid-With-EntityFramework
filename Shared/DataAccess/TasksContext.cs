using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace TreeGrdiWithEF.Shared.DataAccess
{
    public class TasksContext: DbContext
    {
        public virtual DbSet<Shared.Models.Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var basePath = Directory.GetCurrentDirectory();
                var candidate1 = Path.Combine(basePath, "Shared", "App_Data", "TreeGridDB.mdf");
                var candidate2 = Path.Combine(basePath, "App_Data", "TreeGridDB.mdf");
                var dbFile = File.Exists(candidate1) ? candidate1 : candidate2;

                var conn = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbFile};Integrated Security=True;Connect Timeout=30";
                optionsBuilder.UseSqlServer(conn, o => o.EnableRetryOnFailure());
            }
        }
    }
}
