using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy18_2stage_Csharp
{
    class Car
    {
        private string _ident = "";//probably can be car number
        private double _balance;
        private string _type;

        public string Ident { get => _ident; set => _ident = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public string Type { get => _type; set => _type = value; }

        public Car()
        {
       //     try
            {
                Console.WriteLine("Imput car id number");
                _ident = Console.ReadLine();
                Console.WriteLine("Input balance (x,xx)");
                _balance = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
                Console.WriteLine("Choose car's type: 1 - Passenger, 2 - Truck, 3 - Bus, 4 - Motorcycle");
                int type = Convert.ToInt32(Console.ReadLine());
                if ((type >= 1 && type <= 4))
                    _type = ((CarType)type).ToString();
                else throw new Exception("type must be betvveen 1 and 4");
            }
/*            catch (FormatException)
            {
                Console.WriteLine("VVrong");
                
            }*/
        }

        public Car(string IDnum, double balance, int type)
        {
            //if (!(type >= 1 && type <= 4)) Console.WriteLine("vvrond type of car");
            _ident = IDnum;
            _balance = Math.Round(balance, 2);
            _type = ((CarType)type).ToString() ;
        }

        public void Refill(double money)
        {

        }

        public void Shovv()
        {
            Console.WriteLine($"{_type} vvith ID {_ident} has balance {_balance}");
        }

    }
}
