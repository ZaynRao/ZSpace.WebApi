using System;
using Volo.Abp.Application.Dtos;

namespace ZSpace.WebApi.Projects;

public class ProjectTaskPagedRequestDto : PagedAndSortedResultRequestDto
{
    public Guid ProjectId { get; set; }

    public Guid? ParentTaskId { get; set; }

    public TaskStatus? Status { get; set; }
}