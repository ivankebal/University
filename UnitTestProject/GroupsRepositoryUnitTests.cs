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
    /// Test GroupsRepository
    /// </summary>
    [TestClass]
    public class GroupsRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            // to run test even if db is empty
            var spec = new Speciality { Name = "TestAutomation" };
            _context.Specialities.Add(spec);

            var repo = new GroupsRepository(_context);
            var item = new Group { Name = "TPP-18-4", Speciality = _context.Specialities.FirstOrDefault() };
            repo.AddItem(item);

            var newitem = _context.Groups.FirstOrDefault(x => x.Name == item.Name && x.Speciality.Id == item.Speciality.Id);
            Assert.AreEqual(item.Name, newitem.Name);
            Assert.AreEqual(item.Speciality, newitem.Speciality);
            _context.Groups.Remove(item);
            _context.Specialities.Remove(spec);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            // to run test even if db is empty
            var spec = new Speciality { Name = "TestAutomation" };
            _context.Specialities.Add(spec);

            var repo = new GroupsRepository(_context);
            Assert.AreEqual(_context.Groups.Count(), repo.AllItems.Count());
            var item1 = new Group { Name = "TPP-18-4", Speciality = _context.Specialities.FirstOrDefault(x => x.Name == spec.Name) };
            var item2 = new Group { Name = "TPP-18-5", Speciality = _context.Specialities.FirstOrDefault(x => x.Name == spec.Name) };
            repo.AddItem(item1);
            repo.AddItem(item2);
            Assert.AreEqual(_context.Groups.Count(), repo.AllItems.Count());
            _context.Groups.Remove(item1);
            _context.Groups.Remove(item2);
            _context.Specialities.Remove(spec);
        }

        [TestMethod]
        public void GetItemTest()
        {
            // to run test even if db is empty
            var spec = new Speciality { Name = "TestAutomation" };
            _context.Specialities.Add(spec);

            var repo = new GroupsRepository(_context);
            var item = new Group { Name = "TPP-18-3", Speciality = _context.Specialities.FirstOrDefault() };
            repo.AddItem(item);
            int Id = _context.Groups.FirstOrDefault(x => x.Name == item.Name && x.Speciality.Id == item.Speciality.Id).Id;
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
            Assert.AreEqual(item.Speciality, repo.GetItem(Id).Speciality);

            _context.Groups.Remove(item);
            _context.Specialities.Remove(spec);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new GroupsRepository(_context);
            var item1 = repo.GetItem(-1).Name;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            // to run test even if db is empty
            var spec1 = new Speciality { Name = "TestAutomation1" };
            _context.Specialities.Add(spec1);

            var repo = new GroupsRepository(_context);
            var item = new Group { Name = "TTT-18-1", Speciality = _context.Specialities.FirstOrDefault() };
            repo.AddItem(item);
            int Id = _context.Groups.FirstOrDefault(x => x.Name == item.Name && x.Speciality.Id == item.Speciality.Id).Id;
            Assert.AreEqual(item.Name, repo.GetItem(Id).Name);
            repo.DeleteItem(Id);

            _context.Specialities.Remove(spec1);

            var deleted = repo.GetItem(Id).Name;
        }

        [TestMethod]
        public void AddItemsTest()
        {
            // to run test even if db is empty
            var spec1 = new Speciality { Name = "TestAutomation1" };
            _context.Specialities.Add(spec1);

            var repo = new GroupsRepository(_context);
            var item1 = new Group { Name = "TTT-18-2", Speciality = _context.Specialities.FirstOrDefault() };
            var item2 = new Group { Name = "TTT-18-3", Speciality = _context.Specialities.FirstOrDefault() };
            Group[] items = new Group[] { item1, item2 };

            repo.AddItems(items);
            Assert.AreEqual(items[0].Name, _context.Groups.FirstOrDefault(x => x.Name == "TTT-18-2").Name);
            Assert.AreEqual(items[0].Speciality, _context.Groups.FirstOrDefault(x => x.Name == "TTT-18-2").Speciality);
            Assert.AreEqual(items[1].Name, _context.Groups.FirstOrDefault(x => x.Name == "TTT-18-3").Name);
            Assert.AreEqual(items[1].Speciality, _context.Groups.FirstOrDefault(x => x.Name == "TTT-18-3").Speciality);

            _context.Groups.Remove(item1);
            _context.Groups.Remove(item2);
            _context.Specialities.Remove(spec1);
        }

        [TestMethod]
        public void ChangeItemTest()
        {
            // to run test even if db is empty
            var spec1 = new Speciality { Name = "TestAutomation1" };
            _context.Specialities.Add(spec1);

            var repo = new GroupsRepository(_context);
            var item = new Group { Name = "TTT-17-10", Speciality = _context.Specialities.FirstOrDefault() };
            repo.AddItem(item);
            var DFDG = _context.Groups.ToList();
            int Id = _context.Groups.FirstOrDefault(x => x.Name == item.Name).Id;
            var newitem = repo.GetItem(Id);
            newitem.Name = "TTT-17-12";
            repo.ChangeItem(newitem);
            Assert.AreEqual(newitem.Name, _context.Groups.FirstOrDefault(x => x.Name == newitem.Name).Name);
            _context.Groups.Remove(newitem);

            _context.Specialities.Remove(spec1);
        }
    }
}
