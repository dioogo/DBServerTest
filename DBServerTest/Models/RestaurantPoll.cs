using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBServerTest.Models
{
    public class RestaurantPoll
    {
        public IEnumerable<Restaurant> AvailableRestaurants { get; set; }
        public IEnumerable<Restaurant> BlockedRestaurants { get; set; }
    }
}