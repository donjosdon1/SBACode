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
    public class UserTest
    {
        [TestMethod]
        public void AddUser()
        {
            UserController controller = new UserController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            UserDetails u = new UserDetails();
            string locationUrl = "http://localhost:55396/api/AddUser";
            try
            {
                // Create the mock and set up the Link method, which is used to create the Location header.
                // The mock version returns a fixed string.
                var mockUrlHelper = new Mock<UrlHelper>();
                mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
                controller.Url = mockUrlHelper.Object;

                // Act            
                
                u.firstname = "FName" + DateTime.Now.ToLongDateString();
                u.lastname = "LName" + DateTime.Now.ToLongDateString();
                u.employee_id = "EmployeeID" + DateTime.Now.ToLongDateString();

                var response = controller.AddUser(u);
                Trace.Write(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                controller = null;
                locationUrl = null;
                u = null;
            }
        }
        [TestMethod]
        public void EditUser()
        {
            UserController controller = new UserController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            string locationUrl = "http://localhost:55396/api/EditUser";

            // Create the mock and set up the Link method, which is used to create the Location header.
            // The mock version returns a fixed string.
            var mockUrlHelper = new Mock<UrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
            controller.Url = mockUrlHelper.Object;

            // Act            
            User u = new User();
            u.user_id = 2;
            u.firstname = "FNameupdated" + DateTime.Now.ToLongDateString();
            u.lastname = "LName" + DateTime.Now.ToLongDateString();
            u.employee_id = "EmployeeID" + DateTime.Now.ToLongDateString();

            var response = controller.EditUser(u);
            Trace.Write(response);
        }
        //[TestMethod]
        //public void RemoveUser()
        //{
        //    UserController controller = new UserController();
        //    controller.Request = new HttpRequestMessage();
        //    controller.Configuration = new HttpConfiguration();

        //    string locationUrl = "http://localhost:55396/api/RemoveUser";

        //    // Create the mock and set up the Link method, which is used to create the Location header.
        //    // The mock version returns a fixed string.
        //    var mockUrlHelper = new Mock<UrlHelper>();
        //    mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
        //    controller.Url = mockUrlHelper.Object;

        //    // Act            
        //    User u = new User();
        //    u.user_id = 1;

        //    var response = controller.RemoveUser(u);
        //    Trace.Write(response);
        //}
        [TestMethod]
        public void GetUser()
        {
            UserController controller = new UserController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            UserDetails u = new UserDetails();
            string locationUrl = "http://localhost:55396/api/GetUser";
            try
            {
                // Create the mock and set up the Link method, which is used to create the Location header.
                // The mock version returns a fixed string.
                var mockUrlHelper = new Mock<UrlHelper>();
                mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
                controller.Url = mockUrlHelper.Object;

                // Act
                var response = controller.GetUser(2);
                Trace.Write(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                controller = null;
                locationUrl = null;
                u = null;
            }
        }
        [TestMethod]
        public void GetAllUsers()
        {
            UserController controller = new UserController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            UserDetails u = new UserDetails();
            string locationUrl = "http://localhost:55396/api/GetAllUsers";
            try
            {
                // Create the mock and set up the Link method, which is used to create the Location header.
                // The mock version returns a fixed string.
                var mockUrlHelper = new Mock<UrlHelper>();
                mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(locationUrl);
                controller.Url = mockUrlHelper.Object;

                // Act
                var response = controller.GetAllUsers();
                Trace.Write(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                controller = null;
                locationUrl = null;
                u = null;
            }
        }
    }
}
