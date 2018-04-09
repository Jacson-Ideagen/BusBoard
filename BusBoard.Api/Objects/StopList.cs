using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.Api.Objects
{
    public class StopList
    {
        public List<Stop> stopPoints
        { get; set; }
        public int pageSize
        { get; set; }
        public int total
        { get; set; }
        public int page
        { get; set; }
    }
}
