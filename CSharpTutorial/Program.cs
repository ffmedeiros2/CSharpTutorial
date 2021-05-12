using CSharpTutorialEntities;
using CSharpTutorialEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTutorial
{
    public class Program
    {
        public static ServiceProvider ServiceProvider { get; set; }

        private static TutorialContext _tutorialContext { get; set; }

        static void Main(string[] args)
        {
            _registerServiceProvider();

            _tutorialContext = ServiceProvider.GetService<TutorialContext>();

            Person person = new Person();

            Console.WriteLine("Are you alredy in the database? y or n");
            string givenValue = Console.ReadLine();

            PersonEntity foundPerson = null;

            if (givenValue == "y")
            {
                foundPerson = person.AskForUserName(_tutorialContext);

                if (foundPerson == null)
                {
                    Console.WriteLine("We couldn't find you. Please create a new account");

                    person.AskForFullName();
                    person.AskForAge();

                    foundPerson = person.SavePersonInDatabase(_tutorialContext);
                }
                if (foundPerson != null)
                {
                    Console.WriteLine("Hello " + foundPerson.FullName + " nice to see you again. We know your age is: " + foundPerson.Age);
                    var carCompanyList = _tutorialContext.CarCompany.Where(carItem => carItem.PersonEntityID == foundPerson.PersonEntityID).ToList();

                    foreach (var carComanyItem in carCompanyList)
                    {
                        Console.WriteLine("A car company you know is: " + carComanyItem.CarCompanyName);
                    }

                    Console.WriteLine("Do you still want to be in your database? y or n");
                    var givenRemoveAnswer = Console.ReadLine();
                    if (givenRemoveAnswer == "n")
                    {
                        _tutorialContext.PersonEntity.Remove(foundPerson);
                        _tutorialContext.SaveChanges();
                    }
                }
            }
            else
            {
                person.AskForFullName();
                person.AskForAge();

                foundPerson = person.SavePersonInDatabase(_tutorialContext);
            }

            person.AskCarCompany();
            person.AskCarCompany();
            person.AskCarCompany();

            person.SaveCarCompanyInDatabase(_tutorialContext, foundPerson);

            person.ShowInformation();

            Console.ReadLine();
        }

        private static void _registerServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<TutorialContext>(options => options.UseMySql(TutorialContextFactory.ConnectionString));
            serviceCollection.AddTransient<TutorialContext>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        
    }
}
