using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WSI.GraphQL.Database
{
    public class GraphQLContextFactory : IDesignTimeDbContextFactory<GraphQLContext>
    {
        public GraphQLContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<GraphQLContext>();
            var connectionString = configuration.GetConnectionString("GraphQLDb");
            builder.UseSqlServer(connectionString);
            return new GraphQLContext(builder.Options);
        }
    }
}