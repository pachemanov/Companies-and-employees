using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Core.DTOs;
using TaskApp.Core.Managers;
using TaskApp.Core.Managers.Contracts;
using TaskApp.Tests.Mock;
using TaskApp.Web.Controllers;

namespace TaskApp.Tests
{
    [TestClass]
    public class UnitTestsCompanies
    {
        private CompaniesMock data;

        public UnitTestsCompanies()
        {
            this.data = new CompaniesMock();
        }

        [TestMethod]
        public async Task GetCompanies_ShouldReturn_Collection_With_Members()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Companies()).ReturnsAsync(this.data.GetMockCompanies());

            var controller = new CompaniesController(moq.Object);

            IEnumerable<CompanyDto> companies = await controller.GetCompanies();

            Assert.AreEqual(3, companies.Count());
        }

        [TestMethod]
        public async Task GetCompany_Should_Return_BadRequest()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Find(0)).ReturnsAsync(this.data.GetNullInsteadCompany());

            var controller = new CompaniesController(moq.Object);

            var actionResult = await controller.GetCompany(0) as BadRequestObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task GetCompany_Should_Be_Ok()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Find(2)).ReturnsAsync(this.data.Find(2));

            var controller = new CompaniesController(moq.Object);

            var actionResult = await controller.GetCompany(2) as OkObjectResult;

            Assert.AreEqual(StatusCodes.Status200OK, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task Update_Existing_Value_With_Null_Should_Return_BadRequest()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Update(null))
                .ReturnsAsync(this.data.GetMockEmptyCompany());

            var controller = new CompaniesController(moq.Object);

            var actionResult = await controller.PutCompany(0, null) as BadRequestObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task Update_Existing_Value_With_Obj_Without_Name_Should_Return_BadRequest()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Update(this.data.GetMockEmptyCompany()))
                .ReturnsAsync(this.data.GetMockEmptyCompany());

            var controller = new CompaniesController(moq.Object);

            var actionResult = await controller.PutCompany(3, this.data.GetMockEmptyCompany()) as BadRequestObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task Update_Existing_Value_With_Diff_Id_Parameter_Should_Return_BadRequest()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Update(this.data.GetMockEmptyCompany()))
                .ReturnsAsync(this.data.GetMockEmptyCompany());

            var controller = new CompaniesController(moq.Object);

            var mockedCompany = this.data.GetFirstCompany();

            var actionResult = await controller.PutCompany(10, mockedCompany) as BadRequestResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task Update_Comp_Should_Be_Ok()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Update(this.data.GetFirstCompany()))
                .ReturnsAsync(this.data.GetFirstCompany());

            var controller = new CompaniesController(moq.Object);

            var mockedCompany = this.data.GetFirstCompany();

            var actionResult = await controller.PutCompany(1, mockedCompany) as NoContentResult;

            Assert.AreEqual(StatusCodes.Status204NoContent, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task Update_Comp_Should_Returns_NotFound()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Update(this.data.GetFirstCompany()))
                .ThrowsAsync(new Exception());

            var controller = new CompaniesController(moq.Object);

            var mockedCompany = this.data.GetFirstCompany();
            mockedCompany.CompanyId = 9999;

            var actionResult = await controller.PutCompany(9999, mockedCompany) as NotFoundObjectResult;

            Assert.AreEqual(StatusCodes.Status404NotFound, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task Post_Company_Without_Name_Should_Return_Bad_Request()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Create(this.data.GetMockEmptyCompany()))
                .ReturnsAsync(this.data.GetMockEmptyCompany());

            var controller = new CompaniesController(moq.Object);

            var mockedCompany = this.data.GetMockEmptyCompany();

            var actionResult = await controller.PostCompany(mockedCompany) as BadRequestObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task Post_Company_Should_Be_Ok()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Create(this.data.GetCompanyWithNameOnly()))
                .ReturnsAsync(this.data.GetCompanyWithNameOnly());

            var controller = new CompaniesController(moq.Object);

            var mockedCompany = this.data.GetCompanyWithNameOnly();

            var actionResult = await controller.PostCompany(mockedCompany) as CreatedAtActionResult;

            Assert.AreEqual(StatusCodes.Status201Created, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task Delete_Comp_With_Negative_Number_Should_Return_BadRequest()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Delete(0));
            var controller = new CompaniesController(moq.Object);

            var actionResult = await controller.DeleteCompany(0) as BadRequestObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        }

        [TestMethod]
        public async Task Delete_Comp_Should_Be_Ok()
        {
            var moq = new Mock<ICompanyManager>();
            moq.Setup(x => x.Delete(3))
                .Returns(Task.FromResult(3));
            var controller = new CompaniesController(moq.Object);

            var actionResult = await controller.DeleteCompany(3) as OkResult;

            Assert.AreEqual(StatusCodes.Status200OK, actionResult.StatusCode);
        }

    }
}
