using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Show.Core.Models;

namespace Show.DataAccess.InMemory
{
    public class ShowRepo
    {
        //Base needs
        ObjectCache cache = MemoryCache.Default;
        List<ShowModel> shows;

        //Constructor
        public ShowRepo()
        {
            shows = cache["shows"] as List<ShowModel>;
            if (shows == null)
            {
                shows = new List<ShowModel>();
            }
        }

        //Commit function
        public void Commit()
        {
            cache["shows"] = shows;
        }

        //Insert function
        public void Insert(ShowModel s)
        {
            shows.Add(s);
        }

        //Update function
        public void Update(ShowModel s)
        {
            ShowModel showToUpdate = shows.Find(p => p.Id == s.Id);
            if (showToUpdate != null)
            {
                showToUpdate = s;
            }
            else
            {
                throw new Exception("Show not found");
            }
        }

        //Find function
        public ShowModel Find(string Id)
        {
            ShowModel show = shows.Find(p => p.Id == Id);
            if (show != null)
            {
                return show;
            }
            else
            {
                throw new Exception("Show not found");
            }
        }

        //Queryable collection fucntion
        public IQueryable<ShowModel> Collection()
        {
            return shows.AsQueryable();
        }

        //Delete show function
        public void Delete(string Id)
        {
            ShowModel showToDelete = shows.Find(p => p.Id == Id);
            if(showToDelete != null)
            {
                shows.Remove(showToDelete);
            }
            else
            {
                throw new Exception("Show no found");
            }
        }

    }
}
