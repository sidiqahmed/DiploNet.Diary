using System;
using DiploNet.Diary.DataAccess.FNHibernate.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiploNet.Diary.DataAccess.FNHibernate.Configuration.Test
{
    [TestClass]
    public class FNHibernateConfigurationTest
    {
        [TestMethod]
        public void Can_Get_SessionFactory()
        {
            // Act
            var sessionFactory =
                FNHibernateConfiguration.SessionFactory;

            // Assert
            Assert.IsNotNull(sessionFactory);
        }
    }
}
