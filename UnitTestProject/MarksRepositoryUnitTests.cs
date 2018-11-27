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
    /// Test MarksRepository
    /// </summary>
    [TestClass]
    public class MarksRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            var repo = new MarksRepository(_context);
            var item = new Mark
            {
                Student = _context.Students.FirstOrDefault(),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(),
                StudentsMark = 55
            };
            repo.AddItem(item);
            var newitem = _context.Marks.FirstOrDefault(x => x.Student.Id == item.Student.Id 
                                                    && x.TeachSubj.Id == item.TeachSubj.Id
                                                    && x.StudentsMark == item.StudentsMark);
            Assert.AreEqual(item.Student.Id, newitem.Student.Id);
            Assert.AreEqual(item.StudentsMark, newitem.StudentsMark);
            Assert.AreEqual(item.TeachSubj.TeacherId, newitem.TeachSubj.TeacherId);
            Assert.AreEqual(item.TeachSubj.SubjId, newitem.TeachSubj.SubjId);
            _context.Marks.Remove(item);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            var repo = new MarksRepository(_context);
            Assert.AreEqual(_context.Marks.Count(), repo.AllItems.Count());
            var item1 = new Mark
            {
                Student = _context.Students.FirstOrDefault(),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(),
                StudentsMark = 55
            };
            repo.AddItem(item1);
            Assert.AreEqual(_context.Marks.Count(), repo.AllItems.Count());
            _context.Marks.Remove(item1);
        }
        [TestMethod]
        public void GetItemTest()
        {
            var repo = new MarksRepository(_context);
            var item = new Mark
            {
                Student = _context.Students.FirstOrDefault(),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(),
                StudentsMark = 55
            };
            repo.AddItem(item);
            int Id = _context.Marks.FirstOrDefault(x => x.Student.Id == item.Student.Id
                                                    && x.TeachSubj.Id == item.TeachSubj.Id
                                                    && x.StudentsMark == item.StudentsMark).Id;
            var newitem = repo.GetItem(Id);
            Assert.AreEqual(item.StudentsMark, newitem.StudentsMark);
            Assert.AreEqual(item.Student.Id, newitem.Student.Id);
            Assert.AreEqual(item.TeachSubj.TeacherId, newitem.TeachSubj.TeacherId);
            Assert.AreEqual(item.TeachSubj.SubjId, newitem.TeachSubj.SubjId);
            _context.Marks.Remove(item);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new MarksRepository(_context);
            var item1 = repo.GetItem(-1).StudentsMark;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            var repo = new MarksRepository(_context);
            var item = new Mark
            {
                Student = _context.Students.FirstOrDefault(),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(),
                StudentsMark = 55
            };
            repo.AddItem(item);
            int Id = _context.Marks.FirstOrDefault(x => x.Student.Id == item.Student.Id
                                                    && x.TeachSubj.Id == item.TeachSubj.Id
                                                    && x.StudentsMark == item.StudentsMark).Id;
            var newitem = repo.GetItem(Id);
            Assert.AreEqual(item.StudentsMark, newitem.StudentsMark);
            Assert.AreEqual(item.Student.Id, newitem.Student.Id);
            Assert.AreEqual(item.TeachSubj.TeacherId, newitem.TeachSubj.TeacherId);
            Assert.AreEqual(item.TeachSubj.SubjId, newitem.TeachSubj.SubjId);
            repo.DeleteItem(Id);
            Assert.AreEqual(item.StudentsMark, repo.GetItem(Id).StudentsMark);
        }

        [TestMethod]
        public void AddItemsTest()
        {
            var repo = new MarksRepository(_context);
            var item1 = new Mark
            {
                Student = _context.Students.FirstOrDefault(),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(x => x.Subject.Id == 1),
                StudentsMark = 55
            };
            var item2 = new Mark
            {
                Student = _context.Students.FirstOrDefault(),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(x=>x.Subject.Id == 2),
                StudentsMark = 55
            };
            Mark[] items = new Mark[] { item1, item2 };

            repo.AddItems(items);
            var newitem1 = _context.Marks.FirstOrDefault(x => x.Student.Id == item1.Student.Id
                                                    && x.TeachSubj.Id == item1.TeachSubj.Id
                                                    && x.StudentsMark == item1.StudentsMark);
            var newitem2 = _context.Marks.FirstOrDefault(x => x.Student.Id == item2.Student.Id
                                                    && x.TeachSubj.Id == item2.TeachSubj.Id
                                                    && x.StudentsMark == item2.StudentsMark);

            Assert.AreEqual(items[0].StudentsMark, newitem1.StudentsMark);
            Assert.AreEqual(items[0].Student.Id, newitem1.Student.Id);
            Assert.AreEqual(items[0].TeachSubj.TeacherId, newitem1.TeachSubj.TeacherId);
            Assert.AreEqual(items[0].TeachSubj.SubjId, newitem1.TeachSubj.SubjId);
            Assert.AreEqual(items[1].StudentsMark, newitem2.StudentsMark);
            Assert.AreEqual(items[1].Student.Id, newitem2.Student.Id);
            Assert.AreEqual(items[1].TeachSubj.TeacherId, newitem2.TeachSubj.TeacherId);
            Assert.AreEqual(items[1].TeachSubj.SubjId, newitem2.TeachSubj.SubjId);
            _context.Marks.Remove(item1);
            _context.Marks.Remove(item2);
        }
        [TestMethod]
        public void ChangeItemTest()
        {
            var repo = new MarksRepository(_context);
            var item = new Mark
            {
                Student = _context.Students.FirstOrDefault(),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(),
                StudentsMark = 77
            };
            repo.AddItem(item);
            int Id = _context.Marks.FirstOrDefault(x => x.Student.Id == item.Student.Id
                                                    && x.TeachSubj.Id == item.TeachSubj.Id
                                                    && x.StudentsMark == item.StudentsMark).Id;
            var newitem = repo.GetItem(Id);
            newitem.StudentsMark = 83;
            repo.ChangeItem(newitem);
            var gotitem = repo.GetItem(Id);
            Assert.AreEqual(newitem.Student.Id, gotitem.Student.Id);
            Assert.AreEqual(newitem.StudentsMark, gotitem.StudentsMark);
            Assert.AreEqual(newitem.TeachSubj.TeacherId, gotitem.TeachSubj.TeacherId);
            Assert.AreEqual(newitem.TeachSubj.SubjId, gotitem.TeachSubj.SubjId);
            _context.Marks.Remove(newitem);
        }
    }
}
