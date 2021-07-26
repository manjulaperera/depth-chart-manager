using DbUp;
using System.Reflection;

namespace DepthChartManager.DatabaseSeederApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=SportsDb.db";

            var upgrader =
                DeployChanges.To
                    .SQLiteDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();
        }
    }
}
