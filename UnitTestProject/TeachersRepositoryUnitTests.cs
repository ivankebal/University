using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using Domain;
using Domain.AppContext;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    /// <summary>
    /// Test TeachersRepository
    /// </summary>
    [TestClass]
    public class TeachersRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext(TestDBConnection.ConnectionString());
        [TestMethod]
        public void AddItemTest()
        {
            var repo = new TeachersRepository(_context);
            var item = new Teacher
            {
                FirstName = "Kate",
                MiddleName = "Mary",
                LastName = "March",
                Department = _context.Departments.FirstOrDefault()
            };
            repo.AddItem(item);
            var newitem = _context.Teachers.FirstOrDefault(x => x.FirstName == item.FirstName
                            && x.MiddleName == item.MiddleName
                            && x.LastName == item.LastName
                            && x.Department.Id == item.Department.Id);
            Assert.AreEqual(item.FirstName, newitem.FirstName);
            Assert.AreEqual(item.MiddleName, newitem.MiddleName);
            Assert.AreEqual(item.LastName, newitem.LastName);
            Assert.AreEqual(item.Department.Id, newitem.Department.Id);
            _context.Teachers.Remove(item);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            var repo = new TeachersRepository(_context);
            Assert.AreEqual(_context.Teachers.Count(), repo.AllItems.Count());
            var item1 = new Teacher
            {
                FirstName = "Kate",
                MiddleName = "Mary",
                LastName = "March",
                Department = _context.Departments.FirstOrDefault()
            };
            var item2 = new Teacher
            {
                FirstName = "Mark",
                MiddleName = "Andrew",
                LastName = "Nielsen",
                Department = _context.Departments.FirstOrDefault()
            };
            repo.AddItem(item1);
            repo.AddItem(item2);
            Assert.AreEqual(_context.Teachers.Count(), repo.AllItems.Count());
            _context.Teachers.Remove(item1);
            _context.Teachers.Remove(item2);
        }

        [TestMethod]
        public void GetItemTest()
        {
            var repo = new TeachersRepository(_context);
            var item = new Teacher
            {
                FirstName = "Kate",
                MiddleName = "Mary",
                LastName = "March",
                Department = _context.Departments.FirstOrDefault()
            };
            repo.AddItem(item);
            int Id = _context.Teachers.FirstOrDefault(x => x.FirstName == item.FirstName
                            && x.MiddleName == item.MiddleName
                            && x.LastName == item.LastName
                            && x.Department.Id == item.Department.Id).Id;
            Assert.AreEqual(item.FirstName, repo.GetItem(Id).FirstName);
            Assert.AreEqual(item.MiddleName, repo.GetItem(Id).MiddleName);
            Assert.AreEqual(item.LastName, repo.GetItem(Id).LastName);
            Assert.AreEqual(item.Department.Id, repo.GetItem(Id).Department.Id);
            _context.Teachers.Remove(item);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new TeachersRepository(_context);
            var item1 = repo.GetItem(-1).LastName;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            var repo = new TeachersRepository(_context);
            var item = new Teacher
            {
                FirstName = "Kate",
                MiddleName = "Mary",
                LastName = "March",
                Department = _context.Departments.FirstOrDefault()
            };
            repo.AddItem(item);
            int Id = _context.Teachers.FirstOrDefault(x => x.FirstName == item.FirstName
                            && x.MiddleName == item.MiddleName
                            && x.LastName == item.LastName).Id;
            Assert.AreEqual(item.FirstName, repo.GetItem(Id).FirstName);
            Assert.AreEqual(item.MiddleName, repo.GetItem(Id).MiddleName);
            Assert.AreEqual(item.LastName, repo.GetItem(Id).LastName);
            repo.DeleteItem(Id);
            Assert.AreEqual(item.LastName, repo.GetItem(Id).LastName);
        }

        [TestMethod]
        public void AddItemsTest()
        {
            var repo = new TeachersRepository(_context);
            var item1 = new Teacher
            {
                FirstName = "Kate",
                MiddleName = "Mary",
                LastName = "March",
                Department = _context.Departments.FirstOrDefault()
            };
            var item2 = new Teacher
            {
                FirstName = "Mark",
                MiddleName = "Andrew",
                LastName = "Nielsen",
                Department = _context.Departments.FirstOrDefault()
            };
            Teacher[] items = new Teacher[] { item1, item2 };

            repo.AddItems(items);
            var newitem1 =_context.Teachers.FirstOrDefault(x => x.FirstName == item1.FirstName
                            && x.MiddleName == item1.MiddleName
                            && x.LastName == item1.LastName
                            && x.Department.Id == item1.Department.Id);
            var newitem2 = _context.Teachers.FirstOrDefault(x => x.FirstName == item2.FirstName
                             && x.MiddleName == item2.MiddleName
                             && x.LastName == item2.LastName
                             && x.Department.Id == item2.Department.Id);

            Assert.AreEqual(items[0].FirstName, newitem1.FirstName);
            Assert.AreEqual(items[0].MiddleName, newitem1.MiddleName);
            Assert.AreEqual(items[0].LastName, newitem1.LastName);
            Assert.AreEqual(items[0].Department.Id, newitem1.Department.Id);

            Assert.AreEqual(items[1].FirstName, newitem2.FirstName);
            Assert.AreEqual(items[1].MiddleName, newitem2.MiddleName);
            Assert.AreEqual(items[1].LastName, newitem2.LastName);
            Assert.AreEqual(items[1].Department.Id, newitem2.Department.Id);

            _context.Teachers.Remove(item1);
            _context.Teachers.Remove(item2);

        }
        [TestMethod]
        public void ChangeItemTest()
        {
            //_context.Subjects.RemoveRange(_context.Subjects);
            var repo = new TeachersRepository(_context);
            var item = new Teacher
            {
                FirstName = "Kate",
                MiddleName = "Mary",
                LastName = "March",
                Department = _context.Departments.FirstOrDefault()
            };
            repo.AddItem(item);
            int Id = _context.Teachers.FirstOrDefault(x => x.FirstName == item.FirstName
                            && x.MiddleName == item.MiddleName
                            && x.LastName == item.LastName
                            && x.Department.Id == item.Department.Id).Id;
            var newitem = repo.GetItem(Id);
            newitem.LastName = "Price";
            repo.ChangeItem(newitem);
            var changeditem = repo.GetItem(Id); ;
            Assert.AreEqual(newitem.FirstName, changeditem.FirstName);
            Assert.AreEqual(newitem.MiddleName, changeditem.MiddleName);
            Assert.AreEqual(newitem.LastName, changeditem.LastName);
            Assert.AreEqual(newitem.Department.Id, changeditem.Department.Id);
            _context.Teachers.Remove(newitem);

        }
    }
}
