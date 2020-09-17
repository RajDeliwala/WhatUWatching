using Show.Core.Contracts;
using Show.Core.Models;
using Show.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Services
{
    public class OrderWatchListService : IOrderWatchList
    {
        //Initializing context
        IRepo<OrderWatchList> orderContext;

        //Default Constructor
        public OrderWatchListService(IRepo<OrderWatchList> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrderWatchList(OrderWatchList baseOrderWatchList, List<WatchListItemViewModel> watchListItems)
        {
            foreach(var item in watchListItems)
            {
                baseOrderWatchList.OrderItems.Add(new OrderWatchListItem()
                {
                    ShowId = item.Id,
                    ShowName = item.showName,
                    Image = item.Image,
                    ShowDescription = item.showDescription,
                    ShowSeason = item.showSeason,
                    ShowStudio = item.showStudio,
                    ShowEpisodeCount = item.showEpisodeCount

                });
            }

            orderContext.Insert(baseOrderWatchList);
            orderContext.Commit();
        }
    }
}
