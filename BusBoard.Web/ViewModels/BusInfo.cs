using BusBoard.Api.Methods;
using BusBoard.Api.Objects;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard.Web.ViewModels

{
    public class BusInfo
    {
        DataMapper dataMapper = new DataMapper();

        public BusInfo(string postCode)
        {
            PostCode = postCode;
            stopList = dataMapper.GetClosestStopList(postCode);
            
        }

        public string PostCode { get; set; }
        public List<Stop> stopList { get; set; }
    }
}