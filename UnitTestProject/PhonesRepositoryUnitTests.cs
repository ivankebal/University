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
    /// Test PhonesRepository
    /// </summary>
    [TestClass]
    public class PhonesRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            //_context.Phones.RemoveRange(_context.Phones);
            var repo = new PhonesRepository(_context);
            var item = new Phone { StudentsPhone = "test243675567" };
            repo.AddItem(item);
            string name = _context.Phones.FirstOrDefault(x => x.StudentsPhone == item.StudentsPhone).StudentsPhone;
            Assert.AreEqual(item.StudentsPhone, name);
            _context.Phones.Remove(item);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            //_context.Phones.RemoveRange(_context.Phones);
            var repo = new PhonesRepository(_context);
            Assert.AreEqual(_context.Phones.Count(), repo.AllItems.Count());
            var item1 = new Phone { StudentsPhone = "test5457757" };
            var item2 = new Phone { StudentsPhone = "test5467578" };
            repo.AddItem(item1);
            repo.AddItem(item2);
            Assert.AreEqual(_context.Phones.Count(), repo.AllItems.Count());
            _context.Phones.Remove(item1);
            _context.Phones.Remove(item2);
        }

        [TestMethod]
        public void GetItemTest()
        {
            //_context.Phones.RemoveRange(_context.Phones);
            var repo = new PhonesRepository(_context);
            var item = new Phone { StudentsPhone = "test6867868" };
            repo.AddItem(item);
            int Id = _context.Phones.FirstOrDefault(x => x.StudentsPhone == item.StudentsPhone).Id;
            Assert.AreEqual(item.StudentsPhone, repo.GetItem(Id).StudentsPhone);
            _context.Phones.Remove(item);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new PhonesRepository(_context);
            var item1 = repo.GetItem(-1).StudentsPhone;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            //_context.Phones.RemoveRange(_context.Phones);
            var repo = new PhonesRepository(_context);
            var item = new Phone { StudentsPhone = "test5768878" };
            repo.AddItem(item);
            int Id = _context.Phones.FirstOrDefault(x => x.StudentsPhone == item.StudentsPhone).Id;
            Assert.AreEqual(item.StudentsPhone, repo.GetItem(Id).StudentsPhone);
            repo.DeleteItem(Id);
            Assert.AreEqual(item.StudentsPhone, repo.GetItem(Id).StudentsPhone);
        }

        [TestMethod]
        public void AddItemsTest()
        {
            // _context.Phones.RemoveRange(_context.Phones);
            var repo = new PhonesRepository(_context);
            var item1 = new Phone { StudentsPhone = "test111222" };
            var item2 = new Phone { StudentsPhone = "test111223" };
            Phone[] items = new Phone[] { item1, item2 };

            repo.AddItems(items);
            Assert.AreEqual(items[0].StudentsPhone, _context.Phones.FirstOrDefault(x => x.StudentsPhone == "test111222").StudentsPhone);
            Assert.AreEqual(items[1].StudentsPhone, _context.Phones.FirstOrDefault(x => x.StudentsPhone == "test111223").StudentsPhone);
            _context.Phones.Remove(item1);
            _context.Phones.Remove(item2);
        }

        [TestMethod]
        public void ChangeItemTest()
        {
            //_context.Phones.RemoveRange(_context.Phones);
            var repo = new PhonesRepository(_context);
            var item = new Phone { StudentsPhone = "test2436346" };
            repo.AddItem(item);
            int Id = _context.Phones.FirstOrDefault(x => x.StudentsPhone == item.StudentsPhone).Id;
            var newitem = repo.GetItem(Id);
            newitem.StudentsPhone = "test2400346";
            repo.ChangeItem(newitem);
            Assert.AreEqual(newitem.StudentsPhone, _context.Phones.FirstOrDefault(x => x.StudentsPhone == newitem.StudentsPhone).StudentsPhone);
            _context.Phones.Remove(newitem);
        }
    }
}
