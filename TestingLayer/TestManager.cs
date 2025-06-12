namespace TestingLayer;

using DataLayer;
using Microsoft.EntityFrameworkCore;

// Install this for convenience: https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnitTemplatesforVisualStudio
// View => Test Explorer

// For Testing Projects download these libraries with Nuget Package Manager:
// Microsoft.NET.Test.Sdk 17.8.0
// NUnit 3.14.0
// NUnit.Analyzers 3.9.0
// NUnit3TestAdapter 4.5.0
// Microsoft.EntityFrameworkCore.InMemory 8/9

using Microsoft.EntityFrameworkCore.InMemory;

[TestFixture]
public class TestManager
{
    internal static FitnessDbContext dbContext;

    static TestManager()
    {
        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        builder.UseInMemoryDatabase("TestDb");
        dbContext = new FitnessDbContext(builder.Options);
    }

    [OneTimeTearDown]
    public void Dispose()
    {
        dbContext.Dispose();
    }

    // [SetUp]
    // public void RandomSetup()
    // {
    //     DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
    //     builder.UseInMemoryDatabase(Guid.NewGuid().ToString()); // different name of the inmemory databases
    //     dbContext = new LibraryDbContext(builder.Options);
    // }

    //  [TearDown]
    // public void RandomDispose()
    // {
    //     dbContext.Dispose();
    // }

    [Test]
    public void Test1()
    {
        int number = 42;
        Assert.That(number == 42, "Number is not 42!");
    }

    [Test]
    public void Test2()
    {
        int number = 10;
        Assert.That(number < 10, "Method does not return number less than 10!");
    }
}