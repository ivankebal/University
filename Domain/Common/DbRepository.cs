using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class DbRepository<T> : IDbRepository<T>
        where T : class, IDbEntity
    {
        private DbContext _context;
        public DbRepository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> AllItems
        {
            get => _context.Set<T>();
        }

        public bool AddItem(T item)
        {
            _context.Set<T>().Add(item);
            return SaveChanges();
        }

        public bool AddItems(IEnumerable<T> items)
        {
            _context.Set<T>().AddRange(items);
            return SaveChanges();
        }

        public bool ChangeItem(T item)
        {
            T changes = _context.Set<T>().FirstOrDefault(x => x.Id == item.Id);
            if (changes == null) return false;
            changes = item;
            return SaveChanges();
        }

        public bool DeleteItem(int id)
        {
            T removed = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            if (removed == null) return false;
            _context.Set<T>().Remove(removed);
            return SaveChanges();
        }

        public T GetItem(int id)
        {
           return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
#pragma warning disable 0168
            catch (Exception e)
#pragma warning restore 0168
            {
                return false;
            }
        }
    }
}
