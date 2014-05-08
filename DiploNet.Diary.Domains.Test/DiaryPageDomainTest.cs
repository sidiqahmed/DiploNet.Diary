using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace DiploNet.Diary.Domains.Test
{
    [TestClass]
    public class DiaryPageDomainTest
    {
        private TestContext _testContext;
        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestInitialize]
        public void DiaryPageDomainTestInitialize()
        {
            var kernel = new StandardKernel(
                new DataAccess.Mock.DependencyInjection.DataAccessMockNinjectModule(),
                new Domains.DependencyInjection.DomainNinjectModule());

            var domain = kernel.Get<IDiaryPageDomain>();
            TestContext.Properties.Add("Domain", domain);
        }

        [TestMethod]
        public void Can_GetAll()
        {
            // Arrange
            var domain =
                TestContext.Properties["Domain"] as IDiaryPageDomain;

            // Act
            var actual = domain.GetAll();

            // Assert
            Assert.IsNotNull(actual);
        }
    }
}
