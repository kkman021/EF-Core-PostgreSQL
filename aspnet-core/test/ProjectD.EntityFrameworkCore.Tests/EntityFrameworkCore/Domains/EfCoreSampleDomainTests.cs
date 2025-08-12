using ProjectD.Samples;
using Xunit;

namespace ProjectD.EntityFrameworkCore.Domains;

[Collection(ProjectDTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ProjectDEntityFrameworkCoreTestModule>
{

}
