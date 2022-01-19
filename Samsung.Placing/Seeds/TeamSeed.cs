using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samsung.Placing.Entities;

namespace Samsung.Placing.Seeds
{
    public static class TeamSeed
    {
        public static Team[] Teams
        {
            get
            {
                return new Team[]
                {
                    new Team() { Id = 304, Name = "DevOps" },
                    new Team() { Id = 584, Name = "Cloud" },
                    new Team() { Id = 275, Name = "Embedded" },
                    new Team() { Id = 149, Name = "TizenOS" },
                    new Team() { Id = 791, Name = "SamsungTV" }
                };
            }
        }
    }
}
