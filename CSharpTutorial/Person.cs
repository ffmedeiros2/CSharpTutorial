using CSharpTutorialEntities;
using CSharpTutorialEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTutorial
{
    public class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public List<string> CarList { get; set; }


        public Person()
        {
            CarList = new List<string>();
        }

        public PersonEntity AskForUserName(TutorialContext tutorialContext)
        {
            Console.WriteLine("What is your name?");
            string givenName = Console.ReadLine();

            var foundPerson = tutorialContext.PersonEntity.FirstOrDefault(x => x.FullName == givenName);

            FullName = foundPerson.FullName;
            Age = foundPerson.Age;

            return foundPerson;
        }
        public void AskForFullName()
        {
            Console.WriteLine("What is your name?");
            string fullName = Console.ReadLine();

            FullName = fullName;
        }
        public void AskForAge()
        {
            Console.WriteLine("What is your age?");
            int age = Convert.ToInt32(Console.ReadLine());

            Age = age;
        }

        public void AskCarCompany()
        {
            Console.WriteLine("Can you name a car company?");
            var givenCar = Console.ReadLine();

            CarList.Add(givenCar);
        }

        public void SaveCarCompanyInDatabase(TutorialContext tutorialContext, PersonEntity personEntity)
        {
            foreach(var carItem in CarList)
            {
                tutorialContext.CarCompany.Add(new CarCompany() {
                    CarID = Guid.NewGuid(),
                    CarCompanyName = carItem,
                    PersonEntityID = personEntity.PersonEntityID
                });
            }
            tutorialContext.SaveChanges();
        }

        public PersonEntity SavePersonInDatabase(TutorialContext tutorialContext)
        {
            var newPersonEntity = new PersonEntity()
            {
                PersonEntityID = Guid.NewGuid(),
                FullName = FullName,
                Age = Age
            };
            
            tutorialContext.PersonEntity.Add(newPersonEntity);

            tutorialContext.SaveChanges();

            return newPersonEntity;
        }

        public void ShowInformation()
        {
            Console.WriteLine("Your name is " + FullName + ", your age is " + Age);
            Console.WriteLine(CarList[0]);
            Console.WriteLine(CarList[1]);
            Console.WriteLine(CarList[2]);
        }        
    }
}
