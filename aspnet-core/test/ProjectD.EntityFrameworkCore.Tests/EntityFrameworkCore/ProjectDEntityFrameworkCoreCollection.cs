using Xunit;

namespace ProjectD.EntityFrameworkCore;

[CollectionDefinition(ProjectDTestConsts.CollectionDefinitionName)]
public class ProjectDEntityFrameworkCoreCollection : ICollectionFixture<ProjectDEntityFrameworkCoreFixture>
{

}
