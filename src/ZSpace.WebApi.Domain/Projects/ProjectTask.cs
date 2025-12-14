using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ZSpace.WebApi.Projects
{
    public class ProjectTask : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 所属项目
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// 父任务 Id（null = 一级任务）
        /// </summary>
        public Guid? ParentTaskId { get; set; }

        /// <summary>
        /// 任务标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 任务详细说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// 任务优先级
        /// </summary>
        public TaskPriority Priority { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public Guid? AssigneeUserId { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? PlanStartTime { get; set; }

        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime? PlanEndTime { get; set; }

        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? ActualStartTime { get; set; }

        /// <summary>
        /// 实际结束时间
        /// </summary>
        public DateTime? ActualEndTime { get; set; }

        /// <summary>
        /// 排序号（同级任务排序）
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// 预估工时（小时）
        /// </summary>
        public decimal? EstimatedHours { get; set; }

        /// <summary>
        /// 实际工时（小时）
        /// </summary>
        public decimal? ActualHours { get; set; }

    }
}
