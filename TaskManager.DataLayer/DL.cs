using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudy.Entities;

namespace TaskManager.DataLayer
{
    public class DL
    {
        helpercontext context = new helpercontext();
        public int AddTaskwithParent(Tasks tasks)
        {
            return context.AddTaskwithParent(tasks);
        }
        public int UpdateTask(Tasks tasks)
        {
            return context.UpdateTask(tasks);
        }
        public List<Tasks> GetAllTasks()
        {
            return context.GetAllTasks();
        }

        public IQueryable<TaskandParent> GetAllTasksJoin()
        {
            return context.GetAllTasksJoin();
        }

        public List<TaskandParent> GetTask(Int64 taskid)
        {
            return context.GetTask(taskid);
        }

        public int RemoveTask(Int64 taskid)
        {
            return context.RemoveTask(taskid);
        }

        public int EndTask(Int64 taskid)
        {
            return context.EndTask(taskid);
        }
    }
}
