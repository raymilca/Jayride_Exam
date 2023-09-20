using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jayrideexam.Models
{
    public class TaskThreeRequest
    { 
        public int noOfPassanger { get; set; }
    }

    public class TaskThreeResponse
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<Listing> listings { get; set; }
    }
    public class Listing
    {
        public string name { get; set; }
        public double pricePerPassenger { get; set; }

        public double TotalPrice { get; set; }
        public VehicleType vehicleType { get; set; }
    }

    public class VehicleType
    {
        public string name { get; set; }
        public int maxPassengers { get; set; }
    }

}
