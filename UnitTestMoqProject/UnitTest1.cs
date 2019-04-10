
using ConsoleApp2.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ConsoleApp2;
using System.Data.Entity;

namespace UnitTestMoqProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetFirstEmployee10Y()
        {
            Dao fakeDao = Mock.Of<Dao>();
            Mock.Get(fakeDao).Setup(x => x.GetFirstEmployee10Y()).Returns(new Employee{Nom="Bob", Prenom="Jean" });
            Assert.IsNotNull(fakeDao.GetFirstEmployee10Y());
        }
        [TestMethod]
        public void AddEmployee_Test()//create
        {
            var mockSet = new Mock<DbSet<Employee>>();

            var mockContext = new Mock<context>();
            mockContext.Setup(m => m.Employee).Returns(mockSet.Object);

            var service = new Dao(mockContext.Object);
            service.AddEmployee("Jean-Mie", "De pain");

            mockSet.Verify(m => m.Add(It.IsAny<Employee>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [TestMethod]
        public void UpdateEmployee()//update
        {
            var mockSet = new Mock<DbSet<Employee>>();

            var mockContext = new Mock<context>();
            mockContext.Setup(m => m.Employee).Returns(mockSet.Object);

            var service = new Dao(mockContext.Object);
            service.UpdateEmployee("Jean-Mie", "Caillou");

            mockSet.Verify(m => m.Add(It.IsAny<Employee>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

    }
}
