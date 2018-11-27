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
    /// Test AudiencesRepository
    /// </summary>
    [TestClass]
    public class AudiencesRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            var repo = new AudiencesRepository(_context);
            var item = new Audience { Name = "Test888" };
            repo.AddItem(item);
            string name = _context.Audiences.FirstOrDefault(x => x.Name == item.Name).Name;
            Assert.AreEqual(item.Name, name);
            _context.Audiences.Remove(item);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            var repo = new AudiencesRepository(_context);
            Assert.AreEqual(_context.Audiences.Count(), repo.AllItems.Count());
            var item1 = new Audience { Name = "Test802" };
            var item2 = new Audience { Name = "Test802" };
            repo.AddItem(item1);
            repo.AddItem(item2);
            Assert.AreEqual(_context.Audiences.Count(), repo.AllItems.Count());
            _context.Audiences.Remove(item1);
            _context.Audiences.Remove(item2);
        }

        [TestMethod]
        public void GetItemTest()
        {
            var repo = new AudiencesRepository(_context);
            var item = new Audience { Name = "Test804" };
            repo.AddItem(item);
            int Id = _context.Audiences.FirstOrDefault(x => x.Name == item.Name).Id;
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
            _context.Audiences.Remove(item);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new AudiencesRepository(_context);
            var item1 = repo.GetItem(-1).Name;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            var repo = new AudiencesRepository(_context);
            var item = new Audience { Name = "Test805" };
            repo.AddItem(item);
            int Id = _context.Audiences.FirstOrDefault(x => x.Name == item.Name).Id;
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
            repo.DeleteItem(Id);
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
        }

        [TestMethod]
        public void AddItemsTest()
        {
            var repo = new AudiencesRepository(_context);
            var item1 = new Audience { Name = "Test222" };
            var item2 = new Audience { Name = "Test223" };
            Audience[] items = new Audience[] { item1, item2 };

            repo.AddItems(items);
            Assert.AreEqual(items[0].Name, _context.Audiences.FirstOrDefault(x => x.Name == "Test222").Name);
            Assert.AreEqual(items[1].Name, _context.Audiences.FirstOrDefault(x => x.Name == "Test223").Name);
            _context.Audiences.Remove(item1);
            _context.Audiences.Remove(item2);
        }

        [TestMethod]
        public void ChangeItemTest()
        {
            var repo = new AudiencesRepository(_context);
            var item = new Audience { Name = "Test806" };
            repo.AddItem(item);
            int Id = _context.Audiences.FirstOrDefault(x => x.Name == item.Name).Id;
            var newitem = repo.GetItem(Id);
            newitem.Name = "Test807";
            repo.ChangeItem(newitem);
            Assert.AreEqual(newitem.Name, _context.Audiences.FirstOrDefault(x => x.Name == newitem.Name).Name);
            _context.Audiences.Remove(newitem);
        }
    }
}
