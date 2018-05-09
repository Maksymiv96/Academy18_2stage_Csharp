using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy18_2stage_Csharp
{
    class Car
    {
        private string _ident = "";//probably car number
        private double _balance;
        private string _type = "";

        public string Ident { get => _ident; set => _ident = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public string Type { get => _type; set => _type = value; }

        public Car(string IDnum, double balance, int type)
        {
            //if (!(type >= 1 && type <= 4)) Console.WriteLine("vvrond type of car");
            _ident = IDnum;
            _balance = Math.Round(balance, 2);
            _type = ((CarType)type).ToString() ;
        }

    }
}
