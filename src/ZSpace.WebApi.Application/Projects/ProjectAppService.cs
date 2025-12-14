using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ZSpace.WebApi.Projects
{
    public class ProjectAppService : ApplicationService, IProjectAppService
    {
        private readonly IRepository<Project, Guid> _projectRepository;
        private readonly IRepository<ProjectTask, Guid> _taskRepository;

        public ProjectAppService(
            IRepository<Project, Guid> projectRepository,
            IRepository<ProjectTask, Guid> taskRepository)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
        }

        // ===================== Project =====================

        public async Task<List<ProjectDto>> GetListAsync()
        {
            var projects = await _projectRepository.GetListAsync();
            return ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects);
        }

        public async Task<PagedResultDto<ProjectDto>> GetPagedListAsync(ProjectPagedRequestDto input)
        {
            var queryable = await _projectRepository.GetQueryableAsync();

            queryable = queryable
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                         p => p.Name.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.CountAsync(queryable);


            var list = await AsyncExecuter.ToListAsync(queryable.OrderBy(input.Sorting ?? "CreationTime desc")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));


            return new PagedResultDto<ProjectDto>(
                totalCount,
                ObjectMapper.Map<List<Project>, List<ProjectDto>>(list)
            );
        }

        public async Task<ProjectDetailDto> GetAsync(Guid id)
        {
            var project = await _projectRepository.GetAsync(id);
            var tasks = await _taskRepository.GetListAsync(t => t.ProjectId == id);
            var taskTree = BuildTaskTree(tasks);

            var dto = ObjectMapper.Map<Project, ProjectDetailDto>(project);
            dto.Tasks = taskTree;
            return dto;
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto input)
        {
            var project = ObjectMapper.Map<CreateProjectDto, Project>(input);
            await _projectRepository.InsertAsync(project);
            return ObjectMapper.Map<Project, ProjectDto>(project);
        }

        public async Task<ProjectDto> UpdateAsync(Guid id, UpdateProjectDto input)
        {
            var project = await _projectRepository.GetAsync(id);
            ObjectMapper.Map(input, project);
            await _projectRepository.UpdateAsync(project);
            return ObjectMapper.Map<Project, ProjectDto>(project);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _projectRepository.DeleteAsync(id);
        }

        // ===================== ProjectTask =====================

        public async Task<PagedResultDto<ProjectTaskDto>> GetTaskListAsync(ProjectTaskPagedRequestDto input)
        {
            var queryable = await _taskRepository.GetQueryableAsync();

            queryable = queryable
                .Where(t => t.ProjectId == input.ProjectId)
                .WhereIf(input.ParentTaskId.HasValue, t => t.ParentTaskId == input.ParentTaskId)
                .WhereIf(input.Status.HasValue, t => t.Status == input.Status);

            var totalCount = await AsyncExecuter.CountAsync(queryable);

            var list = await AsyncExecuter.ToListAsync(
                queryable
                    .OrderBy(input.Sorting ?? "SortOrder asc")
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)
            );

            return new PagedResultDto<ProjectTaskDto>(
                totalCount,
                ObjectMapper.Map<List<ProjectTask>, List<ProjectTaskDto>>(list)
            );
        }

        public async Task<ProjectTaskDto> GetTaskAsync(Guid id)
        {
            var task = await _taskRepository.GetAsync(id);
            return ObjectMapper.Map<ProjectTask, ProjectTaskDto>(task);
        }

        public async Task<List<ProjectTaskTreeDto>> GetTaskTreeAsync(Guid projectId)
        {
            var tasks = await _taskRepository.GetListAsync(t => t.ProjectId == projectId);
            var tree = BuildTaskTree(tasks);
            return tree;
        }

        public async Task<ProjectTaskDto> CreateTaskAsync(CreateProjectTaskDto input)
        {
            var task = ObjectMapper.Map<CreateProjectTaskDto, ProjectTask>(input);
            await _taskRepository.InsertAsync(task);
            return ObjectMapper.Map<ProjectTask, ProjectTaskDto>(task);
        }

        public async Task<ProjectTaskDto> UpdateTaskAsync(Guid id, UpdateProjectTaskDto input)
        {
            var task = await _taskRepository.GetAsync(id);
            ObjectMapper.Map(input, task);
            await _taskRepository.UpdateAsync(task);
            return ObjectMapper.Map<ProjectTask, ProjectTaskDto>(task);
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        // ===================== ProjectTask 额外操作 =====================

        public async Task<ProjectTaskDto> UpdateTaskStatusAsync(Guid id, TaskStatus status)
        {
            var task = await _taskRepository.GetAsync(id);
            task.Status = status;
            await _taskRepository.UpdateAsync(task);
            return ObjectMapper.Map<ProjectTask, ProjectTaskDto>(task);
        }

        public async Task<ProjectTaskDto> UpdateTaskPriorityAsync(Guid id, TaskPriority priority)
        {
            var task = await _taskRepository.GetAsync(id);
            task.Priority = priority;
            await _taskRepository.UpdateAsync(task);
            return ObjectMapper.Map<ProjectTask, ProjectTaskDto>(task);
        }

        public async Task UpdateTaskSortOrderAsync(Guid projectId, List<Guid> sortedTaskIds)
        {
            var tasks = await _taskRepository.GetListAsync(t => t.ProjectId == projectId && sortedTaskIds.Contains(t.Id));

            for (int i = 0; i < sortedTaskIds.Count; i++)
            {
                var task = tasks.FirstOrDefault(t => t.Id == sortedTaskIds[i]);
                if (task != null)
                {
                    task.SortOrder = i + 1;
                    await _taskRepository.UpdateAsync(task);
                }
            }
        }

        // ===================== 私有方法 =====================

        private List<ProjectTaskTreeDto> BuildTaskTree(List<ProjectTask> tasks)
        {
            var lookup = tasks.ToLookup(t => t.ParentTaskId);

            List<ProjectTaskTreeDto> Build(Guid? parentId)
            {
                return lookup[parentId]
                    .OrderBy(t => t.SortOrder)
                    .Select(t =>
                    {
                        // 映射实体到 DTO
                        var dto = ObjectMapper.Map<ProjectTask, ProjectTaskTreeDto>(t);
                        dto.Children = Build(t.Id); // 递归填充子节点
                        return dto;
                    })
                    .ToList();
            }

            return Build(null);
        }
    }
}
