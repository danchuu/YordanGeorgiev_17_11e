using Data_Layer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;


namespace TestingLayer2
{
    [SetUpFixture]
    public static class SetupFixture
    {
        public static DBContext dbContext;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
       
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            dbContext = new DBContext(builder.Options);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
           
            dbContext.Dispose();
        }
    }
}