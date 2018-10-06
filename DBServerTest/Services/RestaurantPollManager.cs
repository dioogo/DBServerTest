using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBServerTest.Models;

namespace DBServerTest.Services
{
    public class RestaurantPollManager : IRestaurantPollManager
    {
        private RestaurantPoll restaurantPoll = new RestaurantPoll
        {
            AvailableRestaurants = new List<Restaurant>
            {
                new Restaurant { Id = 0, Name = "Palatus", Votes = 1 },
                new Restaurant { Id = 1, Name = "Ponto Onze", Votes = 3 },
                new Restaurant { Id = 2, Name = "Novo Sabor", Votes = 2 },
                new Restaurant { Id = 3, Name = "Espaço 32", Votes = 5 },
            },
            BlockedRestaurants = new List<Restaurant>
            {
                new Restaurant { Id = 0, Name = "Panorama", Votes = 12},
                new Restaurant { Id = 1, Name = "Sabor Família", Votes = 10}
            }
        };

        public RestaurantPoll GetAllRestaurants()
        {
            return restaurantPoll;
        }

        public RestaurantPoll PostVoteForRestaurant(int id)
        {
            restaurantPoll.AvailableRestaurants.Single(_ => _.Id == id).Votes++;

            return restaurantPoll;
        }
    }
}