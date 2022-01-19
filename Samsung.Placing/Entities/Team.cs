using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samsung.Data;

namespace Samsung.Placing.Entities
{
    public class Team : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Developer> Developers { get; set; }
    }
}
