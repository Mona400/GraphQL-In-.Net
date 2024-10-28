using Commander_GraphQL.Data;
using Commander_GraphQL.Models;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace Commander_GraphQL.GraphQL
{
	public class Query
	{
	
		//[UseProjection]//To Bring any child object [navigation properties]
					   //now we dont need to use the projection attribute as the resolver in the PlatformType.cs do it

		[UseDbContext(typeof(AppDbContext))]
		[UseFiltering]
		[UseSorting]
		//[UseProjection] // This enables projectio
		public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext context)
		{
			return context.Platforms.Include(p => p.Commands).AsQueryable();
		}

		// If you need to fetch a single platform by ID
		[UseDbContext(typeof(AppDbContext))]
		[UseFiltering]
		[UseSorting]
		public Platform GetPlatform(int id, [ScopedService] AppDbContext context)
		{
			return context.Platforms.Include(p => p.Commands).FirstOrDefault(p => p.Id == id);
		}

		[UseDbContext(typeof(AppDbContext))]
		[UseFiltering]
		[UseSorting]
		//[UseProjection]//To Bring any child object [navigation properties]
		public IQueryable<Command> GetCommand([ScopedService] AppDbContext Context)
		{
			return Context.Commands.AsQueryable();

		}

	}
}
