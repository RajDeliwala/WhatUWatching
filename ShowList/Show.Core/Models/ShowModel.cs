using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Core.Models
{
    public class ShowModel
    {
        /** Show variables that need to be recorded **/

        //Unique Id per show
        public string Id { get; set; }
        //Name of the show
        [DisplayName("Show Name")]
        public string Name { get; set; }
        //Breif description of the show
        public string Description { get; set; }
        //Genere of the show
        public string Genere1 { get; set; }
        //Genere of the show
        public string Genere2 { get; set; }
        //Genere of the show
        public string Genere3 { get; set; }
        //Genere of the show
        public string Genere4 { get; set; }
        //Genere of the show
        public string Genere5 { get; set; }
        //Image of the show
        public string Image { get; set; }
        //What season the show premiered in
        public string PremieredSeason { get; set; }
        //Number of episodes
        public string EpisodeCount { get; set; }
        //Studio that is working on the show
        public string Studio { get; set; }


        //Constructor to initialize a random ID per new product
        public ShowModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }







    }
}
