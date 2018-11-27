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
    /// Test SubjectsRepository
    /// </summary>
    [TestClass]
    public class SubjectsRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            //_context.Subjects.RemoveRange(_context.Subjects);
            var repo = new SubjectsRepository(_context);
            var item = new Subject { Name = "Data Engineering" };
            repo.AddItem(item);
            string name = _context.Subjects.FirstOrDefault(x => x.Name == item.Name).Name;
            Assert.AreEqual(item.Name, name);
            _context.Subjects.Remove(item);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            //_context.Subjects.RemoveRange(_context.Subjects);
            var repo = new SubjectsRepository(_context);
            Assert.AreEqual(_context.Subjects.Count(), repo.AllItems.Count());
            var item1 = new Subject { Name = "Data Engineering" };
            var item2 = new Subject { Name = "Automation Theory" };
            repo.AddItem(item1);
            repo.AddItem(item2);
            Assert.AreEqual(_context.Subjects.Count(), repo.AllItems.Count());
            _context.Subjects.Remove(item1);
            _context.Subjects.Remove(item2);
        }

        [TestMethod]
        public void GetItemTest()
        {
            //_context.Subjects.RemoveRange(_context.Subjects);
            var repo = new SubjectsRepository(_context);
            var item = new Subject { Name = "Automation Theory" };
            repo.AddItem(item);
            int Id = _context.Subjects.FirstOrDefault(x => x.Name == item.Name).Id;
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
            _context.Subjects.Remove(item);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new SubjectsRepository(_context);
            var item1 = repo.GetItem(-1).Name;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            //_context.Subjects.RemoveRange(_context.Subjects);
            var repo = new SubjectsRepository(_context);
            var item = new Subject { Name = "Automation Theory" };
            repo.AddItem(item);
            int Id = _context.Subjects.FirstOrDefault(x => x.Name == item.Name).Id;
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
            repo.DeleteItem(Id);
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
        }

        [TestMethod]
        public void AddItemsTest()
        {
            //_context.Subjects.RemoveRange(_context.Subjects);
            var repo = new SubjectsRepository(_context);
            var item1 = new Subject { Name = "Automation Theory" };
            var item2 = new Subject { Name = "Data Analysis" };
            Subject[] items = new Subject[] { item1, item2 };

            repo.AddItems(items);
            Assert.AreEqual(items[0].Name, _context.Subjects.FirstOrDefault(x => x.Name == "Automation Theory").Name);
            Assert.AreEqual(items[1].Name, _context.Subjects.FirstOrDefault(x => x.Name == "Data Analysis").Name);
            _context.Subjects.Remove(item1);
            _context.Subjects.Remove(item2);

        }
        [TestMethod]
        public void ChangeItemTest()
        {
            //_context.Subjects.RemoveRange(_context.Subjects);
            var repo = new SubjectsRepository(_context);
            var item = new Subject { Name = "Biology" };
            repo.AddItem(item);
            int Id = _context.Subjects.FirstOrDefault(x => x.Name == item.Name).Id;
            var newitem = repo.GetItem(Id);
            newitem.Name = "Chemistry";
            repo.ChangeItem(newitem);
            Assert.AreEqual(newitem.Name, _context.Subjects.FirstOrDefault(x => x.Name == newitem.Name).Name);
            _context.Subjects.Remove(newitem);

        }
    }
}
