using CSharpTutorialEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTutorialEntities
{
    public class TutorialContext : DbContext
    {
        public TutorialContext(DbContextOptions<TutorialContext> options) : base(options) { }

        public DbSet<CarCompany> CarCompany { get; set; }
        public DbSet<FoodCompany> FoodCompany { get; set; }
        public DbSet<PersonEntity> PersonEntity { get; set; }
    }
}
