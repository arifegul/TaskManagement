using AutoMapper;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Entities;

namespace TaskManagement.Business.Mapping
{
    public class TaskManagementAutoMapperProfile : Profile
    {
        public TaskManagementAutoMapperProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<Tasks, TaskResponse>().ReverseMap();
            CreateMap<TaskDetail, TaskDetailResponse>().ReverseMap();
            CreateMap<Role, RoleResponse>().ReverseMap();
        }
    }  
}
