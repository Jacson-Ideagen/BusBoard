using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusBoard.Api.Methods;
namespace BusBoard.Api.Objects
{
   public class Stop
    {
        DataMapper dataMapper = new DataMapper();
        
        public string commonName
        { get; set; }
        public double distance
        { get; set; }
        public string icsCode
        { get; set; }
        public string id
        { get; set; }
        public string indicator
        { get; set; }
        public string lat
        { get; set; }
        public string lon
        { get; set; }
        public string naptanId
        { get; set; }
        public string placeType
        { get; set; }
        public string stationNaptan
        { get; set; }
        public bool status
        { get; set; }
        public string stopType
        { get; set; }
        public List<Line> lines
        { get; set; }
        public List<LineGroup> lineGroup
        { get; set; }
        public List<Bus> buses
        {
            get { return (dataMapper.GetStop(lineGroup.ElementAt(0).naptanIdReference)); }
        }
    }
    public class Line
    {
        public string id
        { get; set; }
        public string name
        { get; set; }
        public string uri
        { get; set; }
    }

    public class LineGroup
    {
        public string naptanIdReference
        { get; set; }
    }

    public class AdditionalProperty
    {
        public string catagory
        { get; set; }
        public string key
        { get; set; }
        public string sourceSystemKey
        { get; set; }
        public string value
        { get; set; }
    }

}
