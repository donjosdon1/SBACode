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
        public int AddTaskwithParent(Tasks tasks, int isparent, Int64? user_id)
        {
            return dl.AddTaskwithParent(tasks, isparent, user_id);
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
        //public int RemoveTask(Int64 taskid)
        //{
        //    return dl.RemoveTask(taskid);
        //}
        public int EndTask(Int64 taskid)
        {
            return dl.EndTask(taskid);
        }
        public int AddUser(CaseStudy.Entities.User user)
        {
            return dl.AddUser(user);
        }
        public int EditUser(CaseStudy.Entities.User user)
        {
            return dl.EditUser(user);
        }
        //public int RemoveUser(CaseStudy.Entities.User user)
        //{
        //    return dl.RemoveUser(user);
        //}
        public int AddProject(Project proj, Int64 user_id)
        {
            return dl.AddProject(proj, user_id);
        }
        public int EditProject(projectandmanager proj)
        {
            return dl.EditProject(proj);
        }
        public int RemoveProject(Project proj)
        {
            return dl.RemoveProject(proj);
        }
        public List<UserDetails> GetAllUsers()
        {
            return dl.GetAllUsers();
        }
        public IQueryable<CaseStudy.Entities.UserDetails> GetUser(Int64 user_id)
        {
            return dl.GetUser(user_id);
        }
        public IQueryable<ProjectDetails> GetAllProjects()
        {
            return dl.GetAllProjects(); 
        }
        public IQueryable<ProjectDetails> GetProjectByID(Int64 project_id)
        {
            return dl.GetProjectByID(project_id);
        }
    }
}
