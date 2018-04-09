using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class LatLong
    {
        public Result result
        { get; set; }
    }
    class Result
    {
        public double longitude
        { get; set; }
        public double latitude
        { get; set; }
        public string postcode
        { get; set; }
    }
}
