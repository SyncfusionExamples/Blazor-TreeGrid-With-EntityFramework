using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreeGridWebApiEFSample.Shared.Models
{
    public class Task
    {
        [Key]
        public int TaskID
        {
            get;
            set;
        }

        public string TaskName
        {
            get;
            set;
        }

        public DateTime? StartDate
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get;
            set;
        }

        public int? Duration
        {
            get;
            set;
        }

        public int? Progress
        {
            get;
            set;
        }
        public int? ParentID
        {
            get;
            set;
        }
        public bool? IsParent
        {
            get;
            set;
        }
    }
}
