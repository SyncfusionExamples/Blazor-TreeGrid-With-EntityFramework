using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitHub\SyncfusionExamples\TreeGrid\treegrid-with-entityframework\tree1\TreeGrdiWithEF (2) 1\TreeGrdiWithEF\Shared\App_Data\TreeGridDB.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}
