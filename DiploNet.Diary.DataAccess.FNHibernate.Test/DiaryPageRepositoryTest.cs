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
        #region TestContext

        private TestContext _textContext;
        public TestContext TestContext
        {
            get { return _textContext; }
            set { _textContext = value; }
        } 
        
        #endregion

        [TestInitialize]
        public void DiaryPageRepositoryTestInitialize()
        {
            var kernel = new StandardKernel(
                new DependencyInjection.FNHibernateNinjectModule(),
                new BusinessObject.DependencyInjection.BusinessObjectNinjectModule());

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
        public void Can_Get_Where()
        {
            // Arrange
            var repository =
                TestContext.Properties["Repository"] as DiaryPageRepository;

            var keyword = repository.GetAll()
                .First().Title.Split(' ')[0];

            // Act
            var actual = repository
                .Get(w => w.Title.Contains(keyword))
                .ToList();

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.All(a => a.Title.Contains(keyword)));
        }

        [TestMethod]
        public void Can_Get_Id()
        {
            // Arrange
            var repository =
                TestContext.Properties["Repository"] as IDiaryPageRepository;

            var expected = repository.GetAll()
                .First();

            // Act
            var actual = repository.Get(expected.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Can_Save()
        {
            // Arrange
            var kernel = 
                TestContext.Properties["Kernel"] as IKernel;

            var title = "It's a test";
            var description = "It's the description"; 
            var text = "Test the persistence";

            var newDiarypage = kernel.Get<IDiaryPage>();
            newDiarypage.Title = title;
            newDiarypage.Description = description;
            newDiarypage.Text = text;

            // Act 
            using (var uow = kernel.Get<IUnitOfWork>())
            {
                var repository = uow.CreateRepository<IDiaryPage>() as IDiaryPageRepository;
                repository.Save(newDiarypage);
                var expected = repository.Get(newDiarypage.Id);

                // Assert
                Assert.AreNotEqual(default(long), newDiarypage.Id);
                Assert.IsNotNull(expected);
                Assert.AreEqual(expected, newDiarypage);

                uow.Rollback();
            }
        }

        [TestMethod]
        public void Can_Update()
        {
            // Assert
            var repository = 
                TestContext.Properties["Repository"] as IDiaryPageRepository;
            
            var kernel 
                = TestContext.Properties["Kernel"] as IKernel;

            var actual = repository.GetAll().First();
            var oldTitle = actual.Title;
            
            // Act 
            using (var uow = kernel.Get<IUnitOfWork>())
            {
                var newTitle = "It's time to change title";
                actual.Title = newTitle; 

                var repo = uow.CreateRepository<IDiaryPage>();
                repo.Update(actual);
                var expected = repository.Get(actual.Id);

                // Assert
                Assert.AreEqual(expected.Title, actual.Title);

                uow.Rollback();
            }
        }

        [TestMethod]
        public void Can_Delete()
        {
            // Assert
            var kernel
                = TestContext.Properties["Kernel"] as IKernel;

            // Act 
            using (var uow = kernel.Get<IUnitOfWork>())
            {
                var repository = uow.CreateRepository<IDiaryPage>();
                var actual = repository.GetAll().First();
                repository.Delete(actual);
                var expected = repository.Get(actual.Id);

                // Assert
                Assert.IsNull(expected);

                uow.Rollback();
            }
        }
    }
}
