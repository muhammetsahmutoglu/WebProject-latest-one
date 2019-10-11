using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.ORM.Context;
using WebProject.Data.ORM.Entity;
using WebProject.Data.ORM.Enum;

namespace WebProject.BLL.BaseService
{
    public class ServiceBase<T> where T : BaseEntity
    {
        private static ProjectContext _context;

        public ProjectContext context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ProjectContext();
                    return _context;
                }
                return _context;
            }
            set { _context = value; }
        }
        public int Save()
        {
            return context.SaveChanges();
        }

        public void Add(List<T> items)
        {
            context.Set<T>().AddRange(items);
            Save();
        }

        public void Add(T item)
        {
            context.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => context.Set<T>().Any(exp);

        public List<T> GetActive()
        {
            return context.Set<T>().Where(x => x.Status == Status.Active || x.Status==Status.Updated).ToList();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).ToList();
        }

        public void Update(T item)
        {
            T updated = GetByID(item.ID);
            DbEntityEntry entry = context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }

        public void Remove(int id)
        {
            T item = GetByID(id);
            item.Status = Status.Deleted;
            Update(item);
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = Status.Deleted;
                Update(item);
            }
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return context.Set<T>().Where(exp).FirstOrDefault();
        }
    }
}
