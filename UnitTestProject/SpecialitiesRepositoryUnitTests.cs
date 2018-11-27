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
    /// Test SpecialitiesRepository
    /// </summary>
    [TestClass]
    public class SpecialitiesRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            //_context.Specialities.RemoveRange(_context.Specialities);
            var repo = new SpecialitiesRepository(_context);
            Speciality item = new Speciality
            {
                Name = "Test Automation"
            };
            repo.AddItem(item);
            var newitem = _context.Specialities.FirstOrDefault(x => x.Name == item.Name);
            Assert.AreEqual(item.Name, newitem.Name);
            _context.Specialities.Remove(item);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            //_context.Specialities.RemoveRange(_context.Specialities);
            var repo = new SpecialitiesRepository(_context);
            Assert.AreEqual(_context.Specialities.Count(), repo.AllItems.Count());
            var item1 = new Speciality
            {
                Name = "Test Computer Security",
            };
            var item2 = new Speciality
            {
                Name = "Test Computer Science",
            };
            repo.AddItem(item1);
            repo.AddItem(item2);
            Assert.AreEqual(_context.Specialities.Count(), repo.AllItems.Count());
            _context.Specialities.Remove(item1);
            _context.Specialities.Remove(item2);
        }

        [TestMethod]
        public void GetItemTest()
        {
            //_context.Specialities.RemoveRange(_context.Specialities);
            var repo = new SpecialitiesRepository(_context);
            var item = new Speciality
            {
                Name = "Test Computer Science"
            };
            repo.AddItem(item);
            int Id = _context.Specialities.FirstOrDefault(x => x.Name == item.Name).Id;
            var newitem = repo.GetItem(Id);
            Assert.AreEqual(item.Name, newitem.Name);
            _context.Specialities.Remove(item);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new SpecialitiesRepository(_context);
            var item1 = repo.GetItem(-1).Name;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            //_context.Specialities.RemoveRange(_context.Specialities);
            var repo = new SpecialitiesRepository(_context);
            var item = new Speciality
            {
                Name = "Test Computer Science"
            };
            repo.AddItem(item);
            var newitem = _context.Specialities.FirstOrDefault(x => x.Name == item.Name);
            Assert.AreEqual(item.Name, repo.GetItem(newitem.Id).Name);
            repo.DeleteItem(newitem.Id);
            Assert.AreEqual(item.Name, repo.GetItem(newitem.Id).Name);
        }

        [TestMethod]
        public void AddItemsTest()
        {
            //_context.Specialities.RemoveRange(_context.Specialities);
            var repo = new SpecialitiesRepository(_context);
            var l1 = new Speciality
            {
                Name = "Test Computer Science"
            };
            var l2 = new Speciality
            {
                Name = "Test Chemistry"
            };

            repo.AddItems(new Speciality[] { l1, l2 });

            var newlection1 = _context.Specialities.FirstOrDefault(x => x.Name == l1.Name);
            var newlection2 = _context.Specialities.FirstOrDefault(x => x.Name == l2.Name);
            Assert.AreEqual(l1.Name, newlection1.Name);
            Assert.AreEqual(l2.Name, newlection2.Name);
            _context.Specialities.Remove(l1);
            _context.Specialities.Remove(l2);
        }

        [TestMethod]
        public void ChangeItemTest()
        {
            //_context.Specialities.RemoveRange(_context.Specialities);
            var repo = new SpecialitiesRepository(_context);
            var item = new Speciality
            {
                Name = "Automation"
            };
            repo.AddItem(item);
            int Id = _context.Specialities.FirstOrDefault(x => x.Name == item.Name).Id;
            var newitem = repo.GetItem(Id);
            newitem.Name = "Electromechanics";
            repo.ChangeItem(newitem);
            Assert.AreEqual(newitem.Name, repo.GetItem(newitem.Id).Name);
            _context.Specialities.Remove(newitem);
        }
    }
}
