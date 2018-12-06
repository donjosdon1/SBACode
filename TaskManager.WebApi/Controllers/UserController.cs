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
        public int AddUser([FromBody] CaseStudy.Entities.User user)
        {            
            return bl.AddUser(user);
        }
        [HttpPost]
        [Route("api/EditUser")]
        public int EditUser([FromBody] CaseStudy.Entities.User user)
        {
            return bl.EditUser(user);
        }
        [HttpPost]
        [Route("api/RemoveUser")]
        public int RemoveUser([FromBody] CaseStudy.Entities.User user)
        {
            return bl.RemoveUser(user);
        }
        [HttpGet]
        [Route("api/GetAllUsers")]
        public IQueryable<UserDetails> GetAllUsers()
        {
            var a= bl.GetAllUsers().AsQueryable<UserDetails>();
            return a;
        }
        [HttpPost]
        [Route("api/GetUser")]
        public IQueryable<CaseStudy.Entities.User> GetUser(Int64 user_id)
        {
            return bl.GetUser(user_id);
        }
    }
}