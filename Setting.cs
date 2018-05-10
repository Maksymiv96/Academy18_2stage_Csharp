using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy18_2stage_Csharp
{
    sealed class Setting
    {
        private static int _timeout = 3;
        private static Dictionary<string, int> _dictionary = new Dictionary<string, int>()
            {
                { ((CarType)1).ToString(), 3},
                { ((CarType)2).ToString(), 5},
                { ((CarType)3).ToString(), 2},
                { ((CarType)4).ToString(), 1},
            };
        private static int _parkingspace = 150;
        private static double _fine = 1.5;
        
        


        private static readonly Lazy<Setting> Lazy = new Lazy<Setting>(() => new Setting());
        public static Setting Instance => Lazy.Value;

        public static Setting GetInstance()
        {
            return Lazy.Value;
        }


        public static int Timeout { get => _timeout; set => _timeout = value; }
        //public static Dictionary<string, int> Dictionary { get => _dictionary; set => _dictionary = value; }
        public static void DictionarySet(string key, int value)
        {
            if (_dictionary.ContainsKey(key))
            {
                _dictionary[key] = value;
            }
            else
            {
                _dictionary.Add(key, value);
            }
        }

        public static int DictionaryGet(string key)
        {
            int result = 0;

            if (_dictionary.ContainsKey(key))
            {
                result = _dictionary[key];
            }

            return result;
        }
        public static int Parkingspace { get => _parkingspace; set => _parkingspace = value; }
        public static double Fine { get => _fine; set => _fine = value; }

        //public static Setting Instance { get { return Lazy.Value; } }

        private Setting()
        {
            try
            {
                SetSetting();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nsetting initialization failed, set into standart");

                //throw ;
            }
        }

        public void SetSetting()
        {
            Console.WriteLine("Initialization setting\ninput timeout (sec) (you can scip it, just press enter)");
            int timeout = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            //Console.WriteLine(dictionary[((CarType)1).ToString()]);
            for (int i=1;i<5;i++)
            { 
                Console.WriteLine($"Set price for {((CarType)i).ToString()}");
                int tempprice = Convert.ToInt32( Console.ReadLine());
                dictionary.Add(((CarType)i).ToString(),tempprice);
            }
            Console.WriteLine("Inpt size of parking (int)");
            int parkingspace = (Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Set fine coef (double x,x)");
            Double fine = Convert.ToDouble(Console.ReadLine());
            _timeout = timeout;
            _dictionary = dictionary;
            _parkingspace = parkingspace;
            _fine = fine;

        }

        public void SetSetting(Dictionary<string,int> dict, int timeout = 3,  int parkingspace = 150, double fine = 1.5)
        {
            _dictionary = dict;
            _timeout = timeout;
            _parkingspace = parkingspace;
            _fine = fine;

        }
    }
}
