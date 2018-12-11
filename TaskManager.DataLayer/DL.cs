using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudy.Entities;

namespace CaseStudy.DataLayer
{
    public class DL
    {
        helpercontext context = new helpercontext();
        public int AddTaskwithParent(Tasks tasks, int isparent, Int64? user_id)
        {
            return context.AddTaskwithParent(tasks, isparent, user_id);
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

        //public int RemoveTask(Int64 taskid)
        //{
        //    return context.RemoveTask(taskid);
        //}

        public int EndTask(Int64 taskid)
        {
            return context.EndTask(taskid);
        }

        public int AddUser(CaseStudy.Entities.User user)
        {
            return context.AddUser(user);
        }
        public int EditUser(CaseStudy.Entities.User user)
        {
            return context.EditUser(user);
        }
        //public int RemoveUser(CaseStudy.Entities.User user)
        //{
        //    return context.RemoveUser(user);
        //}
        public int AddProject(Project proj, Int64 user_id)
        {
            return context.AddProject(proj, user_id);
        }
        public int EditProject(projectandmanager proj)
        {
            return context.EditProject(proj);
        }
        public int RemoveProject(Project proj)
        {
            return context.RemoveProject(proj);
        }
        public List<UserDetails> GetAllUsers()
        {
            return context.GetAllUsers();
        }
        public IQueryable<CaseStudy.Entities.UserDetails> GetUser(Int64 user_id)
        {
            return context.GetUser(user_id);
        }
        public IQueryable<ProjectDetails> GetAllProjects()
        {
            return context.GetAllProjects();
        }
        public IQueryable<ProjectDetails> GetProjectByID(Int64 project_id)
        {
            return context.GetProjectByID(project_id);
        }
    }
}
