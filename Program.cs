using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Academy18_2stage_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Setting settings;
            settings = Setting.Instance;
            

            Menu menu = new Menu();
            Console.ReadKey();
            
        }
    }
    enum CarType
    {
        Passenger = 1,Truck,Bus,Motorcycle
    }
}
