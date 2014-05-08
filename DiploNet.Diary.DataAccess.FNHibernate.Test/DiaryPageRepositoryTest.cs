using System;
using System.Linq;
using DiploNet.Diary.BusinessObject;
using DiploNet.Diary.DataAccess.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace DiploNet.Diary.DataAccess.FNHibernate.Test
{
    [TestClass]
    public class DiaryPageRepositoryTest
    {
        private TestContext _textContext;
        public TestContext TestContext
        {
            get { return _textContext; }
            set { _textContext = value; }
        }

        [TestInitialize]
        public void DiaryPageRepositoryTestInitialize()
        {
            var kernel =
                new StandardKernel(new DependencyInjection.FNHibernateNinjectModule());

            TestContext.Properties.Add("Kernel", kernel);
            TestContext.Properties.Add("Repository", kernel.Get<DiaryPageRepository>());
        }

        [TestMethod]
        public void Can_GetAll()
        {
            // Arrange
            var respository =
                TestContext.Properties["Repository"] as DiaryPageRepository;

            // Act
            var actual = respository.GetAll();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() >= 1);
        }

        [TestMethod]
        public void Can_UnitOfWork()
        {
            // Arrange
            var kernel = TestContext.Properties["Kernel"] as IKernel;
            using (var uow =  kernel.Get<UnitOfWork>())
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

        [TestMethod]
        public void Can_Get()
        {
            // Arrange
            var repository =
                TestContext.Properties["Repository"] as DiaryPageRepository;

            var expected = repository.GetAll()
                .Where(w => w.Title.Contains("Lorem"));

            // Act
            var actual = repository.Get(w => w.Title.Contains("Lorem"));

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count(), expected.Count());
        }
    }
}
