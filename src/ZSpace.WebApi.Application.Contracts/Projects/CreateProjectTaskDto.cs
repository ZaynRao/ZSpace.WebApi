using System;
using System.ComponentModel.DataAnnotations;

namespace ZSpace.WebApi.Projects;


public class CreateProjectTaskDto
{
    [Required]
    public Guid ProjectId { get; set; }

    public Guid? ParentTaskId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [StringLength(2000)]
    public string Description { get; set; }

    public TaskPriority Priority { get; set; } = TaskPriority.Normal;

    public Guid? AssigneeUserId { get; set; }

    public DateTime? PlanStartTime { get; set; }

    public DateTime? PlanEndTime { get; set; }

    public decimal? EstimatedHours { get; set; }
}