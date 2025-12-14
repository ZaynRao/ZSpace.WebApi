using System;
using Volo.Abp.Application.Dtos;

namespace ZSpace.WebApi.Projects;

public class ProjectTaskDto : FullAuditedEntityDto<Guid>
{
    public Guid ProjectId { get; set; }

    public Guid? ParentTaskId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TaskStatus Status { get; set; }

    public TaskPriority Priority { get; set; }

    public Guid? AssigneeUserId { get; set; }

    public DateTime? PlanStartTime { get; set; }

    public DateTime? PlanEndTime { get; set; }

    public DateTime? ActualStartTime { get; set; }

    public DateTime? ActualEndTime { get; set; }

    public int SortOrder { get; set; }

    public decimal? EstimatedHours { get; set; }

    public decimal? ActualHours { get; set; }
}
