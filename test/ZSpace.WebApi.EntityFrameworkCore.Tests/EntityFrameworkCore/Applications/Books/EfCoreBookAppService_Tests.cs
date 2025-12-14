using ZSpace.WebApi.Books;
using Xunit;

namespace ZSpace.WebApi.EntityFrameworkCore.Applications.Books;

[Collection(WebApiTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<WebApiEntityFrameworkCoreTestModule>
{

}