using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.DataAccess.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Linq;

namespace DiploNet.Diary.DataAccess.FNHibernate.Test
{
    [TestClass]
    public class UnitOfWorkTest
    {
        #region MyRegion

        private TestContext _testContext;
        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        #endregion

        [TestMethod]
        public void Can_UnitOfWork()
        {
            // Arrange
            var kernel = TestContext.Properties["Kernel"] as IKernel;
            using (var uow = kernel.Get<UnitOfWork>())
            {
                var repository =
                    uow.CreateRepository<IDiaryPage>() as IDiaryPageRepository;

                var newRepository = TestContext.Properties["Repository"];

                // Act
                var actual = repository.GetAll();

                // Assert
                Assert.IsNotNull(actual);
                Assert.IsTrue(actual.Count() >= 1);

                var uowSession = new PrivateObject(uow).GetField("_session");
                var repositorySession =
                    new PrivateObject(repository, new PrivateType(typeof(Repository<IDiaryPage>)))
                        .GetField("_session");
                var newRepositorySession =
                    new PrivateObject(newRepository, new PrivateType(typeof(Repository<IDiaryPage>)))
                        .GetField("_session");
                Assert.AreEqual(uowSession, repositorySession);
                Assert.AreNotEqual(uowSession, newRepositorySession);
            }
        }
    }
}
