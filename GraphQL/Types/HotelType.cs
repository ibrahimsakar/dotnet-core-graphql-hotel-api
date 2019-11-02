using dotnet_core_graphql_hotel_api.Models;
using GraphQL.Types;

namespace dotnet_core_graphql_hotel_api.GraphQL.Types
{
    public class HotelType : ObjectGraphType<Hotel>
    {
        public HotelType()
        {
            Name = "Hotel";
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Description);
            Field(p => p.StarCount);
        }
    }
}