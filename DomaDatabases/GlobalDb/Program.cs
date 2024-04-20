using FluentAssertions;
using GlobalDb.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

class TestClass
{
    static void Main(string[] args)
    {
        // Display the number of command line arguments.
        Console.WriteLine(args.Length);
      
        DbExistsAndConnectionStringContainsDbNameTest("GlobalDatabase.db");
    }



    // This Test just shows that the output folder has data in it
    public static void DbExistsAndConnectionStringContainsDbNameTest(string dbName)
    {
        var builder = new SqliteConnectionStringBuilder();

        var path = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory") as string
                                ?? AppDomain.CurrentDomain.BaseDirectory,
            builder.DataSource,

            dbName);

        builder.DataSource = Path.GetFullPath(path);

        var connectionString = builder.ToString();

        connectionString.Should().Contain(dbName);

        var optionsBuilder = new DbContextOptionsBuilder<GlobalDbContext>();
        optionsBuilder.UseSqlite(connectionString);
        var context = new GlobalDbContext((optionsBuilder.Options));
        context.Should().NotBeNull();
        var count = context.AppConfigurations.ToList().Count();
        var query = context.AppConfigurations.Where(x => x.AppConfigurationId != null).ToList();
    }

}