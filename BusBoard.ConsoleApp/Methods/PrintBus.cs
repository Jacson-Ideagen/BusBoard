using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusBoard.Api.Objects;
using BusBoard.Api.Methods;

namespace BusBoard.ConsoleApp.Methods
{
    class PrintBus
    {
        DataMapper GD = new DataMapper();

        public void StopsPrint(List<Bus> buses, int count = 5)
        {
            //print buses
            int i = 0;
            foreach (Bus bus in buses)
            {

                var time = bus.expectedArrival.ToLocalTime().Subtract(DateTime.Now).ToString(@"mm");

                Console.WriteLine("Bus " + bus.VehicleId + " going towards " + bus.towards + " is expected to arrive at " + bus.stationName + " in " + time + " minutes. ");
                if (i == count-1) { break; }
                i++;
            }
        }

        public void StopListPrint(List<Stop> stopList, int count = 2)
        {
            int i = 0;
            foreach (Stop stop in stopList)
            {
                Console.WriteLine("Bus stop : " + stop.commonName + " : Distance : " + Math.Round(stop.distance).ToString() + " meters away");
                StopsPrint(GD.GetStop(stop.lineGroup.ElementAt(0).naptanIdReference));
                Console.WriteLine("==========================================================================================");
                Console.WriteLine("");
                if (i > count - 1)
                {
                    break;
                }
                i++;
            }
        }

    }
}
