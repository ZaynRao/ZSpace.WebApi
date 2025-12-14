using System;
using Volo.Abp.Application.Dtos;

namespace ZSpace.WebApi.Projects;

public class ProjectDto : FullAuditedEntityDto<Guid>
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ProjectStatus Status { get; set; }

    public Guid? OwnerUserId { get; set; }

    public DateTime? PlanStartTime { get; set; }

    public DateTime? PlanEndTime { get; set; }

    public DateTime? ActualStartTime { get; set; }

    public DateTime? ActualEndTime { get; set; }
}