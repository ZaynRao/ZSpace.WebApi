using Xunit;

namespace ZSpace.WebApi.EntityFrameworkCore;

[CollectionDefinition(WebApiTestConsts.CollectionDefinitionName)]
public class WebApiEntityFrameworkCoreCollection : ICollectionFixture<WebApiEntityFrameworkCoreFixture>
{

}
