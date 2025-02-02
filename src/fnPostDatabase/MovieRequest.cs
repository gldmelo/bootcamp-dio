
namespace fnPostDatabase
{
	public class MovieRequest
	{
		public string id => Guid.NewGuid().ToString();
		
		public string title { get; set; }
		
		public int year { get; set; }
		
		public string video { get; set; }
		
		public string thumb { get; set; }

	}
}
