using Show.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Show.DataAccess.InMemory
{
    public class InMemoryRepo<T> where T : BaseEntity 
    {
        // Set-up
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        // Basic Constructor
        public InMemoryRepo()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        }

        // Commit method
        public void Commit()
        {
            cache[className] = items;
        }

        // Insert method
        public void Insert(T t)
        {
            items.Add(t);
        }

        // Update method
        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);
            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + " Not found");
            }
        }

        // Find function
        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + " Not found");
            }
        }

        // IQueryable function
        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        // Delete function
        public void Delete(string Id)
        {
            T tToDelete = items.Find(i => i.Id == Id);
            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className = " Not found");
            }
        }


    }
}
