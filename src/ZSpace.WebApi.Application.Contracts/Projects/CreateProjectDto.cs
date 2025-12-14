using System;
using System.ComponentModel.DataAnnotations;

namespace ZSpace.WebApi.Projects;

public class CreateProjectDto
{
    [Required]
    [StringLength(50)]
    public string Code { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [StringLength(2000)]
    public string Description { get; set; }

    public Guid? OwnerUserId { get; set; }

    public DateTime? PlanStartTime { get; set; }

    public DateTime? PlanEndTime { get; set; }
}