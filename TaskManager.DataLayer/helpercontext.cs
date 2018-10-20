using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudy.Entities;

namespace TaskManager.DataLayer
{
    public class helpercontext : DbContext
    {
        public helpercontext() : base("name=helpercontext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            modelBuilder.Entity<Tasks>()
                .HasOptional(p => p.ParentTask)
                .WithRequired(t => t.Tasks);
        }

        public DbSet<ParentTask> Parenttask { get; set; }
        public DbSet<Tasks> Task { get; set; }

        public int AddTaskwithParent(Tasks tasks)
        {
            ParentTask ptask = new ParentTask();
            ptask.parent_task = tasks.task;
            Parenttask.Add(ptask);
            Task.Add(tasks);
            return this.SaveChanges();
        }

        public int UpdateTask(Tasks tasks)
        {
            if (tasks.task_id != 0)
            {
                Tasks t = Task.Find(tasks.task_id);
                t.parent_id = tasks.parent_id;
                t.task = tasks.task;
                t.priority = tasks.priority;
                t.start_date = tasks.start_date;
                t.end_date = tasks.end_date;
                t.taskended = 0;
                return this.SaveChanges();
            }
            else
                return 0;
        }

        public List<Tasks> GetAllTasks()
        {
            return Task.ToList<Tasks>();
        }

        public IQueryable<TaskandParent> GetAllTasksJoin()
        {
            var query = (from task in Task
                         join parenttask in Parenttask on task.parent_id equals parenttask.parent_id into details
                         from m in details.DefaultIfEmpty()
                         select new TaskandParent
                         {
                             task_id = task.task_id,
                             parent_id = task.parent_id,
                             task = task.task,
                             parent_task = (m.parent_task != null ? m.parent_task : string.Empty),
                             start_date = task.start_date,
                             end_date = task.end_date,
                             priority = task.priority,
                             taskended = task.taskended
                         }).AsQueryable();
            return query;
        }

        public List<TaskandParent> GetTask(Int64 taskid)
        {
            var query = (from task in Task
                         join parenttask in Parenttask on task.parent_id equals parenttask.parent_id into details
                         from m in details.DefaultIfEmpty()
                         select new TaskandParent
                         {
                             task_id = task.task_id,
                             parent_id = task.parent_id,
                             task = task.task,
                             parent_task = (m.parent_task!=null? m.parent_task : string.Empty),
                             start_date = task.start_date,
                             end_date = task.end_date,
                             priority = task.priority,
                             taskended = task.taskended
                         }).Where(x => x.task_id == taskid).AsQueryable();
            return query.ToList<TaskandParent>();
        }
        public int RemoveTask(Int64 taskid)
        {
            var query = (from task in Task
                         where task.parent_id == taskid
                         select new
                         {
                             task_id = task.task_id
                         }
                         );
            if (query.ToList().Count > 0)
            {
                return 101;//Dependency exists as this task is referred as ParentId for another tasks
            }
            else
            {
                Parenttask.Remove(Parenttask.Find(taskid));
                Task.Remove(Task.Find(taskid));
                return this.SaveChanges();
            }
        }
        public int EndTask(Int64 taskid)
        {
            Tasks t = Task.Find(taskid);
            t.taskended = 1;
            return this.SaveChanges();
        }
    }
    
}
