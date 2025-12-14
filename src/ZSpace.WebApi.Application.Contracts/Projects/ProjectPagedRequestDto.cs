using Volo.Abp.Application.Dtos;

namespace ZSpace.WebApi.Projects;

public class ProjectPagedRequestDto : PagedAndSortedResultRequestDto
{
    public string Keyword { get; set; }

    public ProjectStatus? Status { get; set; }
}