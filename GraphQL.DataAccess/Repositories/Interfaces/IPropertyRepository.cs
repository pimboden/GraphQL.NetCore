using System.Collections.Generic;
using WSI.GraphQL.Database.Models;

namespace WSI.GraphQL.DataAccess.Repositories
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
    }
}