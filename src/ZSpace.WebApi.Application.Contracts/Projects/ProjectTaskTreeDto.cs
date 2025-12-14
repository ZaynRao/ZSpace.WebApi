using System.Collections.Generic;

namespace ZSpace.WebApi.Projects;
public class ProjectTaskTreeDto : ProjectTaskDto
{
    public List<ProjectTaskTreeDto> Children { get; set; }
}
