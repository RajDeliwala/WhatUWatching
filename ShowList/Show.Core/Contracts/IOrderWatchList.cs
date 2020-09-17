using Show.Core.Models;
using Show.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Core.Contracts
{
    public interface IOrderWatchList
    {
        //OrderWatchList function
        void CreateOrderWatchList(OrderWatchList baseOrderWatchList, List<WatchListItemViewModel> watchListItems);

        //Returns list of all watch lists
        List<OrderWatchList> GetOrderWatchLists();

        //Returns the single watch list
        OrderWatchList GetWatchList(string Id);

        //Update watchlist
        void UpdateWatchList(OrderWatchList orderWatchList);


    }
}
