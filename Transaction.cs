using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy18_2stage_Csharp
{
    class Transaction
    {
        DateTime _dateTime;
        string _iDcar;
        double _mOney;

        public DateTime DateTime { get => _dateTime; set => _dateTime = value; }
        public string IDcar { get => _iDcar; set => _iDcar = value; }
        public double MOney { get => _mOney; set => _mOney = value; }

        public Transaction(string ID, double charge)
        {
            DateTime = DateTime.Now;
            IDcar = ID;
            MOney = charge;
        }

        public string Shovv()
        {
            return ($"{DateTime} {IDcar} paid {MOney} uah");
        }
    }
}
