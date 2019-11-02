using System.Collections.Generic;
using System.Linq;
using dotnet_core_graphql_hotel_api.Models;

namespace dotnet_core_graphql_hotel_api.Data
{
    public class HotelContext
    {
        private readonly List<Hotel> _hotels = new List<Hotel>();

        public HotelContext()
        {
            // Dummy hotels
            for (var i = 0; i < 10; i++)
            {
                _hotels.Add(new Hotel()
                {
                    Id = i,
                    Name = $"GitHub Hotel {i}",
                    Description = $"GitHub Hotel Description {i}",
                    StarCount = 5
                });
            }
        }

        public List<Hotel> GetHotels()
        {
            return _hotels;
        }

        public List<Hotel> GetHotelsById(int hotelId)
        {
            return _hotels.Where(p => p.Id == hotelId).ToList();
        }
    }
}