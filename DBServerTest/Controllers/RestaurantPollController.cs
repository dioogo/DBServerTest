using DBServerTest.Services;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace DBServerTest.Controllers
{
    public class RestaurantPollController : ApiController
    {
        private readonly IRestaurantPollManager restaurantPollManager;

        public RestaurantPollController(IRestaurantPollManager _restaurantPollManager)
        {
            restaurantPollManager = _restaurantPollManager;
        }


        [HttpGet]
        public IHttpActionResult GetAllRestaurants()
        {
            return Ok(restaurantPollManager.GetAllRestaurants());
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostVoteForRestaurant(int id)
        {
            try
            {
                var restaurants = restaurantPollManager.PostVoteForRestaurant(id);
                return await Task.FromResult(Ok(restaurants));
            }
            catch(Exception)
            {
                return await Task.FromResult(BadRequest("Out of index"));
            }
        }
    }
}
