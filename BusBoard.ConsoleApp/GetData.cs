using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class GetData
    {
        TflApi tfl = new TflApi();

        public void GetStop(string stopId)
        {
            RestRequest req = new RestRequest("StopPoint/" + stopId +"/Arrivals", Method.GET);
            var response = tfl.Execute<List<Bus>>(req);

            int i = 0;
            foreach(Bus bus in response)
            {
                // var time = TimeSpan.Parse(bus.expectedArrival.Split('T')[1].Remove(bus.expectedArrival.Split('T')[1].Length - 1));

                var time = bus.expectedArrival.ToLocalTime().Subtract(DateTime.Now).ToString(@"mm");

                Console.WriteLine("Bus " + bus.VehicleId + " going towards " + bus.towards + " is expected to arrive at " + bus.stationName + " in " + time + " minutes. ");
                if(i == 4) { break; }
                i++;
            }
            Console.ReadLine();
        }

    }

}
