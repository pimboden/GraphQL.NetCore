using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using WSI.GraphQL.DataAccess.Repositories;
using WSI.GraphQL.Database.Models;
using WSI.GraphQL.Types.Property;

namespace WSI.GraphQL.Api.Mutations
{
    public class PropertyMutation:ObjectGraphType
    {
        public PropertyMutation(IPropertyRepository propertyRepository)
        {
            Field<PropertyType>(
                "addProperty",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PropertyIndputType>> {Name = "property"}),
                resolve: context =>
                {
                    var property = context.GetArgument<Property>("property");
                    return propertyRepository.Add(property);
                });
        }
    }
}
