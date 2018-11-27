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
    /// Test TeachSubj Repository
    /// </summary>
    [TestClass]
    public class TeachSubjRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            var subject = new Subject { Name = "Test Linear Algebra" };
            _context.Subjects.Add(subject);
            var repo = new TeachSubjRepository(_context);
            var item = new TeachSubj
            {
                Teacher = _context.Teachers.FirstOrDefault(x=>x.Id==1),
                Subject = _context.Subjects.FirstOrDefault(x=>x.Name == subject.Name)
            };
            repo.AddItem(item);
            var newitem = _context.TeachSubjs.FirstOrDefault(x => x.Teacher.Id == item.Teacher.Id 
                                                    && x.Subject.Id == item.Subject.Id);
            Assert.AreEqual(item.Teacher.Id, newitem.Teacher.Id);
            Assert.AreEqual(item.Subject.Id, newitem.Subject.Id);
            _context.TeachSubjs.Remove(item);
            _context.Subjects.Remove(subject);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            var subject = new Subject { Name = "Test Linear Algebra" };
            _context.Subjects.Add(subject);
            var repo = new TeachSubjRepository(_context);
            Assert.AreEqual(_context.TeachSubjs.Count(), repo.AllItems.Count());
            var item1 = new TeachSubj
            {
                Teacher = _context.Teachers.FirstOrDefault(x => x.Id == 1),
                Subject = _context.Subjects.FirstOrDefault(x => x.Name == subject.Name)
            };
            repo.AddItem(item1);
            Assert.AreEqual(_context.TeachSubjs.Count(), repo.AllItems.Count());
            _context.TeachSubjs.Remove(item1);
            _context.Subjects.Remove(subject);
        }
        [TestMethod]
        public void GetItemTest()
        {
            var subject = new Subject { Name = "Test Linear Algebra" };
            _context.Subjects.Add(subject);
            var repo = new TeachSubjRepository(_context);
            var item = new TeachSubj
            {
                Teacher = _context.Teachers.FirstOrDefault(x => x.Id == 1),
                Subject = _context.Subjects.FirstOrDefault(x => x.Name == subject.Name)
            };
            repo.AddItem(item);
            int Id = _context.TeachSubjs.FirstOrDefault(x => x.Teacher.Id == item.Teacher.Id
                                                    && x.Subject.Id == item.Subject.Id).Id;
            var newitem = repo.GetItem(Id);
            Assert.AreEqual(item.Teacher.Id, newitem.Teacher.Id);
            Assert.AreEqual(item.Subject.Id, newitem.Subject.Id);
            _context.TeachSubjs.Remove(item);
            _context.Subjects.Remove(subject);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new TeachSubjRepository(_context);
            var item1 = repo.GetItem(-1).Subject.Id;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            var subject = new Subject { Name = "Test Linear Algebra" };
            _context.Subjects.Add(subject);
            var repo = new TeachSubjRepository(_context);
            var item = new TeachSubj
            {
                Teacher = _context.Teachers.FirstOrDefault(x => x.Id == 1),
                Subject = _context.Subjects.FirstOrDefault(x => x.Name == subject.Name)
            };
            repo.AddItem(item);
            int Id = _context.TeachSubjs.FirstOrDefault(x => x.Teacher.Id == item.Teacher.Id
                                                    && x.Subject.Id == item.Subject.Id).Id;
            var newitem = repo.GetItem(Id);
            Assert.AreEqual(item.Teacher.Id, newitem.Teacher.Id);
            Assert.AreEqual(item.Subject.Id, newitem.Subject.Id);
            repo.DeleteItem(Id);
            _context.Subjects.Remove(subject);
            Assert.AreEqual(item.Teacher.Id, repo.GetItem(Id).Teacher.Id);
        }

        /*[TestMethod]
        public void AddItemsTest()
        {
            var subject1 = new Subject { Name = "Test Linear Algebra" };
            _context.Subjects.Add(subject1);
            var subject2 = new Subject { Name = "NameNameTest" };
            _context.Subjects.Add(subject2);
            var repo = new TeachSubjRepository(_context);
            var item1 = new TeachSubj
            {
                Teacher = _context.Teachers.FirstOrDefault(x => x.Id == 1),
                Subject = _context.Subjects.FirstOrDefault(x => x.Name == subject1.Name)
            };
            var item2 = new TeachSubj
            {
                Teacher = _context.Teachers.FirstOrDefault(x => x.Id == 1),
                Subject = _context.Subjects.FirstOrDefault(x => x.Name == subject2.Name)
            };
            TeachSubj[] items = new TeachSubj[] { item1, item2 };

            repo.AddItems(items);
            TeachSubj newitem1 = _context.TeachSubjs.FirstOrDefault(x => x.Teacher.Id == item1.Teacher.Id
                                                    && x.Subject.Id == item1.Subject.Id);
            TeachSubj newitem2 = _context.TeachSubjs.FirstOrDefault(x => x.Teacher.Id == item2.Teacher.Id
                                                    && x.Subject.Id == item2.Subject.Id);

            Assert.AreEqual(items[0].Teacher.Id, newitem1.Teacher.Id);
            Assert.AreEqual(items[0].Subject.Id, newitem1.Subject.Id);
            Assert.AreEqual(items[1].Teacher.Id, newitem2.Teacher.Id);
            Assert.AreEqual(items[1].Subject.Id, newitem2.Subject.Id);
            _context.TeachSubjs.Remove(item1);
            _context.TeachSubjs.Remove(item2);
            _context.Subjects.Remove(subject1);
            _context.Subjects.Remove(subject2);
        }*/

        [TestMethod]
        public void ChangeItemTest()
        {
            var subject = new Subject { Name = "Test Linear Algebra" };
            _context.Subjects.Add(subject);
            var repo = new TeachSubjRepository(_context);
            var item = new TeachSubj
            {
                Teacher = _context.Teachers.FirstOrDefault(x => x.Id == 1),
                Subject = _context.Subjects.FirstOrDefault(x => x.Name == subject.Name)
            };
            repo.AddItem(item);
            int Id = _context.TeachSubjs.FirstOrDefault(x => x.Teacher.Id == item.Teacher.Id
                                                    && x.Subject.Id == item.Subject.Id).Id;
            var newitem = repo.GetItem(Id);
            newitem.Subject.Name = "Demo";
            repo.ChangeItem(newitem);
            var gotitem = repo.GetItem(Id);
            Assert.AreEqual(newitem.Teacher.Id, gotitem.Teacher.Id);
            Assert.AreEqual(newitem.Subject.Name, gotitem.Subject.Name);
            _context.TeachSubjs.Remove(newitem);
            _context.Subjects.Remove(subject);
        }
    }
}
