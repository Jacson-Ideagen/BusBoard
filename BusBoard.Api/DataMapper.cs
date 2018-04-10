using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using BusBoard.Api;
using BusBoard.Api.Objects;

namespace BusBoard.Api.Methods
{
    public class DataMapper
    {
        TflApi tfl = new TflApi();
        PostCodeIO pcio = new PostCodeIO();

        public List<Bus> GetStop(string stopId, int count = 5)
        {
            //get buses
            RestRequest req = new RestRequest("StopPoint/" + stopId + "/Arrivals", Method.GET);
            var response = tfl.Execute<List<Bus>>(req);

            //reorder buses
            List<Bus> _buses = new List<Bus>();

            int i = 0;
            foreach (Bus bus in response)
            {
                _buses.Add(bus);
                if (i == count - 1) { break; }
                i++;
            }

            List<Bus> buses = new List<Bus>();

            buses = _buses.OrderBy(b => b.expectedArrival).ToList();

            return buses;
        }
        public List<Stop> GetClosestStopList(string postcode, int count = 2, int radius = 200)
        {

            var latLong = new LatLong();
            latLong = GetLatLon(postcode);

            List<Stop> stopList = new List<Stop>();

            //get buses
            try
            {
                RestRequest req = new RestRequest("StopPoint?stopTypes=NaptanOnstreetBusCoachStopPair%2C%20NaptanPublicBusCoachTram&radius=" + radius + "&modes=bus&lat=" + latLong.result.latitude + "&lon=" + latLong.result.longitude, Method.GET);
                var response = tfl.Execute<StopList>(req);

                int i = 0;
                foreach (Stop stop in response.stopPoints)
                {
                    stopList.Add(stop);
                    if(i == count - 1) { break; }
                    i++;
                }
            }
            catch (Exception e)
            {

            }
            return stopList;
        }

        public LatLong GetLatLon(string postcode)
        {
            RestRequest req = new RestRequest("postcodes/" + postcode, Method.GET);
            var response = pcio.Execute<LatLong>(req);

            return response;
        }

    }

}