using ZSpace.WebApi.Samples;
using Xunit;

namespace ZSpace.WebApi.EntityFrameworkCore.Domains;

[Collection(WebApiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<WebApiEntityFrameworkCoreTestModule>
{

}
