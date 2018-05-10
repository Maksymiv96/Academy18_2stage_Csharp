using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Academy18_2stage_Csharp
{
    class Parking
    {
        private static List<Transaction> transactions = new List<Transaction>();
        private static List<Car> cars = new List<Car>();

        internal static List<Transaction> Transactions { get => transactions; set => transactions = value; }
        internal static List<Car> Cars { get => cars; set => cars = value; }

        private static double balance;
        private double startbalance;

        public static double Balance { get => balance; set => balance = value; }
        public double Startbalance { get => startbalance; }

        private static TimerCallback tm = new TimerCallback(takecharge);
        private Timer _timer = new Timer(tm, null, 0, Setting.Timeout*1000);

        private static TimerCallback tm2 = new TimerCallback(creatinglog);
        private Timer _timer2 = new Timer(tm2, null, 0, 60 * 1000);

        private Parking()
        {
            try
            {
                Console.WriteLine("set parking starting balance (not necessary, can skip it pressing enter)");
                Balance = Convert.ToInt32( Console.ReadLine());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nsetting initialization failed, set into standart");
                Balance = 1;
                
                //throw ;
            }
            finally
            {
                startbalance = Balance;
            }
        }
        
        private static readonly Lazy<Parking> Lazy = new Lazy<Parking>(() => new Parking());
        public static Parking Instance => Lazy.Value;

        

        private static void takecharge(object obj)
        {
            foreach (Car car in Cars)
            {
                if (car.Balance >= Setting.DictionaryGet(car.Type))
                {
                    Balance += Setting.DictionaryGet(car.Type);
                    car.Balance -= Setting.DictionaryGet(car.Type);
                }
                else if (car.Balance > 0)
                {
                    Balance += car.Balance;
                    car.Balance -= Setting.DictionaryGet(car.Type) * Setting.Fine;
                }
                else if (car.Balance <=0)
                {
                    car.Balance -= Setting.DictionaryGet(car.Type) * Setting.Fine;
                }
                //Console.WriteLine(car.Shovv());
                //Console.WriteLine(balance);
                Transactions.Add(new Transaction(car.Ident,Setting.DictionaryGet(car.Type)));
            }
        }


        public void shovvlog()
        {
            foreach (Transaction trans in Transactions)
            {
                if (timetosec(trans.DateTime) > (timetosec(DateTime.Now) - 60))
                {
                    Console.WriteLine(trans.Shovv());
                }

            }
            
        }

        private static void creatinglog(object obj)
        {
            double sum = 0;
            //Console.WriteLine("current time " + DateTime.Now);
            foreach (Transaction trans in Transactions)
            {
                if (timetosec(trans.DateTime) > (timetosec(DateTime.Now) - 60))
                {
                    sum += trans.MOney;
                }
                    
            }
            string path = "transaction.log";
            
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{DateTime.Now}: total income for last minute: {sum}");


                }
           
        }

        static int timetosec(DateTime time)
        {
            DateTime dt = TimeZoneInfo.ConvertTimeToUtc(time);
            DateTime dt2018 = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan tsInterval = dt.Subtract(dt2018);
            return Convert.ToInt32(tsInterval.TotalSeconds);
        }


        public double gettotalearning()
        {
            return Balance - Startbalance;
        }
        


        public void setintoparking (Car car)
        {
            if (Cars.Exists(x => x.Ident == car.Ident))
            {
                Console.WriteLine("Something vvrong, this car is already on the parking");

            }
            else
            if (Cars.Count() < Setting.Parkingspace)
                Cars.Add(car);
            else Console.WriteLine("Parking is full");
        }

        public void getfromparking (string IDcar)
        {
            if (Cars.Count() == 0) throw new Exception("Parking is empty");
            if (!Cars.Exists(x => x.Ident == IDcar))
            {
                throw new Exception("This car dosn't exists");
            }
            else
            {
                int indexofcar = Cars.FindIndex(x => x.Ident == IDcar);
                if (Cars[indexofcar].Balance >= 0)
                    Cars.RemoveAt(indexofcar);
                else throw new Exception("This car ovver, try refill your ballance");
            }
        }
        
    }
}
