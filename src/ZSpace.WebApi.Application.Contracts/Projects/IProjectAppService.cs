using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ZSpace.WebApi.Projects;

/// <summary>
/// 项目模块应用服务接口（完整自定义）
/// </summary>
public interface IProjectAppService
{
    // ===================== Project =====================
    Task<List<ProjectDto>> GetListAsync();
    Task<PagedResultDto<ProjectDto>> GetPagedListAsync(ProjectPagedRequestDto input);
    Task<ProjectDetailDto> GetAsync(Guid id);
    Task<ProjectDto> CreateAsync(CreateProjectDto input);
    Task<ProjectDto> UpdateAsync(Guid id, UpdateProjectDto input);
    Task DeleteAsync(Guid id);

    // ===================== ProjectTask =====================
    Task<PagedResultDto<ProjectTaskDto>> GetTaskListAsync(ProjectTaskPagedRequestDto input);
    Task<ProjectTaskDto> GetTaskAsync(Guid id);
    Task<List<ProjectTaskTreeDto>> GetTaskTreeAsync(Guid projectId);
    Task<ProjectTaskDto> CreateTaskAsync(CreateProjectTaskDto input);
    Task<ProjectTaskDto> UpdateTaskAsync(Guid id, UpdateProjectTaskDto input);
    Task DeleteTaskAsync(Guid id);

    // ===================== ProjectTask 额外操作 =====================
    /// <summary>
    /// 更新任务状态
    /// </summary>
    Task<ProjectTaskDto> UpdateTaskStatusAsync(Guid id, TaskStatus status);

    /// <summary>
    /// 更新任务优先级
    /// </summary>
    Task<ProjectTaskDto> UpdateTaskPriorityAsync(Guid id, TaskPriority priority);

    /// <summary>
    /// 更新任务排序（同级任务拖拽排序）
    /// </summary>
    Task UpdateTaskSortOrderAsync(Guid projectId, List<Guid> sortedTaskIds);
}