using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;
using ZSpace.WebApi.Projects;

namespace ZSpace.WebApi.EntityFrameworkCore.Configures.Projects
{
    public class ProjectTaskConfig : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.ToTable(WebApiConsts.DbTablePrefix + "ProjectTasks",WebApiConsts.DbSchema);

            builder.ConfigureByConvention();

            // ---------- 基础字段 ----------

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Description)
                   .HasMaxLength(2000);

            builder.Property(x => x.Status)
                   .IsRequired();

            builder.Property(x => x.Priority)
                   .IsRequired();

            builder.Property(x => x.SortOrder)
                   .HasDefaultValue(0);

            builder.Property(x => x.EstimatedHours)
                   .HasPrecision(10, 2);

            builder.Property(x => x.ActualHours)
                   .HasPrecision(10, 2);

            // ---------- 索引（非常重要） ----------

            builder.HasIndex(x => x.ProjectId);

            builder.HasIndex(x => x.ParentTaskId);

            builder.HasIndex(x => new
            {
                x.ProjectId,
                x.ParentTaskId
            });

            // ---------- 关系配置 ----------

            builder.HasOne<Project>()
                   .WithMany(p => p.Tasks)
                   .HasForeignKey(x => x.ProjectId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            // 父子任务（自关联，不级联删除，避免误删整棵树）
            builder.HasOne<ProjectTask>()
                   .WithMany()
                   .HasForeignKey(x => x.ParentTaskId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
