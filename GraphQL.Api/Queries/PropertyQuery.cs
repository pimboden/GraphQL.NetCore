using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore.Metadata;
using WSI.GraphQL.DataAccess.Repositories;
using WSI.GraphQL.Types;
using WSI.GraphQL.Types.Property;

namespace WSI.GraphQL.Api.Queries
{
    public class PropertyQuery:ObjectGraphType
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyQuery(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
            Field<ListGraphType<PropertyType>>("properties", resolve: context => propertyRepository.GetAll());
            Field<PropertyType>("property", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType>{Name="id"}),
                resolve: context => propertyRepository.GetById(context.GetArgument<int>("id")));
        }
    }
}
