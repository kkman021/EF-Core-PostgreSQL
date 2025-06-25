namespace Shared
{
    public static class SharedConnectionString
    {
        public static string GetConnectionString()
        {
            return "Server=(localdb)\\mssqllocaldb;Database=EFCorePOC_SharedDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
    }
}
