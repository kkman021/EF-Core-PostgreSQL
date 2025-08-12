using ProjectD.Samples;
using Xunit;

namespace ProjectD.EntityFrameworkCore.Applications;

[Collection(ProjectDTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ProjectDEntityFrameworkCoreTestModule>
{

}
