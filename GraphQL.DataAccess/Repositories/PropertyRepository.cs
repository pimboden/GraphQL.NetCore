using System.Collections.Generic;
using WSI.GraphQL.Database.Models;
using WSI.GraphQL.Database;

namespace WSI.GraphQL.DataAccess.Repositories
{
    public class PropertyRepository: IPropertyRepository
    {
        private readonly GraphQLContext _dbContext;

        public PropertyRepository(GraphQLContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Property> GetAll()
        {
            return _dbContext.Properties;
        }
    }
}
