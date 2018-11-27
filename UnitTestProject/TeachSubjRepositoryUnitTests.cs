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
    public class AudLectsRepositoryUnitTest
    {
        MyAppDbContext _context = new MyAppDbContext("UniversityTest");
        [TestMethod]
        public void AddItemTest()
        {
            var audience = new Audience { Name = "1203" };
            _context.Audiences.Add(audience);
            var repo = new AudLectRepository(_context);
            var item = new AudLect
            {
                Audience = _context.Audiences.FirstOrDefault(x => x.Name == audience.Name),
                Lection = _context.Lections.FirstOrDefault(s => s.Id == 1),
                Group = _context.Groups.FirstOrDefault(s => s.Id == 1),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(t => t.Id == 1)
            };
            repo.AddItem(item);
            var newitem = _context.AudLects.FirstOrDefault(x => x.Audience.Id == item.Audience.Id 
                                                    && x.Lection.Id == item.Lection.Id
                                                    && x.Group.Id == item.Group.Id
                                                    && x.TeachSubj.Id == item.TeachSubj.Id);
            Assert.AreEqual(item.Audience.Id, newitem.Audience.Id);
            Assert.AreEqual(item.Lection.Id, newitem.Lection.Id);
            Assert.AreEqual(item.Group.Id, newitem.Group.Id);
            Assert.AreEqual(item.TeachSubj.Id, newitem.TeachSubj.Id);
            _context.AudLects.Remove(item);
            _context.Audiences.Remove(audience);
        }

        [TestMethod]
        public void AllItemsTest()
        {
            var audience = new Audience { Name = "1203" };
            _context.Audiences.Add(audience);
            var repo = new AudLectRepository(_context);
            Assert.AreEqual(_context.AudLects.Count(), repo.AllItems.Count());
            var item1 = new AudLect
            {
                Audience = _context.Audiences.FirstOrDefault(x => x.Name == audience.Name),
                Lection = _context.Lections.FirstOrDefault(s => s.Id == 1),
                Group = _context.Groups.FirstOrDefault(s => s.Id == 1),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(t => t.Id == 1)
            };
            repo.AddItem(item1);
            Assert.AreEqual(_context.AudLects.Count(), repo.AllItems.Count());
            _context.AudLects.Remove(item1);
            _context.Audiences.Remove(audience);
        }
        [TestMethod]
        public void GetItemTest()
        {
            var audience = new Audience { Name = "1203" };
            _context.Audiences.Add(audience);
            var repo = new AudLectRepository(_context);
            var item = new AudLect
            {
                Audience = _context.Audiences.FirstOrDefault(x => x.Name == audience.Name),
                Lection = _context.Lections.FirstOrDefault(s => s.Id == 1),
                Group = _context.Groups.FirstOrDefault(s => s.Id == 1),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(t => t.Id == 1)
            };
            repo.AddItem(item);
            int Id = _context.AudLects.FirstOrDefault(x => x.Audience.Id == item.Audience.Id
                                                    && x.Lection.Id == item.Lection.Id
                                                    && x.Group.Id == item.Group.Id
                                                    && x.TeachSubj.Id == item.TeachSubj.Id).Id;
            var newitem = repo.GetItem(Id);
            Assert.AreEqual(item.Audience.Id, newitem.Audience.Id);
            Assert.AreEqual(item.Lection.Id, newitem.Lection.Id);
            Assert.AreEqual(item.Group.Id, newitem.Group.Id);
            Assert.AreEqual(item.TeachSubj.Id, newitem.TeachSubj.Id);
            _context.AudLects.Remove(item);
            _context.Audiences.Remove(audience);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetItemExceptionTest()
        {
            var repo = new AudLectRepository(_context);
            var item1 = repo.GetItem(-1).Lection.Id;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemTest()
        {
            var audience = new Audience { Name = "1203" };
            _context.Audiences.Add(audience);
            var repo = new AudLectRepository(_context);
            var item = new AudLect
            {
                Audience = _context.Audiences.FirstOrDefault(x => x.Name == audience.Name),
                Lection = _context.Lections.FirstOrDefault(s => s.Id == 1),
                Group = _context.Groups.FirstOrDefault(s => s.Id == 1),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(t => t.Id == 1)
            };
            repo.AddItem(item);
            int Id = _context.AudLects.FirstOrDefault(x => x.Audience.Id == item.Audience.Id
                                                    && x.Lection.Id == item.Lection.Id
                                                    && x.Group.Id == item.Group.Id
                                                    && x.TeachSubj.Id == item.TeachSubj.Id).Id;
            var newitem = repo.GetItem(Id);
            Assert.AreEqual(item.Audience.Id, newitem.Audience.Id);
            Assert.AreEqual(item.Lection.Id, newitem.Lection.Id);
            Assert.AreEqual(item.Group.Id, newitem.Group.Id);
            Assert.AreEqual(item.TeachSubj.Id, newitem.TeachSubj.Id);
            repo.DeleteItem(Id);
            _context.Audiences.Remove(audience);
            Assert.AreEqual(item.Audience.Id, repo.GetItem(Id).Audience.Id);
        }

        [TestMethod]
        public void ChangeItemTest()
        {
            var audience = new Audience { Name = "1203" };
            _context.Audiences.Add(audience);
            var repo = new AudLectRepository(_context);
            var item = new AudLect
            {
                Audience = _context.Audiences.FirstOrDefault(x => x.Name == audience.Name),
                Lection = _context.Lections.FirstOrDefault(s => s.Id == 1),
                Group = _context.Groups.FirstOrDefault(s => s.Id == 1),
                TeachSubj = _context.TeachSubjs.FirstOrDefault(t => t.Id == 1)
            };
            repo.AddItem(item);
            int Id = _context.AudLects.FirstOrDefault(x => x.Audience.Id == item.Audience.Id
                                                    && x.Lection.Id == item.Lection.Id
                                                    && x.Group.Id == item.Group.Id
                                                    && x.TeachSubj.Id == item.TeachSubj.Id).Id;
            var newitem = repo.GetItem(Id);
            newitem.Audience.Name = "1221";
            repo.ChangeItem(newitem);
            var gotitem = repo.GetItem(Id);
            Assert.AreEqual(newitem.Audience.Name, gotitem.Audience.Name);
            Assert.AreEqual(newitem.Lection.Id, gotitem.Lection.Id);
            Assert.AreEqual(newitem.Group.Id, gotitem.Group.Id);
            Assert.AreEqual(newitem.TeachSubj.Id, gotitem.TeachSubj.Id);
            _context.AudLects.Remove(newitem);
            _context.Audiences.Remove(audience);
        }
    }
}
