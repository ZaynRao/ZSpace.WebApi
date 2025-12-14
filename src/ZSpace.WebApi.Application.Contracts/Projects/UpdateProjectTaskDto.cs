using System;
using System.ComponentModel.DataAnnotations;

namespace ZSpace.WebApi.Projects;

public class UpdateProjectTaskDto
{
    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [StringLength(2000)]
    public string Description { get; set; }

    public TaskStatus Status { get; set; }

    public TaskPriority Priority { get; set; }

    public Guid? AssigneeUserId { get; set; }

    public DateTime? PlanStartTime { get; set; }

    public DateTime? PlanEndTime { get; set; }

    public DateTime? ActualStartTime { get; set; }

    public DateTime? ActualEndTime { get; set; }

    public int SortOrder { get; set; }

    public decimal? ActualHours { get; set; }
}