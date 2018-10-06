using DBServerTest.Controllers;
using DBServerTest.Models;
using DBServerTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace DBServerTest.Tests.Controllers
{
    [TestClass]
    public class RestaurantPollControllerTest
    {
        private RestaurantPoll RestaurantPoll = new RestaurantPoll
        {
            AvailableRestaurants = new List<Restaurant>
            {
                new Restaurant { Id = 0, Name = "Ponto Onze", Votes = 2 },
                new Restaurant { Id = 1, Name = "Panorama", Votes = 4 },
            },
            BlockedRestaurants = new List<Restaurant>
            {
                new Restaurant { Id = 0, Name = "Ponto Onze", Votes = 4},
            }
        };


        [TestMethod]
        public void testGetAllRestaurants()
        {
            IRestaurantPollManager restaurantPollManager = Substitute.For<IRestaurantPollManager>();
            restaurantPollManager.GetAllRestaurants().Returns(RestaurantPoll);

            RestaurantPollController controller = new RestaurantPollController(restaurantPollManager);

            var result = controller.GetAllRestaurants() as OkNegotiatedContentResult<RestaurantPoll>;

            Assert.AreEqual(2, result.Content.AvailableRestaurants.ToList().Count);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[0].Id, result.Content.AvailableRestaurants.ToList()[0].Id);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[0].Name, result.Content.AvailableRestaurants.ToList()[0].Name);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[0].Votes, result.Content.AvailableRestaurants.ToList()[0].Votes);

            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[1].Id, result.Content.AvailableRestaurants.ToList()[1].Id);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[1].Name, result.Content.AvailableRestaurants.ToList()[1].Name);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[1].Votes, result.Content.AvailableRestaurants.ToList()[1].Votes);

            Assert.AreEqual(1, result.Content.BlockedRestaurants.ToList().Count);
            Assert.AreEqual(RestaurantPoll.BlockedRestaurants.ToList()[0].Id, result.Content.BlockedRestaurants.ToList()[0].Id);
            Assert.AreEqual(RestaurantPoll.BlockedRestaurants.ToList()[0].Name, result.Content.BlockedRestaurants.ToList()[0].Name);
            Assert.AreEqual(RestaurantPoll.BlockedRestaurants.ToList()[0].Votes, result.Content.BlockedRestaurants.ToList()[0].Votes);
        }

        [TestMethod]
        public async Task testPostVoteForRestaurantWithInvalidId()
        {
            IRestaurantPollManager restaurantPollManager = Substitute.For<IRestaurantPollManager>();
            restaurantPollManager.PostVoteForRestaurant(10).Returns(ex => { throw new Exception(); });

            RestaurantPollController controller = new RestaurantPollController(restaurantPollManager);

            var result = await controller.PostVoteForRestaurant(10) as BadRequestErrorMessageResult;
            Assert.AreEqual("Out of index", result.Message);
        }

        [TestMethod]
        public async Task testPostVoteForRestaurantWithValidId()
        {
            IRestaurantPollManager restaurantPollManager = Substitute.For<IRestaurantPollManager>();
            restaurantPollManager.PostVoteForRestaurant(10).Returns(RestaurantPoll);

            RestaurantPollController controller = new RestaurantPollController(restaurantPollManager);

            var result = await controller.PostVoteForRestaurant(10) as OkNegotiatedContentResult<RestaurantPoll>;

            Assert.AreEqual(2, result.Content.AvailableRestaurants.ToList().Count);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[0].Id, result.Content.AvailableRestaurants.ToList()[0].Id);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[0].Name, result.Content.AvailableRestaurants.ToList()[0].Name);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[0].Votes, result.Content.AvailableRestaurants.ToList()[0].Votes);

            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[1].Id, result.Content.AvailableRestaurants.ToList()[1].Id);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[1].Name, result.Content.AvailableRestaurants.ToList()[1].Name);
            Assert.AreEqual(RestaurantPoll.AvailableRestaurants.ToList()[1].Votes, result.Content.AvailableRestaurants.ToList()[1].Votes);

            Assert.AreEqual(1, result.Content.BlockedRestaurants.ToList().Count);
            Assert.AreEqual(RestaurantPoll.BlockedRestaurants.ToList()[0].Id, result.Content.BlockedRestaurants.ToList()[0].Id);
            Assert.AreEqual(RestaurantPoll.BlockedRestaurants.ToList()[0].Name, result.Content.BlockedRestaurants.ToList()[0].Name);
            Assert.AreEqual(RestaurantPoll.BlockedRestaurants.ToList()[0].Votes, result.Content.BlockedRestaurants.ToList()[0].Votes);
        }

    }
}
