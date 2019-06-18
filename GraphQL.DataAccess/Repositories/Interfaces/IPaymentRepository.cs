

using System.Collections.Generic;
using WSI.GraphQL.Database.Models;

namespace WSI.GraphQL.DataAccess.Repositories
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllForProperty(int propertyId);
        IEnumerable<Payment> GetAllForProperty(int propertyId, int lastAmount);
    }
}
