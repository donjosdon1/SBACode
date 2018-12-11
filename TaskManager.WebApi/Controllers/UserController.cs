using CaseStudy.BusinessLayer;
using CaseStudy.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CaseStudy.WebApi.Controllers
{
    public class UserController : ApiController
    {
        public BL bl = new BL();
        [HttpPost]
        [Route("api/AddUser")]
        public int AddUser([FromBody] UserDetails user)
        {
            Entities.User u = new Entities.User();
            u.employee_id = user.employee_id;
            u.firstname = user.firstname;
            u.lastname = user.lastname;
            u.project_id = null;
            u.task_id = null;
            return bl.AddUser(u);
        }
        [HttpPost]
        [Route("api/EditUser")]
        public int EditUser([FromBody] CaseStudy.Entities.User user)
        {
            return bl.EditUser(user);
        }
        //[HttpPost]
        //[Route("api/RemoveUser")]
        //public int RemoveUser([FromBody] CaseStudy.Entities.User user)
        //{
        //    return bl.RemoveUser(user);
        //}
        [HttpGet]
        [Route("api/GetAllUsers")]
        public IQueryable<UserDetails> GetAllUsers()
        {
            var a= bl.GetAllUsers().AsQueryable<UserDetails>();
            return a;
        }
        [HttpGet]
        [Route("api/GetUser/{user_id}")]
        public IQueryable<CaseStudy.Entities.UserDetails> GetUser(Int64 user_id)
        {
            return bl.GetUser(user_id);
        }
    }
}