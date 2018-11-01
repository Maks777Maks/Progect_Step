using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<T> where T : class
    {
        Model1 db = null;
        DbSet<T> Set = null;

        public Repository()
        {
            db = new Model1();
            Set = db.Set<T>();
        }

        public void Create(T entity)
        {
            Set.Add(entity);
            db.SaveChanges();
        }

        public T Read(Func<T, bool> pred)
        {
            return Set.AsNoTracking().FirstOrDefault(pred);
        }

        public List<T> ReadAll()
        {
            return Set.AsNoTracking().ToList();
        }

        public List<T> ReadWhere(Func<T, bool> pred)
        {
            return Set.AsNoTracking().Where(pred).ToList();
        }


        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);  //db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Delete_Stud_Course(T entity)
        {
            Set.Remove(entity);  
            db.SaveChanges();
        }
    }
}
