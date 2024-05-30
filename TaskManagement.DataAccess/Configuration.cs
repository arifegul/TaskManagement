using Microsoft.Extensions.Configuration;

namespace TaskManagement.DataAccess
{
    static class Configuration
	{
		static public string ConnectionString
		{
			get
			{
				ConfigurationManager configurationManager = new();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TaskManagement.API"));
				configurationManager.AddJsonFile("appsettings.json");

				var configurationString = configurationManager.GetConnectionString("DefaultConnection");
				var errorMessage = "Configuration error!";
				if(configurationString == null)
					return errorMessage;
                return configurationString;
			}
		}
	}
}
