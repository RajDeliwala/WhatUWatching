using Show.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        //Default constructor to initalize the database
        public DataContext(): base("DefaultConnection")
        {

        }

        public DbSet<ShowModel> show { get; set; }
        public DbSet<ShowSeason> showseaon { get; set; }
    }
}
