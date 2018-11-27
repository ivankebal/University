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
    /// Test StudentsRepository
    /// </summary>
    [TestClass]
    public class StudentsRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            var repo = new StudentsRepository(_context);
            var item = new Student
            {
                FirstName = "John",
                MiddleName = "Anthony",
                LastName = "Cena",
                Address = "West Newbury",
                Birthday = new DateTime(1973, 04, 23),
                Email = "someadress@gmail.com",
                LogbookNumber = 4355,
                Group = _context.Groups.FirstOrDefault()
            };
            repo.AddItem(item);

            var newitem = _context.Students.FirstOrDefault(x => x.LogbookNumber == item.LogbookNumber);
            Assert.AreEqual(item.FirstName, newitem.FirstName);
            Assert.AreEqual(item.MiddleName, newitem.MiddleName);
            Assert.AreEqual(item.LastName, newitem.LastName);
            Assert.AreEqual(item.Address, newitem.Address);
            Assert.AreEqual(item.Birthday, newitem.Birthday);
            Assert.AreEqual(item.Email, newitem.Email);
            Assert.AreEqual(item.LogbookNumber, newitem.LogbookNumber);
            _context.Students.Remove(item);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            var repo = new StudentsRepository(_context);
            Assert.AreEqual(_context.Students.Count(), repo.AllItems.Count());
            var item1 = new Student
            {
                FirstName = "John",
                MiddleName = "Anthony",
                LastName = "Cena",
                Address = "West Newbury",
                Birthday = new DateTime(1973, 04, 23),
                Email = "someadress@gmail.com",
                LogbookNumber = 4355,
                Group = _context.Groups.FirstOrDefault()
            };
            var item2 = new Student
            {
                FirstName = "Kurt",
                MiddleName = "Unknown",
                LastName = "Wallander",
                Address = "Ystad",
                Birthday = new DateTime(1961, 05, 23),
                Email = "wallander@gmail.com",
                LogbookNumber = 4366,
                Group = _context.Groups.FirstOrDefault()
            };
            repo.AddItem(item1);
            repo.AddItem(item2);
            Assert.AreEqual(_context.Students.Count(), repo.AllItems.Count());
            _context.Students.Remove(item1);
            _context.Students.Remove(item2);
        }

        [TestMethod]
        public void GetItemTest()
        {
            var repo = new StudentsRepository(_context);
            var item = new Student
            {
                FirstName = "John",
                MiddleName = "Anthony",
                LastName = "Cena",
                Address = "West Newbury",
                Birthday = new DateTime(1973, 04, 23),
                Email = "someadress@gmail.com",
                LogbookNumber = 4355,
                Group = _context.Groups.FirstOrDefault()
            };
            repo.AddItem(item);
            int Id = _context.Students.FirstOrDefault(x => x.LogbookNumber == item.LogbookNumber).Id;
            var newitem = repo.GetItem(Id);
            Assert.AreEqual(item.FirstName, newitem.FirstName);
            Assert.AreEqual(item.MiddleName, newitem.MiddleName);
            Assert.AreEqual(item.LastName, newitem.LastName);
            Assert.AreEqual(item.Address, newitem.Address);
            Assert.AreEqual(item.Birthday, newitem.Birthday);
            Assert.AreEqual(item.Email, newitem.Email);
            Assert.AreEqual(item.LogbookNumber, newitem.LogbookNumber);

            _context.Students.Remove(item);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new StudentsRepository(_context);
            var item1 = repo.GetItem(-1).FirstName;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            var repo = new StudentsRepository(_context);
            var item = new Student
            {
                FirstName = "Kurt",
                MiddleName = "Unknown",
                LastName = "Wallander",
                Address = "Ystad",
                Birthday = new DateTime(1961, 05, 23),
                Email = "wallander@gmail.com",
                LogbookNumber = 4366,
                Group = _context.Groups.FirstOrDefault()
            };
            int Id = _context.Students.FirstOrDefault(x => x.LogbookNumber == item.LogbookNumber).Id;
            Assert.AreEqual(item.LogbookNumber, repo.GetItem(Id).LogbookNumber);
            repo.DeleteItem(Id);
            var deleted = repo.GetItem(Id).LogbookNumber;
        }

        [TestMethod]
        public void AddItemsTest()
        {
            var repo = new StudentsRepository(_context);
            var item1 = new Student
            {
                FirstName = "John",
                MiddleName = "Anthony",
                LastName = "Cena",
                Address = "West Newbury",
                Birthday = new DateTime(1973, 04, 23),
                Email = "someadress@gmail.com",
                LogbookNumber = 4355,
                Group = _context.Groups.FirstOrDefault()
            };
            var item2 = new Student
            {
                FirstName = "Paul",
                MiddleName = "Unknown",
                LastName = "Jacobson",
                Address = "Manchester",
                Birthday = new DateTime(1968, 11, 02),
                Email = "jacobson@gmail.com",
                LogbookNumber = 4299,
                Group = _context.Groups.FirstOrDefault()
            };
            Student[] items = new Student[] { item1, item2 };

            repo.AddItems(items);
            var newitem1 = _context.Students.FirstOrDefault(x => x.LogbookNumber == 4355);
            var newitem2 = _context.Students.FirstOrDefault(x => x.LogbookNumber == 4299);
            Assert.AreEqual(items[0].LogbookNumber, newitem1.LogbookNumber);
            Assert.AreEqual(items[0].FirstName, newitem1.FirstName);
            Assert.AreEqual(items[0].MiddleName, newitem1.MiddleName);
            Assert.AreEqual(items[0].LastName, newitem1.LastName);
            Assert.AreEqual(items[0].Address, newitem1.Address);
            Assert.AreEqual(items[0].Birthday, newitem1.Birthday);
            Assert.AreEqual(items[0].Email, newitem1.Email);

            Assert.AreEqual(items[1].LogbookNumber, newitem2.LogbookNumber);
            Assert.AreEqual(items[1].FirstName, newitem2.FirstName);
            Assert.AreEqual(items[1].MiddleName, newitem2.MiddleName);
            Assert.AreEqual(items[1].LastName, newitem2.LastName);
            Assert.AreEqual(items[1].Address, newitem2.Address);
            Assert.AreEqual(items[1].Birthday, newitem2.Birthday);
            Assert.AreEqual(items[1].Email, newitem2.Email);

            _context.Students.Remove(item1);
            _context.Students.Remove(item2);
        }

        [TestMethod]
        public void ChangeItemTest()
        {
            var repo = new StudentsRepository(_context);
            var item = new Student
            {
                FirstName = "Kurt",
                MiddleName = "Unknown",
                LastName = "Wallander",
                Address = "Ystad",
                Birthday = new DateTime(1961, 05, 23),
                Email = "wallander@gmail.com",
                LogbookNumber = 4366,
                Group = _context.Groups.FirstOrDefault()
            };
            repo.AddItem(item);
            int Id = _context.Students.FirstOrDefault(x => x.LogbookNumber == item.LogbookNumber).Id;
            var newitem = repo.GetItem(Id);
            newitem.Email = "kurtwallander@gmail.com";
            repo.ChangeItem(newitem);
            var gotitem = repo.GetItem(Id);
            Assert.AreEqual(newitem.FirstName, gotitem.FirstName);
            Assert.AreEqual(newitem.MiddleName, gotitem.MiddleName);
            Assert.AreEqual(newitem.LastName, gotitem.LastName);
            Assert.AreEqual(newitem.Address, gotitem.Address);
            Assert.AreEqual(newitem.Birthday, gotitem.Birthday);
            Assert.AreEqual(newitem.Email, gotitem.Email);
            Assert.AreEqual(newitem.LogbookNumber, gotitem.LogbookNumber);
            _context.Students.Remove(newitem);
        }
    }
}
