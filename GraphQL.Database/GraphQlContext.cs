using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WSI.GraphQL.Database.Models;

namespace WSI.GraphQL.Database
{
    public class GraphQLContext:DbContext   
    {
        public GraphQLContext(DbContextOptions<GraphQLContext> options):base(options)
        {
            
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }

    //needed to get connectionstring form the appsettings
}
