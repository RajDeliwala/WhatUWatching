using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Core.Models
{
    public class OrderWatchListItem : BaseEntity
    {
        //Variables
        public string OrderId { get; set; }
        public string ShowId { get; set; }
        public string ShowName { get; set; }
        public string Image { get; set; }

        public string ShowDescription { get; set; }
        public  string ShowSeason { get; set; }

        public string ShowStudio { get; set; }
        public string ShowEpisodeCount { get; set; }
    }
}
