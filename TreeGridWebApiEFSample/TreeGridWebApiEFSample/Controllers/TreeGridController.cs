using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreeGridWebApiEFSample.Shared.Models;
using TreeGridWebApiEFSample.Shared.DataAccess;
using Microsoft.Extensions.Primitives;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;


namespace TreeGridWebApiEFSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TreeGridController : ControllerBase
    {
        TasksDataAccessLayer db = new TasksDataAccessLayer();

        // GET: api/<TreeGridController>
        [HttpGet]
        public object Get()
        {
            var queryString = Request.Query;
            IQueryable<TreeGridWebApiEFSample.Shared.Models.Task> data1 = db.GetAllRecords().AsQueryable();
            if (queryString.Keys.Contains("$filter") && !queryString.Keys.Contains("$top"))
            {
                StringValues filter;
                queryString.TryGetValue("$filter", out filter);
                int fltr = Int32.Parse(filter[0].ToString().Split("eq")[1]);
                data1 = data1.Where(f => f.ParentID == fltr).AsQueryable();

                return new { Items = data1, Count = data1.Count() };
            }
            if (queryString.Keys.Contains("$select"))
            {
                data1 = (from ord in data1
                         select new TreeGridWebApiEFSample.Shared.Models.Task
                         {
                             ParentID = ord.ParentID
                         }
                        );
                return data1;
            }

            data1 = data1.Where(p => p.ParentID == null);
            var count = data1.Count();

            if (queryString.Keys.Contains("$inlinecount"))
            {
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data1.Count();
                return new { Items = data1.Skip(skip).Take(top), Count = count };
            }
            else
            {
                return data1;
            }
        }

        // GET api/<TreeGridController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public object Post([FromBody]TreeGridWebApiEFSample.Shared.Models.Task Task)
        {

            IQueryable<TreeGridWebApiEFSample.Shared.Models.Task> data1 = db.GetAllRecords().AsQueryable();
            var i = 0;
            for (; i < data1.ToList().Count; i++)
            {
                if (data1.ToList()[i].TaskID == Task.ParentID)
                {
                    if (data1.ToList()[i].IsParent == null)
                    {
                        data1.ToList()[i].IsParent = true;
                    }
                    break;

                }
            }
            db.AddTask(Task);
            return Task;

        }
        public int FindChildRecords(int? id)
        {
            var count = 0;
            IQueryable<TreeGridWebApiEFSample.Shared.Models.Task> data1 = db.GetAllRecords().AsQueryable();
            for (var i = 0; i < data1.ToList().Count; i++)
            {
                if (data1.ToList()[i].ParentID == id)
                {
                    count++;
                    count += FindChildRecords(data1.ToList()[i].TaskID);
                }
            }
            return count;
        }

        [HttpPut]
        public object Put([FromBody]TreeGridWebApiEFSample.Shared.Models.Task Task)
        {
            IQueryable<TreeGridWebApiEFSample.Shared.Models.Task> data2 = db.GetAllRecords().AsQueryable();
            TreeGridWebApiEFSample.Shared.Models.Task val = data2.Where(or => or.TaskID == Task.TaskID).FirstOrDefault();
            val.TaskID = Task.TaskID;
            val.TaskName = Task.TaskName;
            db.UpdateTask(val);
            return val;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteTask(id);
        }
    }
}
