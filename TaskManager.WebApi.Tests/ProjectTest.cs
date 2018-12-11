using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaseStudy.WebApi.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Moq;
using CaseStudy.Entities;
using System.Diagnostics;

namespace CaseStudy.WebApi.Tests
{
    [TestClass]
    public class ProjectTest
    {
        [TestMethod]
        public void AddProject()
        {
            ProjectController controller = new ProjectController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/AddProject";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            projectandmanager p = new projectandmanager();
            p.project = "Project " + DateTime.Now.ToLongDateString();
            p.priority = 10;
            p.user_id = 1;
            p.startdate = DateTime.Now;
            p.enddate = DateTime.Now.AddDays(10);            
            var response = controller.AddProject(p);
            Trace.Write(response);
        }
        [TestMethod]
        public void EditProject()
        {
            ProjectController controller = new ProjectController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/EditProject";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            projectandmanager p = new projectandmanager();
            p.project_id = 2;
            p.project = "Project " + DateTime.Now.ToLongDateString();
            p.priority = 30;
            p.user_id = 2;
            p.startdate = DateTime.Now;
            p.enddate = DateTime.Now.AddDays(10);
            var response = controller.EditProject(p);
            Trace.Write(response);
        }
        //[TestMethod]
        //public void RemoveProject()
        //{
        //    ProjectController controller = new ProjectController();
        //    controller.Request = new HttpRequestMessage();
        //    controller.Configuration = new HttpConfiguration();

        //    string locationUrl = "http://localhost:55396/api/RemoveProject";

        //    // Create the mock and set up the Link method, which is used to create the Location header.
        //    // The mock version returns a fixed string.
        //    var mockUrlHelper = new Mock<UrlHelper>();
        //    mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
        //    controller.Url = mockUrlHelper.Object;

        //    // Act            
        //    projectandmanager p = new projectandmanager();
        //    p.project_id = 1;            
        //    var response = controller.RemoveProject(p);
        //    Trace.Write(response);
        //}
        [TestMethod]
        public void GetAllProjects()
        {
            ProjectController controller = new ProjectController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/getallprojects";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            var response = controller.GetAllProjects();
            Trace.Write(response);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
    }
}
