using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudy.DataLayer;
using CaseStudy.Entities;

namespace CaseStudy.BusinessLayer
{
    public class BL
    {
        public DL dl = new DL();
        public int AddTaskwithParent(Tasks tasks)
        {
            return dl.AddTaskwithParent(tasks);
        }
        public int UpdateTask(Tasks tasks)
        {
            return dl.UpdateTask(tasks);
        }
        public List<Tasks> GetAllTasks()
        {
            return dl.GetAllTasks();
        }
        public IQueryable<TaskandParent> GetAllTasksJoin()
        {
            return dl.GetAllTasksJoin();
        }
        public List<TaskandParent> GetTaskByID(Int64 taskid)
        {
            return dl.GetTask(taskid);
        }
        public int RemoveTask(Int64 taskid)
        {
            return dl.RemoveTask(taskid);
        }
        public int EndTask(Int64 taskid)
        {
            return dl.EndTask(taskid);
        }
    }
}
