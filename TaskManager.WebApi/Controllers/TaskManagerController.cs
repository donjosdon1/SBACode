using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CaseStudy.BusinessLayer;
using CaseStudy.Entities;

namespace CaseStudy.WebApi.Controllers
{
    public class TaskManagerController : ApiController
    {
        public BL bl = new BL();

        [HttpPost]
        [Route("api/AddTaskwithParent")]
        public int AddTaskwithParent([FromBody] TaskandParent tp)
        {
            Tasks tasks = new Tasks();
            tasks.task = tp.task;
            tasks.parent_id = tp.parent_id;
            tasks.priority = tp.priority;
            if (tp.project_id != 0)
                tasks.project_id = tp.project_id;
            else
                tasks.project_id = null; 
            tasks.start_date = tp.start_date;
            tasks.end_date = tp.end_date;
            return bl.AddTaskwithParent(tasks, tp.isparent, tp.user_id);
        }
        [HttpPost]
        [Route("api/EditTask")]
        public int UpdateTask([FromBody] TaskandParent tp)
        {
            Tasks tasks = new Tasks();
            tasks.task_id = tp.task_id;
            tasks.task = tp.task;
            tasks.parent_id = tp.parent_id;
            tasks.priority = tp.priority;
            tasks.start_date = tp.start_date;
            tasks.end_date = tp.end_date;
            return bl.UpdateTask(tasks);
        }


        [HttpGet]
        [Route("api/GetAllTasks")]
        public IHttpActionResult GetAllTasks()

        {
            return Ok(JsonConvert.SerializeObject(bl.GetAllTasks(), Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
                ));
        }
        [HttpGet]
        [Route("api/GetAllTasksJoin")]
        public IHttpActionResult  GetAllTasksJoin()
        {
            //return Ok(JsonConvert.SerializeObject(bl.GetAllTasksJoin(), Formatting.None, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //}
            //    ));
            List<TaskandParent> t= bl.GetAllTasksJoin().ToList<TaskandParent>();
            return Ok(t);
        }
        [HttpGet]
        [Route("api/GetTaskByID/{taskid}")]
        public IHttpActionResult GetTaskByID(Int64 taskid)
        {
            //return Ok(JsonConvert.SerializeObject(bl.GetTaskByID(taskid), Formatting.None, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //}
            //    ));
            List<TaskandParent> t = bl.GetTaskByID(taskid).ToList<TaskandParent>();
            return Ok(t);
        }

        //[HttpPost]
        //[Route("api/RemoveTaskByID")]
        //public int RemoveTask(Int64 taskid)
        //{
        //    return bl.RemoveTask(taskid);
        //}

        [HttpGet]
        [Route("api/EndTask/{taskid}")]
        public int EndTask(Int64 taskid)
        {            
            return bl.EndTask(taskid);
        }
    }
}
