using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class MainBusBoard
    {
        public GetData GD = new GetData();
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            new MainBusBoard().Init();
        }
        public void Init()
        {
            Console.WriteLine("Welcome to BusBoard");
            Console.WriteLine("Please enter a stop id to continue..");
            var stopId = Console.ReadLine();

            GD.GetStop(stopId);
        }
    }
}
