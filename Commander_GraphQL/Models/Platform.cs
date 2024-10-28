namespace Commander_GraphQL.Models
{
	//[GraphQLDescription("Represent any software or platform ")]//use it to make documentation of the api
	public class Platform
	{
        public int Id { get; set; }
		public string Name { get; set; }

		public string ?LicenseKey { get; set; }
		public ICollection<Command> ?Commands { get; set; } = new List<Command>();
    }
}
