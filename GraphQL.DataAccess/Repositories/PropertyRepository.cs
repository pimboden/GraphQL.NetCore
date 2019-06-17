using System.Collections.Generic;
using System.Linq;
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

        public Property GetById(int id)
        {
            return _dbContext.Properties.SingleOrDefault(x => x.Id == id);
        }

        public Property Add(Property property)
        {
            _dbContext.Properties.Add(property);
            _dbContext.SaveChanges();
            return property;
        }
    }
}
