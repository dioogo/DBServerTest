using DBServerTest.Models;
using System.Collections.Generic;

namespace DBServerTest.Services
{
    public interface IRestaurantPollManager
    {
        RestaurantPoll GetAllRestaurants();

        RestaurantPoll PostVoteForRestaurant(int id);
    }
}