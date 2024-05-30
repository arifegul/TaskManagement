using AutoMapper;

namespace TaskManagement.Business.Mapping
{
    public class ObjectMapper
	{
		private static readonly Lazy<IMapper> lazy = new(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<TaskManagementAutoMapperProfile>();
			});
			return config.CreateMapper();
		});
		public static IMapper Mapper => lazy.Value;
	}
}
