using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace ZSpace.WebApi.Projects
{
    public class Project : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 项目编号（业务可读）
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 项目描述
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 项目状态
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// 项目负责人
        /// </summary>
        public Guid? OwnerUserId { get; set; }

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
        /// 项目下的全部任务（包含子任务）
        /// 扁平结构
        /// </summary>
        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}
