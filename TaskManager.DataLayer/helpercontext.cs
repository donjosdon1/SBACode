using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudy.Entities;

namespace CaseStudy.DataLayer
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
            modelBuilder.Entity<Tasks>()
                .HasOptional(p => p.Project);
            modelBuilder.Entity<CaseStudy.Entities.User>()
                .HasOptional(p => p.Project);
            modelBuilder.Entity<CaseStudy.Entities.User>()
                .HasOptional(p => p.Tasks);
        }

        public DbSet<ParentTask> Parenttask { get; set; }
        public DbSet<Tasks> Task { get; set; }
        public DbSet<CaseStudy.Entities.User> users { get; set; }
        public DbSet<Project> projects { get; set; }

        public int AddTaskwithParent(Tasks tasks, int isparent, Int64? user_id)
        {
            if (isparent==1)
            {
                ParentTask ptask = new ParentTask();
                ptask.parent_task = tasks.task;
                Parenttask.Add(ptask);
            }
            Task.Add(tasks);
            if(user_id != null && user_id !=0)
            {
                User u = users.Find(user_id);
                if(u!=null)
                {
                    u.project_id = tasks.project_id;
                    u.task_id = tasks.task_id;
                }
            }

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
                         join parenttask in Parenttask on task.parent_id equals parenttask.parent_id into a
                         from aa in a.DefaultIfEmpty()
                         join p in projects on task.project_id equals p.project_id into b
                         from bb in b.DefaultIfEmpty()
                         join u in users on task.task_id equals u.task_id into details
                         from m in details.DefaultIfEmpty()
                         select new TaskandParent
                         {
                             task_id = task.task_id,
                             parent_id = aa.parent_id,
                             task = task.task,
                             parent_task = (aa.parent_task != null ? aa.parent_task : string.Empty),
                             start_date = task.start_date,
                             end_date = task.end_date,
                             priority = task.priority,
                             taskended = task.taskended,
                             project_id = task.project_id,
                             project = task.project_id == null ? string.Empty : bb.project,
                             username = m.firstname + " " + m.lastname ,
                             user_id = m.user_id
                         }).Where(x => x.task_id == taskid).AsQueryable();
            return query.ToList<TaskandParent>();
        }
        //public int RemoveTask(Int64 taskid)
        //{
        //    var query = (from task in Task
        //                 where task.parent_id == taskid
        //                 select new
        //                 {
        //                     task_id = task.task_id
        //                 }
        //                 );
        //    if (query.ToList().Count > 0)
        //    {
        //        return 101;//Dependency exists as this task is referred as ParentId for another tasks
        //    }
        //    else
        //    {
        //        Parenttask.Remove(Parenttask.Find(taskid));
        //        Task.Remove(Task.Find(taskid));
        //        return this.SaveChanges();
        //    }
        //}
        public int EndTask(Int64 taskid)
        {
            Tasks t = Task.Find(taskid);
            t.taskended = 1;
            return this.SaveChanges();
        }
        public int AddUser(CaseStudy.Entities.User user)
        {            
            users.Add(user);
            return this.SaveChanges();
        }
        public int EditUser(CaseStudy.Entities.User user)
        {
            if (user.user_id > 0)
            {
                User u = users.Find(user.user_id);
                u.firstname = user.firstname;
                u.lastname = user.lastname;
                u.employee_id = user.employee_id;
                u.task_id = user.task_id;
                u.project_id = user.project_id;
                return this.SaveChanges();
            }
            else
                return 0;
        }
        //public int RemoveUser(CaseStudy.Entities.User user)
        //{
        //    if (user.user_id > 0)
        //    {
        //        CaseStudy.Entities.User u = users.Find(user.user_id);
        //        users.Remove(u);
        //        return this.SaveChanges();
        //    }
        //    else
        //        return 0;
        //}
        public int AddProject(Project proj, Int64 user_id)
        {
            proj = projects.Add(proj);
            if (proj.project_id > 0 && user_id>0 )
            {
                CaseStudy.Entities.User u = users.Find(user_id);
                u.project_id = proj.project_id;
            }
            return this.SaveChanges();
        }
        public int EditProject(projectandmanager proj)
        {
            if (proj.project_id > 0)
            {
                Project project = projects.Find(proj.project_id);
                project.project = proj.project;
                project.startdate = proj.startdate;
                project.enddate = proj.enddate;
                project.priority = proj.priority;  
                if(proj.user_id>0)
                {
                    CaseStudy.Entities.User u = users.Find(proj.user_id);
                    u.project_id = proj.project_id;
                }
                return this.SaveChanges();
            }
            else
                return 0;
        }
        public int RemoveProject(Project proj)
        {
            if (proj.project_id > 0)
            {
                List<User> u = users.Where(e => e.project_id == proj.project_id).ToList<User>();
                if (u != null)
                    foreach(var uu in u)
                    uu.project_id = null;
                List<Tasks> t = Task.Where(e => e.project_id == proj.project_id).ToList<Tasks>();
                if (t != null)
                    foreach (var tt in t)
                        tt.project_id = null;
                proj = projects.Find(proj.project_id);
                projects.Remove(proj);
                return this.SaveChanges();
            }
            else
                return 0;
        }
        public List<UserDetails> GetAllUsers()
        {
            try
            {
                var query = (from u in users
                             select new UserDetails
                             {
                                 user_id = u.user_id,
                                 firstname = u.firstname,
                                 lastname = u.lastname,
                                 employee_id = u.employee_id
                             });
                return query.ToList<UserDetails>();
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
        public IQueryable<CaseStudy.Entities.UserDetails> GetUser(Int64 user_id)
        {
            var query = (from u in users
                         select new CaseStudy.Entities.UserDetails
                         {
                             user_id = u.user_id,
                             firstname = u.firstname,
                             lastname = u.lastname,
                             employee_id = u.employee_id
                         }).Where(e=>e.user_id==user_id).AsQueryable();
            return query;
        }

        public IQueryable<ProjectDetails> GetAllProjects()
        {
            var query = (from proj in projects
                         join task in Task on proj.project_id equals task.project_id into details
                         from m in details.DefaultIfEmpty()
                         select new ProjectDetails
                         {
                             project_id = proj.project_id,
                             project = proj.project,
                             startdate = proj.startdate,
                             enddate = proj.enddate,
                             priority = proj.priority,
                             numberoftasks = details.Count(),
                             Completed = "No"
                             }).Distinct().AsQueryable();
                return query;
        }
        public IQueryable<ProjectDetails> GetProjectByID(Int64 project_id)
        {
            var query = (from proj in projects
                         join task in Task on proj.project_id equals task.project_id into details
                         from m in details.DefaultIfEmpty()
                         select new ProjectDetails
                         {
                             project_id = proj.project_id,
                             project = proj.project,
                             startdate = proj.startdate,
                             enddate = proj.enddate,
                             priority = proj.priority,
                             numberoftasks = details.Count(),
                             Completed = "No"
                         }).Where(x=>x.project_id==project_id).AsQueryable();
            return query;
        }
    }
    
}
