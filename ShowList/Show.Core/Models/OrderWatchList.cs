using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Core.Models
{
    public class OrderWatchList : BaseEntity
    {
        //Default constructor
        public OrderWatchList()
        {
            this.OrderItems = new List<OrderWatchListItem>();
        }

        //Variables
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ListStatus { get; set; }
        //List of OrderWatchListItems
        public virtual ICollection<OrderWatchListItem> OrderItems { get; set; }

    }
}
