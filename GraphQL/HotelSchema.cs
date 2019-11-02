using GraphQL;
using GraphQL.Types;

namespace dotnet_core_graphql_hotel_api.GraphQL
{
    public class HotelSchema : Schema
    {
        public HotelSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<HotelQuery>();
        }
    }
}