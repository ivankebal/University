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
    /// Test LectionsRepository
    /// </summary>
    [TestClass]
    public class LectionsRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            //_context.Lections.RemoveRange(_context.Lections);
            var repo = new LectionsRepository(_context);
            var item = new Lection
            {
                Day = DayOfWeek.Tuesday,
                Start = new DateTime(1976, 1, 1, 8, 0, 0),
                Finish = new DateTime(1976, 1, 1, 9, 20, 0)
            };
            repo.AddItem(item);
            var newitem = _context.Lections.FirstOrDefault(x => x.Day == item.Day
                                                    && x.Start == item.Start
                                                    && x.Finish == item.Finish);
            Assert.AreEqual(item.Day, newitem.Day);
            Assert.AreEqual(item.Start, newitem.Start);
            Assert.AreEqual(item.Finish, newitem.Finish);
            _context.Lections.Remove(item);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            //_context.Lections.RemoveRange(_context.Lections);
            var repo = new LectionsRepository(_context);
            Assert.AreEqual(_context.Lections.Count(), repo.AllItems.Count());
            var item1 = new Lection
            {
                Day = DayOfWeek.Tuesday,
                Start = new DateTime(1976, 1, 1, 9, 35, 0),
                Finish = new DateTime(1976, 1, 1, 10, 55, 0)
            };
            repo.AddItem(item1);
            var item2 = new Lection
            {
                Day = DayOfWeek.Tuesday,
                Start = new DateTime(1976, 1, 1, 11, 20, 0),
                Finish = new DateTime(1976, 1, 1, 12, 40, 0)
            };
            repo.AddItem(item2);
            Assert.AreEqual(_context.Lections.Count(), repo.AllItems.Count());
            _context.Lections.Remove(item1);
            _context.Lections.Remove(item2);
        }
        [TestMethod]
        public void GetItemTest()
        {
            //_context.Lections.RemoveRange(_context.Lections);
            var repo = new LectionsRepository(_context);
            var item = new Lection
            {
                Day = DayOfWeek.Tuesday,
                Start = new DateTime(1976, 1, 1, 11, 20, 0),
                Finish = new DateTime(1976, 1, 1, 12, 40, 0)
            };
            repo.AddItem(item);
            int Id = _context.Lections.FirstOrDefault(x => x.Day == item.Day
                                                    && x.Start == item.Start
                                                    && x.Finish == item.Finish).Id;
            var newitem = repo.GetItem(Id);
            Assert.AreEqual(item.Day, newitem.Day);
            Assert.AreEqual(item.Start, newitem.Start);
            Assert.AreEqual(item.Finish, newitem.Finish);
            _context.Lections.Remove(item);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new LectionsRepository(_context);
            var item1 = repo.GetItem(-1).Day;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            //_context.Lections.RemoveRange(_context.Lections);
            var repo = new LectionsRepository(_context);
            var item = new Lection
            {
                Day = DayOfWeek.Tuesday,
                Start = new DateTime(1976, 1, 1, 11, 20, 0),
                Finish = new DateTime(1976, 1, 1, 12, 40, 0)
            };
            repo.AddItem(item);
            var newitem = _context.Lections.FirstOrDefault(x => x.Day == item.Day
                                                    && x.Start == item.Start
                                                    && x.Finish == item.Finish);
            Assert.AreEqual(item.Day, repo.GetItem(newitem.Id).Day);
            Assert.AreEqual(item.Start, repo.GetItem(newitem.Id).Start);
            Assert.AreEqual(item.Finish, repo.GetItem(newitem.Id).Finish);
            repo.DeleteItem(newitem.Id);
            Assert.AreEqual(item.Day, repo.GetItem(newitem.Id).Day);
        }

        [TestMethod]
        public void AddItemsTest()
        {
            //_context.Lections.RemoveRange(_context.Lections);
            var repo = new LectionsRepository(_context);
            Lection l1 = new Lection
            {
                Day = DayOfWeek.Tuesday,
                Start = new DateTime(1975, 1, 1, 11, 20, 0),
                Finish = new DateTime(1975, 1, 1, 12, 40, 0)
            };
            Lection l2 = new Lection
            {
                Day = DayOfWeek.Tuesday,
                Start = new DateTime(1975, 1, 1, 12, 55, 0),
                Finish = new DateTime(1975, 1, 1, 14, 15, 0)
            };

            repo.AddItems(new Lection[] { l1, l2 });

            Lection newlection1 = _context.Lections.FirstOrDefault(x => x.Day == l1.Day
                                                    && x.Start == l1.Start
                                                    && x.Finish == l1.Finish);
            Lection newlection2 = _context.Lections.FirstOrDefault(x => x.Day == l2.Day
                                                    && x.Start == l2.Start
                                                    && x.Finish == l2.Finish);
            Assert.AreEqual(l1.Day, newlection1.Day);
            Assert.AreEqual(l1.Start, newlection1.Start);
            Assert.AreEqual(l1.Finish, newlection1.Finish);
            Assert.AreEqual(l2.Day, newlection2.Day);
            Assert.AreEqual(l2.Start, newlection2.Start);
            Assert.AreEqual(l2.Finish, newlection2.Finish);

            _context.Lections.Remove(l1);
            _context.Lections.Remove(l2);
        }
        [TestMethod]
        public void ChangeItemTest()
        {
            //_context.Lections.RemoveRange(_context.Lections);
            var repo = new LectionsRepository(_context);
            var item = new Lection
            {
                Day = DayOfWeek.Tuesday,
                Start = new DateTime(1976, 1, 1, 11, 20, 0),
                Finish = new DateTime(1976, 1, 1, 12, 40, 0)
            };
            repo.AddItem(item);
            int Id = _context.Lections.FirstOrDefault(x => x.Day == item.Day
                                                    && x.Start == item.Start
                                                    && x.Finish == item.Finish).Id;
            var newitem = repo.GetItem(Id);
            newitem.Day = DayOfWeek.Saturday;
            repo.ChangeItem(newitem);
            Assert.AreEqual(newitem.Day, repo.GetItem(newitem.Id).Day);
            Assert.AreEqual(newitem.Start, repo.GetItem(newitem.Id).Start);
            Assert.AreEqual(newitem.Finish, repo.GetItem(newitem.Id).Finish);
            _context.Lections.Remove(newitem);
        }
    }
}
