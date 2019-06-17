using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore.Internal;
using WSI.GraphQL.Utilities;

namespace WSI.GraphQL.Api.Controllers
{
    [Route("[controller]")]
    public class GraphQLController:Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var inputs = query.Variables?.ToInputs();
            //Special Graphql class used during excecution of the query
            var executionOtpions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };
            var result = await _documentExecuter.ExecuteAsync(executionOtpions);
            if (result.Errors?.Count>0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
