using System.Collections.Generic;

namespace ZSpace.WebApi.Projects;

public class ProjectDetailDto : ProjectDto
{
    public List<ProjectTaskTreeDto> Tasks { get; set; }
}
