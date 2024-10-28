using Commander_GraphQL.Data;
using Commander_GraphQL.GraphQL.Commands;
using Commander_GraphQL.GraphQL.Platforms;
using Commander_GraphQL.Models;

namespace Commander_GraphQL.GraphQL
{
	public class Mutation
	{
		[UseDbContext(typeof(AppDbContext))]
		[UseMutationConvention(Disable = true)]
		public  async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, [SchemaService]AppDbContext context)
		{
			var platform = new Platform
			{
				Name = input.Name,
			};
			context.Platforms.Add(platform);
		  await	context.SaveChangesAsync();
			return new AddPlatformPayload(platform);
		}
		[UseDbContext(typeof(AppDbContext))]
		[UseMutationConvention(Disable =true)]
		public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [SchemaService] AppDbContext context)
		{
			var command = new Command
			{
				CommandLine = input.CommandLine,
				HowTo	= input.HowTo,
				PlatformId = input.PlatformId,
			};
			context.Commands.Add(command);
			await context.SaveChangesAsync();
			return new AddCommandPayload(command);
		}

	}
}
