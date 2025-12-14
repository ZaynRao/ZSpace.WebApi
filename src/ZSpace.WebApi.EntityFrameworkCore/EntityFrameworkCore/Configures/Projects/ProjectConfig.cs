using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;
using ZSpace.WebApi.Projects;

namespace ZSpace.WebApi.EntityFrameworkCore.Configures.Projects
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable(WebApiConsts.DbTablePrefix + "Projects", WebApiConsts.DbSchema);
            builder.ConfigureByConvention();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Code).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Description).HasMaxLength(2000);
        }
    }
}
