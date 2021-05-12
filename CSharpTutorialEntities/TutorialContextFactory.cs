using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTutorialEntities
{
    public class TutorialContextFactory : IDesignTimeDbContextFactory<TutorialContext>
    {
        public static string ConnectionString = "Server=localhost;Port=3306;Database=tutorialdb;Uid=tutorial;Pwd=tutorial;";

        public TutorialContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TutorialContext>();

            optionsBuilder.UseMySql(ConnectionString);

            return new TutorialContext(optionsBuilder.Options);
        }
    }
}
