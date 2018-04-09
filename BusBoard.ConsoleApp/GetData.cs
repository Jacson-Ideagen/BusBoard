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
        PostCodeIO pcio = new PostCodeIO();

        public void GetStop(string stopId)
        {
            //get buses
            RestRequest req = new RestRequest("StopPoint/" + stopId + "/Arrivals", Method.GET);
            var response = tfl.Execute<List<Bus>>(req);

            //reorder buses
            List<Bus> _buses = new List<Bus>();

            foreach (Bus bus in response)
            {
                _buses.Add(bus);
            }

            List<Bus> buses = new List<Bus>();

            buses = _buses.OrderBy(b => b.expectedArrival).ToList();

            //print buses
            int i = 0;
            foreach (Bus bus in buses)
            {

                var time = bus.expectedArrival.ToLocalTime().Subtract(DateTime.Now).ToString(@"mm");

                Console.WriteLine("Bus " + bus.VehicleId + " going towards " + bus.towards + " is expected to arrive at " + bus.stationName + " in " + time + " minutes. ");
                if (i == 4) { break; }
                i++;
            }
        }
        public void GetClosestStopList(string postcode, int count = 2, int radius = 200)
        {

            var latLong = new LatLong();
            latLong = GetLatLon(postcode);

            //get buses
            RestRequest req = new RestRequest("StopPoint?stopTypes=NaptanOnstreetBusCoachStopPair%2C%20NaptanPublicBusCoachTram&radius=" + radius + "&modes=bus&lat=" + latLong.result.latitude + "&lon=" + latLong.result.longitude, Method.GET);
            var response = tfl.Execute<StopList>(req);

            List<Stop> stopList = new List<Stop>();

            foreach (Stop stop in response.stopPoints)
            {
                stopList.Add(stop);
            }

            int i = 0;
            foreach (Stop stop in stopList)
            {
                Console.WriteLine("Bus stop : " + stop.commonName + " : Distance : " + Math.Round(stop.distance).ToString());
                GetStop(stop.lineGroup.ElementAt(i).naptanIdReference);
                Console.WriteLine("==========================================================================================");
                Console.WriteLine("");
                if(i> count - 1)
                {
                    break;
                }
                i++;
            }
            Console.WriteLine("Press any key to return to main menu..");
            Console.ReadLine();
            return;
        }

        public LatLong GetLatLon(string postcode)
        {
            RestRequest req = new RestRequest("postcodes/" + postcode, Method.GET);
            var response = pcio.Execute<LatLong>(req);

            return response;
        }

    }

}
//https://api.tfl.gov.uk/