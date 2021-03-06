﻿using System.Diagnostics;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WSI.GraphQL.Api.Mutations;
using WSI.GraphQL.Api.Queries;
using WSI.GraphQL.Api.Schemas;
using WSI.GraphQL.DataAccess.Repositories;
using WSI.GraphQL.Database;
using WSI.GraphQL.Types;
using WSI.GraphQL.Types.Payment;
using WSI.GraphQL.Types.Property;

namespace WSI.GraphQL.Api
{
    public class Startup
    {

        readonly string SiteCorsPolicy = "SiteCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // ********************
            // Setup CORS
            // ********************
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            //corsBuilder.AllowAnyOrigin(); // For anyone access.
            corsBuilder.WithOrigins(Configuration.GetValue<string>("CorsAllowedHosts").Split(';'));
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy(SiteCorsPolicy, corsBuilder.Build());
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(SiteCorsPolicy));
            });
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddDbContext<GraphQLContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:GraphQLDb"]));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<PropertyQuery>();
            services.AddSingleton<PropertyMutation>();
            services.AddSingleton<PropertyIndputType>();
            services.AddSingleton<PropertyType>();
            services.AddSingleton<PaymentType>();
            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphQLSchema(new FuncDependencyResolver(type => serviceProvider.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GraphQLContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseCors(SiteCorsPolicy);
            app.UseMvc();
            dbContext.EnsureSeedData();
        }
    }
}
