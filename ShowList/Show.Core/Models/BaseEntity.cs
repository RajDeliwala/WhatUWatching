using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Show.Core.Models
{
    public abstract class BaseEntity
    {
        // intertnal variables 
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        // Base constructor
        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }

    }
}
