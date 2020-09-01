using Show.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Core.ViewModels
{
    public class ShowManagerViewModel
    {
        public ShowModel show { get; set; }
        public IEnumerable<ShowSeason> showSeason { get; set; }

    }
}
