using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.DTOs;
using TaskApp.Core.Managers.Contracts;
using TaskApp.Tests.Mock;
using TaskApp.Web.Controllers;

namespace TaskApp.Tests
{
    [TestClass]
    public class UnitTestsEmployees
    {
        private EmployeesMock data;

        public UnitTestsEmployees()
        {
            this.data = new EmployeesMock();
        }

        [TestMethod]
        public async Task GetEmployees_Should_Return_Collection_With_Members_From_Company_With_ID_2()
        {
            var moq = new Mock<IEmployeeManager>();
            moq.Setup(x => x.All(2)).ReturnsAsync(this.data.GetAllEmployees(2));

            var controller = new EmployeesController(moq.Object);

            var employees = await controller.GetEmployees(2);


            Assert.AreEqual(2, employees.FirstOrDefault().CompanyId);
        }

        [TestMethod]
        public async Task GetEmployee_Should_Return_OK()
        {
            var moq = new Mock<IEmployeeManager>();
            moq.Setup(x => x.Get(2)).ReturnsAsync(this.data.GetEmployee(2));

            var controller = new EmployeesController(moq.Object);

            var result = await controller.GetEmployee(2) as OkObjectResult;


            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(2, (result.Value as EmployeeDto).EmployeeId);
        }

        [TestMethod]
        public async Task GetEmployee_Should_Return_Bad_Request()
        {
            var moq = new Mock<IEmployeeManager>();
            moq.Setup(x => x.Get(0)).ReturnsAsync(this.data.GetEmptyEmployee());

            var controller = new EmployeesController(moq.Object);

            var result = await controller.GetEmployee(0) as BadRequestObjectResult;


            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
        }


        [TestMethod]
        public async Task Update_Employee_Should_Return_NotFound()
        {
            var moq = new Mock<IEmployeeManager>();
            moq.Setup(x => x.Update(this.data.GetFirstEmployee()))
                .ThrowsAsync(new Exception());

            var employee = this.data.GetFirstEmployee();
            employee.EmployeeId = -1;

            var controller = new EmployeesController(moq.Object);

            var result = await controller.PutEmployee(-1, employee) as NotFoundResult;

            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [TestMethod]
        public async Task Update_Employee_Should_Return_NoContent()
        {
            var moq = new Mock<IEmployeeManager>();
            moq.Setup(x => x.Update(this.data.GetFirstEmployee()))
                .ReturnsAsync(this.data.GetFirstEmployee());

            var controller = new EmployeesController(moq.Object);

            var result = await controller.PutEmployee(1, this.data.GetFirstEmployee()) as NoContentResult;

            Assert.AreEqual(StatusCodes.Status204NoContent, result.StatusCode);
        }

        [TestMethod]
        public async Task Create_Employee_Should_Return_NotFound()
        {
            var moq = new Mock<IEmployeeManager>();
            moq.Setup(x => x.Create(this.data.GetFirstEmployee()))
                .ThrowsAsync(new Exception());

            var controller = new EmployeesController(moq.Object);
            var emp = this.data.GetFirstEmployee();
            emp.CompanyId = 9999;

            var result = await controller.PostEmployee(emp) as NotFoundResult;

            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [TestMethod]
        public async Task Create_Employee_Should_Be_Ok()
        {
            var moq = new Mock<IEmployeeManager>();
            moq.Setup(x => x.Create(this.data.GetFirstEmployee()))
                .ReturnsAsync(this.data.GetFirstEmployee());

            var controller = new EmployeesController(moq.Object);

            var result = await controller.PostEmployee(this.data.GetFirstEmployee()) as CreatedAtActionResult;

            Assert.AreEqual(StatusCodes.Status201Created, result.StatusCode);
        }
    }
}
