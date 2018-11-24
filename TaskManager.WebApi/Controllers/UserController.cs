using CaseStudy.BusinessLayer;
using CaseStudy.Entities;
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
        public int AddUser([FromBody] User user)
        {            
            return bl.AddUser(user);
        }
        [HttpPost]
        [Route("api/EditUser")]
        public int EditUser([FromBody] User user)
        {
            return bl.EditUser(user);
        }
        [HttpPost]
        [Route("api/RemoveUser")]
        public int RemoveUser([FromBody] User user)
        {
            return bl.RemoveUser(user);
        }
        [HttpGet]
        [Route("api/GetAllUsers")]
        public IQueryable<User> GetAllUsers()
        {
            return bl.GetAllUsers();
        }
        [HttpPost]
        [Route("api/GetUser")]
        public IQueryable<User> GetUser(Int64 user_id)
        {
            return bl.GetUser(user_id);
        }
    }
}