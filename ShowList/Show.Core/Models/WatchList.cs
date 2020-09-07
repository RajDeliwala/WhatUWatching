using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Core.Models
{
    public class WatchList : BaseEntity
    {
        public virtual ICollection<WatchListItem> WatchListItems { get; set; }

        // Base Constructor
        public WatchList()
        {
            this.WatchListItems = new List<WatchListItem>();
        }
    }
}
