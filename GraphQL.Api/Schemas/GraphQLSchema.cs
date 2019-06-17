using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using WSI.GraphQL.Api.Queries;

namespace WSI.GraphQL.Api.Schemas
{
    public class GraphQLSchema:Schema
    {
        public GraphQLSchema(IDependencyResolver resolver):base(resolver)
        {
            Query = resolver.Resolve<PropertyQuery>();
        }
    }
}
