using AutoMapper;
using Reddit.Contract.Task;
using Reddit.Domain.Entities;
using Task = Reddit.Domain.Entities.Task;

namespace Reddit.Service.Mapping;
public class TaskMapperProfile: Profile
{
    public TaskMapperProfile()
    {
        CreateMap<Task, TaskResponse>();
        CreateMap<TaskCreateRequest, Task>();
        CreateMap<TaskUpdateRequest, Task>();
    }
}
