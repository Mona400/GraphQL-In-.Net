using Commander_GraphQL.Data;
using Commander_GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Commander_GraphQL.GraphQL.Platforms
{
	public class PlatformType : ObjectType<Platform>
	{
		protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
		{
			descriptor.Description("Represents any software or platform.");
			descriptor.Field(x => x.LicenseKey).Ignore();
			descriptor.Field(x => x.Commands)
				.ResolveWith<Resolvers>(x => x.GetCommands(default!, default!))
				.UseDbContext<AppDbContext>()
				
				.Description("The list of available commands for this platform.");

			
		}

		private class Resolvers
		{
			public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
			{
				return context.Commands.Where(x => x.PlatformId == platform.Id);
			}
		}
	}
}
