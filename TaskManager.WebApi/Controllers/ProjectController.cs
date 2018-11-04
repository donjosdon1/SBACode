﻿using CaseStudy.BusinessLayer;
using CaseStudy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CaseStudy.WebApi.Controllers
{
    public class ProjectController : ApiController
    {
        public BL bl = new BL();
        [HttpPost]
        [Route("api/AddProject")]
        public int AddProject(projectandmanager p)
        {
            Project proj = new Project();
            proj.project = p.project;
            proj.priority = p.priority;
            proj.startdate = p.startdate;
            proj.enddate = p.enddate;            
            return bl.AddProject(proj, p.user_id);
        }
        [HttpPost]
        [Route("api/EditProject")]
        public int EditProject(projectandmanager proj)
        {
            return bl.EditProject(proj);
        }
        [HttpPost]
        [Route("api/RemoveProject")]
        public int RemoveProject(Project proj)
        {
            return bl.RemoveProject(proj);
        }
    }
}
