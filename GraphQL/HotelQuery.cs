using dotnet_core_graphql_hotel_api.Data;
using dotnet_core_graphql_hotel_api.GraphQL.Types;
using GraphQL.Types;

namespace dotnet_core_graphql_hotel_api.GraphQL
{
    public class HotelQuery : ObjectGraphType<object>
    {
        public HotelQuery(HotelContext _hotelContext)
        {
            Name = "Hotel Query";

            Field<ListGraphType<HotelType>>("Hotels", resolve: ctx => _hotelContext.GetHotels());
            Field<ListGraphType<HotelType>>("HotelsByHotelId",
                arguments: new QueryArguments()
                {
                    new QueryArgument<IntGraphType>
                    {
                        Name = "Id",
                        Description = "Hotel Id"
                    }
                },
                resolve: ctx => _hotelContext.GetHotelsById(ctx.GetArgument<int>("Id")));
        }
    }
}