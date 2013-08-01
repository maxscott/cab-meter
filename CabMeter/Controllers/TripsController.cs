using System;
using System.Web;
using System.Web.Http;
using CabMeter.Calculation;
using CabMeter.Models;

namespace CabMeter.Controllers
{
    public class TripsController : ApiController
    {
        private readonly IFareCalculator fareCalculator;

        public TripsController(IFareCalculator fareCalculator)
        {
            this.fareCalculator = fareCalculator;
        }

        [HttpPost]
        public Trip GetFare(Trip trip)
        {
            fareCalculator.CalculateFare(trip);
            return trip;
        }
    }
}