using System;
using System.ComponentModel.DataAnnotations;

namespace ZSpace.WebApi.Projects;

public class UpdateProjectDto
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [StringLength(50)]
    public string Code { get; set; }

    public ProjectStatus Status { get; set; }

    public Guid? OwnerUserId { get; set; }

    public DateTime? PlanStartTime { get; set; }

    public DateTime? PlanEndTime { get; set; }

    public DateTime? ActualStartTime { get; set; }

    public DateTime? ActualEndTime { get; set; }

    [StringLength(2000)]
    public string Description { get; set; }
}