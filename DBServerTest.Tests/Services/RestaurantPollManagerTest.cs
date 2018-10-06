using DBServerTest.Models;
using DBServerTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServerTest.Tests.Services
{
    [TestClass]
    public class RestaurantPollManagerTest
    {
        private RestaurantPoll ExpectedRestaurantPoll = new RestaurantPoll
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

        [TestMethod]
        public void testGetAllRestaurants()
        {
            RestaurantPollManager manager = new RestaurantPollManager();
            var result = manager.GetAllRestaurants();

            Assert.AreEqual(4, result.AvailableRestaurants.ToList().Count);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[0].Id, result.AvailableRestaurants.ToList()[0].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[0].Name, result.AvailableRestaurants.ToList()[0].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[0].Votes, result.AvailableRestaurants.ToList()[0].Votes);

            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[1].Id, result.AvailableRestaurants.ToList()[1].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[1].Name, result.AvailableRestaurants.ToList()[1].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[1].Votes, result.AvailableRestaurants.ToList()[1].Votes);

            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[2].Id, result.AvailableRestaurants.ToList()[2].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[2].Name, result.AvailableRestaurants.ToList()[2].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[2].Votes, result.AvailableRestaurants.ToList()[2].Votes);

            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[3].Id, result.AvailableRestaurants.ToList()[3].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[3].Name, result.AvailableRestaurants.ToList()[3].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[3].Votes, result.AvailableRestaurants.ToList()[3].Votes);

            Assert.AreEqual(2, result.BlockedRestaurants.ToList().Count);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[0].Id, result.BlockedRestaurants.ToList()[0].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[0].Name, result.BlockedRestaurants.ToList()[0].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[0].Votes, result.BlockedRestaurants.ToList()[0].Votes);

            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[1].Id, result.BlockedRestaurants.ToList()[1].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[1].Name, result.BlockedRestaurants.ToList()[1].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[1].Votes, result.BlockedRestaurants.ToList()[1].Votes);
        }

        [TestMethod]
        public void testPostVoteForRestaurantWithValidId()
        {
            RestaurantPollManager manager = new RestaurantPollManager();
            var result = manager.PostVoteForRestaurant(1);

            Assert.AreEqual(4, result.AvailableRestaurants.ToList().Count);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[0].Id, result.AvailableRestaurants.ToList()[0].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[0].Name, result.AvailableRestaurants.ToList()[0].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[0].Votes, result.AvailableRestaurants.ToList()[0].Votes);

            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[1].Id, result.AvailableRestaurants.ToList()[1].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[1].Name, result.AvailableRestaurants.ToList()[1].Name);
            Assert.AreEqual(4, result.AvailableRestaurants.ToList()[1].Votes);

            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[2].Id, result.AvailableRestaurants.ToList()[2].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[2].Name, result.AvailableRestaurants.ToList()[2].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[2].Votes, result.AvailableRestaurants.ToList()[2].Votes);

            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[3].Id, result.AvailableRestaurants.ToList()[3].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[3].Name, result.AvailableRestaurants.ToList()[3].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.AvailableRestaurants.ToList()[3].Votes, result.AvailableRestaurants.ToList()[3].Votes);

            Assert.AreEqual(2, result.BlockedRestaurants.ToList().Count);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[0].Id, result.BlockedRestaurants.ToList()[0].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[0].Name, result.BlockedRestaurants.ToList()[0].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[0].Votes, result.BlockedRestaurants.ToList()[0].Votes);

            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[1].Id, result.BlockedRestaurants.ToList()[1].Id);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[1].Name, result.BlockedRestaurants.ToList()[1].Name);
            Assert.AreEqual(ExpectedRestaurantPoll.BlockedRestaurants.ToList()[1].Votes, result.BlockedRestaurants.ToList()[1].Votes);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void testPostVoteForRestaurantWithInvalidId()
        {
            RestaurantPollManager manager = new RestaurantPollManager();
            var result = manager.PostVoteForRestaurant(10);
        }
    }
}
