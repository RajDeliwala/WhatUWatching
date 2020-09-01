using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Core.Models
{
    public class ShowSeason
    {
        // Variables for Show Seasons
        public string Id { get; set; }
        public string ShowSeasonAired { get; set; }

        // Default Constructor
        public ShowSeason() 
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
