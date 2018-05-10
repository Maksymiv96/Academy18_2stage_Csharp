using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Academy18_2stage_Csharp
{
    class Menu
    {
        public Menu()
        {
            Parking pg = Parking.Instance;

            string menu;
            help();
            
            do
            {
                Console.WriteLine("\n\tVVaiting for your command, sir");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "help":
                        {
                            help();
                            break;
                        }
                    case "clear":
                        {
                            Console.Clear();
                            break;
                        }
                    case "setting":
                        {
                            Setting settings;
                            settings = Setting.Instance;
                            settings.SetSetting();
                            break;
                        }
                    case "put":
                        {
                            Parking parking = Parking.Instance;
                            Car car;
                            try
                            {
                                car = new Car();
                                car.Shovv();
                                parking.setintoparking(car);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Your data is invalid:(\n" + ex.Message);
                            }
                            
                            break;
                        }
                    case "get":
                        {
                            Parking parking = Parking.Instance;
                            try
                            {
                                Console.WriteLine("Choose your car");

                                parking.getfromparking(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case "reffil":
                        {
                            Console.WriteLine("Choose your car");
                            string car = Console.ReadLine();
                            try
                            {
                                Console.WriteLine("insert money");
                                double money = Convert.ToDouble(Console.ReadLine());
                                Parking parking = Parking.Instance;
                                int index = Parking.Cars.FindIndex(x => x.Ident.Equals(car));
                                if (money >= Math.Abs(Parking.Cars[index].Balance))
                                {
                                    Parking.Balance += Math.Abs(Parking.Cars[index].Balance);
                                    Parking.Cars[index].Balance += money;
                                }
                                else
                                {
                                    Parking.Balance += money;
                                    Parking.Cars[index].Balance += money;

                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            
                            break;
                        }
                    case "money":
                        {
                            Console.WriteLine(pg.gettotalearning());
                            break;
                        }
                    case "freepark":
                        {
                            Console.WriteLine("Total free spaces: " + (Setting.Parkingspace - Parking.Cars.Count));
                            break;
                        }
                    case "trans":
                        {
                            pg.shovvlog();
                            break;
                        }
                    case "exit":
                        {
                            Console.WriteLine("auf vviedersehen mein lieber freund");
                            break;
                        }
                    case "log":
                        {
                            if (File.Exists("transaction.log"))
                            {
                                string text = System.IO.File.ReadAllText("transaction.log");
                                Console.WriteLine(text);
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("VVrong command");
                            break;
                        }
                }
            }
            while (menu != "exit");
        }
        void help()
        {
            Console.WriteLine("Possible command:\n" +
                "help - shovv commands list \n" +
                "clear - clear console\n" +
                "setting - set setting\n" +
                "put - put car into parking\n" + 
                "get - get car from parking\n" + 
                "refill - refill car's balance\n" +
                "money - shovv parking total earnings\n" +
                "freepark - shovv count of free parkingspace\n" +
                "trans - get transaction list\n"+
                "log - shovv transaction log\n" + 
                "exit - =(");
        }
    }
}
