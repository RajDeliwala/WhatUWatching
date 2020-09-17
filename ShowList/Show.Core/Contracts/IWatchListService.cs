using Show.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Show.Core.Contracts
{
    public interface IWatchListService
    {
        void AddToWatchList(HttpContextBase httpContext, string showId);

        void RemoveFromWatchList(HttpContextBase httpContext, string itemId);

        List<WatchListItemViewModel> GetWatchListItems(HttpContextBase httpContext);

        void ClearWatchList(HttpContextBase httpContext);
    }
}
