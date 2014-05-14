using System.Linq;
using DiploNet.Diary.DataAccess.Mock;
using DiploNet.Diary.Web.MVCSite.Controllers;
using DiploNet.Diary.Web.MVCSite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace DiploNet.Diary.Web.Site.Test
{
    [TestClass]
    public class DiaryControllerTest
    {
        private TestContext _testContext;
        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestInitialize]
        public void DiaryControllerTestInitialize()
        {
            var kernel = new StandardKernel(
                new Diary.BusinessObject.DependencyInjection.BusinessObjectNinjectModule(),
                new Diary.DataAccess.Mock.DependencyInjection.DataAccessMockNinjectModule(),
                new Diary.Domains.DependencyInjection.DomainNinjectModule());
            TestContext.Properties.Add("Kernel", kernel);

            var controller = kernel.Get<DiaryController>();
            TestContext.Properties.Add("Controller", controller);
        }

        [TestMethod]
        public void Can_Get_Index()
        {
            // Arrange
            var controller =
                TestContext.Properties["Controller"] as DiaryController;

            var expected = DbMock.GetDb();

            // Act
            var result = controller.Index().Model as DiaryModel;

            // Assert
            Assert.AreEqual(result.DiaryPages.Count(), expected.Count());
        }
    }
}
