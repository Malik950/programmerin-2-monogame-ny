using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Health
    {
        enum health
        {
            Low,
            Medium,
            High,
        }
        static void Update(string[] args)
        {
            health myVar = health.Low;
            switch (myVar)
            {
                case health.Medium:
                    Console.WriteLine("Medium health");
                    break;
                case health.High:
                    Console.WriteLine("High health");
                    break;
             }
        }
    }
}
