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
    }
}
