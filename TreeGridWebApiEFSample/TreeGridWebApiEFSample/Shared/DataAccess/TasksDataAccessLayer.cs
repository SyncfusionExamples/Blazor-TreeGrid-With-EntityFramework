using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeGridWebApiEFSample.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace TreeGridWebApiEFSample.Shared.DataAccess
{
    public class TasksDataAccessLayer
    {
        TasksContext treedb = new TasksContext();

        //To Get all Task details   
        public IEnumerable<Shared.Models.Task> GetAllRecords()
        {
            try
            {
                return treedb.Tasks.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Tasks record     
        public void AddTask(Shared.Models.Task task)
        {
            try
            {

                treedb.Tasks.Add(task);

                treedb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar Tasks    
        public void UpdateTask(Shared.Models.Task task)
        {
            try
            {
                treedb.Entry(task).State = EntityState.Modified;
                treedb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Tasks    
        public Shared.Models.Task GetTaskData(int id)
        {
            try
            {
                Shared.Models.Task task = treedb.Tasks.Find(id);
                return task;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Tasks    
        public void DeleteTask(int id)
        {
            try
            {
                Shared.Models.Task emp = treedb.Tasks.Find(id);
                treedb.Tasks.Remove(emp);
                treedb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
