using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Academy18_2stage_Csharp
{
    class Parking
    {
        private List<Transaction> transactions = new List<Transaction>();
        private List<Car> cars = new List<Car>();
        private double balance;
        private double startbalance;

        public double Balance { get => balance; }
        public double Startbalance { get => startbalance; }

        private Parking()
        {
            try
            {
                Console.WriteLine("set parking starting balance");
                balance = Convert.ToInt32( Console.ReadLine());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nsetting initialization failed, set into standart");
                balance = 1;
                
                //throw ;
            }
            finally
            {
                startbalance = balance;
            }
        }
        
        private static readonly Lazy<Parking> Lazy = new Lazy<Parking>(() => new Parking());
        public static Parking Instance => Lazy.Value;



        public double gettotalearning()
        {
            return Startbalance - Balance;
        }
        


        public void setintoparking (Car car)
        {
            if (cars.Exists(x => x.Ident == car.Ident))
            {
                Console.WriteLine("Something vvrong, this car is already on the parking");

            }
            else
            if (cars.Count() < Setting.Parkingspace)
                cars.Add(car);
            else Console.WriteLine("Parking is full");
        }

        public void getfromparking (string IDcar)
        {
            if (cars.Count() == 0) throw new Exception("Parking is empty");
            if (!cars.Exists(x => x.Ident == IDcar))
            {
                throw new Exception("This car dosn't exists");
            }
            else
            {
                int indexofcar = cars.FindIndex(x => x.Ident == IDcar);
                if (cars[indexofcar].Balance >= 0)
                    cars.RemoveAt(indexofcar);
                else throw new Exception("This car ovver, try refill your ballance");
            }
        }
        
    }
}
