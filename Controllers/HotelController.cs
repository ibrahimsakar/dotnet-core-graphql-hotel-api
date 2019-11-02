using System;
using System.Threading.Tasks;
using dotnet_core_graphql_hotel_api.GraphQL;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Conversion;
using GraphQL.Types;

namespace dotnet_core_graphql_hotel_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public HotelController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphqlQueryParameter query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var executionOptions = new ExecutionOptions()
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = query.Variables?.ToInputs(),
                FieldNameConverter = new PascalCaseFieldNameConverter()
            };

            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(result.Data);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
