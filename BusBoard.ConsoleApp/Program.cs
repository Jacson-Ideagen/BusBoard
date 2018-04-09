using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusBoard.ConsoleApp.Methods;
using BusBoard.Api.Methods;
using BusBoard.Api.Objects;

namespace BusBoard.ConsoleApp
{
    class MainBusBoard
    {
        public DataMapper dataMapper = new DataMapper();
        public PrintBus busPrinter = new PrintBus();

        public bool x = true;

        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            new MainBusBoard().Init();
        }
        public void Init()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Welcome to BusBoard");
            while (x)
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a command..");
                Console.WriteLine("");
                var command = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("");
                Run(command);
            }

        }
        public void Run(string command)
        {
            if (command.ToLower().Contains("stop list[") || command.ToLower().Contains("stoplist[") || command.ToLower().Contains("sl["))
            {
                var values = command.Split('[');
                


                var postcode = values[1].Remove(values[1].Length -1);
                int count;
                int radius;

                var stopList = new List<Stop>();

                switch (values.Length)
                {
                    case 3:
                        count = Convert.ToInt32(values[2].Remove(values[1].Length - 1));
                        stopList =  dataMapper.GetClosestStopList(postcode, count);
                        busPrinter.StopListPrint(stopList, count);
                        break;
                    case 4:
                        count = Convert.ToInt32(values[2].Remove(values[1].Length - 1));
                        radius = Convert.ToInt32(values[3].Remove(values[3].Length - 1));
                        stopList = dataMapper.GetClosestStopList(postcode, count, radius);
                        busPrinter.StopListPrint(stopList, count);
                        break;
                    default:
                        stopList = dataMapper.GetClosestStopList(postcode);
                        busPrinter.StopListPrint(stopList);
                        break;
                }
            }
            else
            if (command.ToLower() == "x")
            {
                x = false;
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to main menu..");
            Console.ReadLine();

        }
    }
}
