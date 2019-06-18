using System.Collections.Generic;
using System.Linq;
using WSI.GraphQL.Database;
using WSI.GraphQL.Database.Models;

namespace WSI.GraphQL.DataAccess.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly GraphQLContext _dbContext;

        public PaymentRepository(GraphQLContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Payment> GetAllForProperty(int propertyId)
        {
            return _dbContext.Payments.Where(x=>x.PropertyId == propertyId);
        }

        public IEnumerable<Payment> GetAllForProperty(int propertyId, int lastAmount)
        {
            return _dbContext.Payments.Where(x => x.PropertyId == propertyId)
                .OrderByDescending(x=>x.DateCreated)
                .Take(lastAmount);
        }
    }
}