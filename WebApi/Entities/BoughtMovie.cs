using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class BoughtMovie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
