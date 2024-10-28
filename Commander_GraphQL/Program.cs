using Commander_GraphQL.Data;
using Commander_GraphQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using HotChocolate.AspNetCore;
using Commander_GraphQL.GraphQL.Platforms;
using Commander_GraphQL.GraphQL.Commands;
//using System.Data;
namespace Commander_GraphQL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			

			#region Connection to database --DI

			
			builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
.EnableSensitiveDataLogging() // Optional for debugging
.LogTo(Console.WriteLine)     // Logs SQL queries to console
);


			//option.UseInMemoryDatabase("InMemory");
			#endregion
			//builder.Services.AddGraphQL().AddQueryType<Query>();
			// Register GraphQL services
			builder.Services.AddGraphQLServer()
				 .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true) // Enables detailed error information
				.AddQueryType<Query>()
				.AddMutationType<Mutation>()
	// .AddMutationType()
	//.AddMutationConventions()

				.AddType<CommandType>()
				.AddType<PlatformType>()
			
				.AddFiltering()
				.AddSorting()
			// .AddMutationConventions() // line added
			//.AddProjections()//To bring the child object [navigation properties]
			; // Add more configurations as necessary
			var app = builder.Build();

			// Add UseRouting() here to set up routing middleware
			app.UseRouting();

			//app.MapGet("/", () => "Hello World!");
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGraphQL();
			});

			app.UseGraphQLVoyager(path: "/graphql-voyager");

			app.Run();
		}
	}
}
