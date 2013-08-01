using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CabMeter.Calculation;
using CabMeter.Models;

namespace CabMeter.Controllers
{
    public class FareController : ApiController
    {
        private readonly IFareCalculator fareCalculator;

        public FareController(IFareCalculator fareCalculator)
        {
            this.fareCalculator = fareCalculator;
        }

        // GET api/values
        public decimal GetFare(Trip trip)
        {
            return fareCalculator.CalculateFare(trip);
        }
    }
}