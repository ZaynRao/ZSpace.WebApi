using ZSpace.WebApi.Samples;
using Xunit;

namespace ZSpace.WebApi.EntityFrameworkCore.Applications;

[Collection(WebApiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<WebApiEntityFrameworkCoreTestModule>
{

}
