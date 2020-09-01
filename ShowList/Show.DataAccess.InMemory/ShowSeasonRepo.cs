using Show.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Show.DataAccess.InMemory
{
    public class ShowSeasonRepo
    {
        //Base needs
        ObjectCache cache = MemoryCache.Default;
        List<ShowSeason> showSeason;

        //Constructor
        public ShowSeasonRepo()
        {
            showSeason = cache["showSeason"] as List<ShowSeason>;
            if (showSeason == null)
            {
                showSeason = new List<ShowSeason>();
            }
        }

        //Commit function
        public void Commit()
        {
            cache["showSeason"] = showSeason;
        }

        //Insert function
        public void Insert(ShowSeason s)
        {
            showSeason.Add(s);
        }

        //Update function
        public void Update(ShowSeason s)
        {
            ShowSeason showSeasonToUpdate = showSeason.Find(p => p.Id == s.Id);
            if (showSeasonToUpdate != null)
            {
                showSeasonToUpdate = s;
            }
            else
            {
                throw new Exception("Show Season not found");
            }
        }

        //Find function
        public ShowSeason Find(string Id)
        {
            ShowSeason showSeasonToFind = showSeason.Find(p => p.Id == Id);
            if (showSeasonToFind != null)
            {
                return showSeasonToFind;
            }
            else
            {
                throw new Exception("Show Season not found");
            }
        }

        //Queryable collection fucntion
        public IQueryable<ShowSeason> Collection()
        {
            return showSeason.AsQueryable();
        }

        //Delete show function
        public void Delete(string Id)
        {
            ShowSeason showSeasonToDelete = showSeason.Find(p => p.Id == Id);
            if (showSeasonToDelete != null)
            {
                showSeason.Remove(showSeasonToDelete);
            }
            else
            {
                throw new Exception("Show no found");
            }
        }

    }
}
