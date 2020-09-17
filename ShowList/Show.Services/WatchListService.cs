using Show.Core.Models;
using Show.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Show.Core.ViewModels;

namespace Show.Services
{
    public class WatchListService : IWatchListService
    {
        IRepo<ShowModel> showContext;
        IRepo<WatchList> watchListContext;
        //IRepo<WatchListItem> watchListItemsContext;

        public const string WatchListSessionName = "ShowWatchList";

        // Default constructor
        public WatchListService(IRepo<ShowModel> ShowContext, IRepo<WatchList> WatchListContext)
        {
            this.showContext = ShowContext;
            this.watchListContext = WatchListContext;
            //this.watchListItemsContext = watchListItemsContext;
        }


        //Internal Methods

        //Pulling watch list
        private WatchList GetWatchList(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(WatchListSessionName);
            WatchList watchList = new WatchList();
            if (cookie != null)
            {
                string watchListId = cookie.Value;
                if (!string.IsNullOrEmpty(watchListId))
                {
                    watchList = watchListContext.Find(watchListId);
                }
                else
                {
                    if (createIfNull)
                    {
                        watchList = CreateNewWatchList(httpContext);
                    }
                }
            }
            else
            {
                if (createIfNull)
                {
                    watchList = CreateNewWatchList(httpContext);
                }
            }
            return watchList;

        }

        //Creating watch list
        private WatchList CreateNewWatchList(HttpContextBase httpContext)
        {
            WatchList watchList = new WatchList();
            watchListContext.Insert(watchList);
            watchListContext.Commit();

            HttpCookie cookie = new HttpCookie(WatchListSessionName);
            cookie.Value = watchList.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);
            return watchList;
        }

        //Add to watch list
        public void AddToWatchList(HttpContextBase httpContext, string showId)
        {
            WatchList watchList = GetWatchList(httpContext, true);
            WatchListItem show = watchList.WatchListItems.FirstOrDefault(i => i.ShowId == showId);

            if (show == null)
            {
                show = new WatchListItem()
                {
                    WatchListId = watchList.Id,
                    ShowId = showId
                };
                watchList.WatchListItems.Add(show);
            }
            
            watchListContext.Commit();
        }

        //Remove show from watch list
        
        public void RemoveFromWatchList(HttpContextBase httpContext, string itemId)
        {
            //watchListItemsContext.Delete(itemId);
            //watchListItemsContext.Commit();

            WatchList watchList = GetWatchList(httpContext, true);
            WatchListItem item = watchList.WatchListItems.FirstOrDefault(i => i.ShowId == itemId);
            if (item != null)
            {
                watchList.WatchListItems.Remove(item);

                watchListContext.Commit();
            }

        }

        //Get list of items
        public List<WatchListItemViewModel> GetWatchListItems(HttpContextBase httpContext)
        {
            WatchList watchlist = GetWatchList(httpContext, false);

            if (watchlist != null)
            {
                var result = (from w in watchlist.WatchListItems
                              join s in showContext.Collection()
                              on w.ShowId equals s.Id
                              select new WatchListItemViewModel()
                              {
                                  Id = w.ShowId,
                                  showName = s.Name,
                                  Image = s.Image,
                                  showDescription = s.Description,
                                  showSeason = s.PremieredSeason,
                                  showStudio = s.Studio,
                                  showEpisodeCount = s.EpisodeCount
                              }).ToList();

                return result;
            }
            else
            {
                return new List<WatchListItemViewModel>();
            }
        }


        //Clear WatchList Service
        public void ClearWatchList(HttpContextBase httpContext)
        {
            WatchList watchList = GetWatchList(httpContext, false);
            watchList.WatchListItems.Clear();
            watchListContext.Commit();
        }

        

    }
}
