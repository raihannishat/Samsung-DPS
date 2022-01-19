using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samsung.Placing.Entities;

namespace Samsung.Placing.Seeds
{
    public static class DeveloperSeed
    {
        public static Developer[] Developers
        {
            get
            {
                return new Developer[]
                {
                    new Developer()
                    {
                        Id = 2518, 
                        Name = "Raihan Nishat", 
                        Skills = "OOP, Design Pattern, C#, .NET Core, AWS",
                        TeamId = 584
                    },

                    new Developer()
                    {
                        Id = 2548,
                        Name = "Asif Abdullah",
                        Skills = "C++, Algorithm, Data Structure",
                        TeamId = 149
                    },

                    new Developer()
                    {
                        Id = 2545,
                        Name = "Zihad Muhammad",
                        Skills = "C++, Degital Device, Robotics",
                        TeamId = 275
                    }
                };
            }
        }
    }
}
