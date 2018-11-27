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
    /// Test DepartmentsRepository
    /// </summary>
    [TestClass]
    public class DepartmentsRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            //_context.Departments.RemoveRange(_context.Departments);
            var repo = new DepartmentsRepository(_context);
            var item = new Department { Name = "Department999" };
            repo.AddItem(item);
            string name = _context.Departments.FirstOrDefault(x => x.Name == item.Name).Name;
            Assert.AreEqual(item.Name, name);
            _context.Departments.Remove(item);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            //_context.Departments.RemoveRange(_context.Departments);
            var repo = new DepartmentsRepository(_context);
            Assert.AreEqual(_context.Departments.Count(), repo.AllItems.Count());
            var item1 = new Department { Name = "Department123" };
            var item2 = new Department { Name = "Department124" };
            repo.AddItem(item1);
            repo.AddItem(item2);
            Assert.AreEqual(_context.Departments.Count(), repo.AllItems.Count());
            _context.Departments.Remove(item1);
            _context.Departments.Remove(item2);
        }
        [TestMethod]
        public void GetItemTest()
        {
            //_context.Departments.RemoveRange(_context.Departments);
            var repo = new DepartmentsRepository(_context);
            var item = new Department { Name = "Security Department" };
            repo.AddItem(item);
            int Id = _context.Departments.FirstOrDefault(x => x.Name == item.Name).Id;
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
            _context.Departments.Remove(item);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new DepartmentsRepository(_context);
            var item1 = repo.GetItem(-1).Name;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            //_context.Departments.RemoveRange(_context.Departments);
            var repo = new DepartmentsRepository(_context);
            var item = new Department { Name = "Department805" };
            repo.AddItem(item);
            int Id = _context.Departments.FirstOrDefault(x => x.Name == item.Name).Id;
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
            repo.DeleteItem(Id);
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
        }

        [TestMethod]
        public void AddItemsTest()
        {
            //_context.Departments.RemoveRange(_context.Departments);
            var repo = new DepartmentsRepository(_context);
            var item1 = new Department { Name = "Department222" };
            var item2 = new Department { Name = "Department223" };
            Department[] items = new Department[] { item1, item2 };

            repo.AddItems(items);
            Assert.AreEqual(items[0].Name, _context.Departments.FirstOrDefault(x => x.Name == "Department222").Name);
            Assert.AreEqual(items[1].Name, _context.Departments.FirstOrDefault(x => x.Name == "Department223").Name);
            _context.Departments.Remove(item1);
            _context.Departments.Remove(item2);
        }
        [TestMethod]
        public void ChangeItemTest()
        {
            //_context.Departments.RemoveRange(_context.Departments);
            var repo = new DepartmentsRepository(_context);
            var item = new Department { Name = "Department806" };
            repo.AddItem(item);
            int Id = _context.Departments.FirstOrDefault(x => x.Name == item.Name).Id;
            var newitem = repo.GetItem(Id);
            newitem.Name = "Department807";
            repo.ChangeItem(newitem);
            Assert.AreEqual(newitem.Name, _context.Departments.FirstOrDefault(x => x.Name == newitem.Name).Name);
            _context.Departments.Remove(item);
        }
    }
}
