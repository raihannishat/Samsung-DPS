using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samsung.Data;

namespace Samsung.Placing.Entities
{
    public class Developer : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skills { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
