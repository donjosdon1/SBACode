using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaseStudy.WebApi.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Moq;
using CaseStudy.Entities;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CaseStudy.WebApi.Tests
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void GetAllTasks()
        {
            TaskManagerController controller = new TaskManagerController();            
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/getalltasks";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            var response = controller.GetAllTasks();
            Trace.Write(((System.Web.Http.Results.OkNegotiatedContentResult<string>)response).Content);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);
            
        }
        [TestMethod]
        public void GetTasksJoin()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/GetAllTasksJoin";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            var response = controller.GetAllTasksJoin();
            Trace.Write("Records returned = " + ((System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.List<CaseStudy.Entities.TaskandParent>>)response).Content.Count);
            //Trace.Write(((System.Web.Http.Results.OkNegotiatedContentResult<string>)response).Content);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
        [TestMethod]
        public void GetTaskByID()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/GetTaskByID";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            var response = controller.GetTaskByID(1);
            Trace.Write("Records returned = "+ ((System.Web.Http.Results.OkNegotiatedContentResult<System.Collections.Generic.List<CaseStudy.Entities.TaskandParent>>)response).Content.Count);
            //Trace.Write(((System.Web.Http.Results.OkNegotiatedContentResult<string>)response).Content);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
        [TestMethod]
        public void AddTaskwithParent()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/AddTaskwithParent";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            TaskandParent t = new TaskandParent();
            t.task = "Task" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            t.isparent = 1;
            //t.priority = 10;
            //t.parent_id = 1;
            t.start_date = null;
            t.end_date = null;
            var response = controller.AddTaskwithParent(t);
            Trace.Write(response);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
        [TestMethod]
        public void UpdateTask()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/UpdateTask";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            TaskandParent t = new TaskandParent();
            t.task = "Task" + DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            t.isparent = 1;
            //t.priority = 10;
            //t.parent_id = 1;
            t.start_date = null;
            t.end_date = null;
            t.task_id = 1;
            var response = controller.UpdateTask(t);
            Trace.Write(response);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
        [TestMethod]
        public void EndTask()
        {
            TaskManagerController controller = new TaskManagerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/EndTask";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act                        
            var response = controller.EndTask(1);
            Trace.Write(response);
            // Assert
            //Assert.AreEqual(locationUrl, response.Headers.Location.AbsoluteUri);

        }
    }

}
