using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Core.Models
{
    public class WatchListItem : BaseEntity
    {
        public string WatchListId { get; set; }
        public string ShowId { get; set; }


    }
}
