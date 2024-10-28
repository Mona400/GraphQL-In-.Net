using Commander_GraphQL.Data;
using Commander_GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Commander_GraphQL.GraphQL.Commands
{
	public class CommandType : ObjectType<Command>
	{
		protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
		{
			descriptor.Description("Represents any executable command.");

			descriptor.Field(x => x.Platform)
				.ResolveWith<Resolvers>(x => x.GetPlatform(default!, default!))
				.UseDbContext<AppDbContext>()
				.Description("The platform associated with the command.");
		}

		private class Resolvers
		{
			public Platform? GetPlatform([Parent]Command command, [ScopedService] AppDbContext context)
			{
				return context.Platforms.FirstOrDefault(x => x.Id == command.PlatformId);
			}

		}
	}
}
