using Business_Layer;
using Data_Layer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingLayer2;

namespace TestLayer
{
    [TestFixture]
    public class InterestContextTest
    {
        private InterestContext context = new InterestContext(SetupFixture.dbContext);
        private Interest interest;
        private User u1, u2;



        [SetUp]
        public void CreateInterest()
        {
            interest = new Interest("tenis na masa");

            u1 = new User("Dimitrar", "Georgiev", 14, "mitkommg", "123456", "mitko@abv.bg");
            u2 = new User("Yordan", "Georgiev", 18, "dancho", "1356886", "dancho@abv.bg");

            interest.Users.Add(u1);
            interest.Users.Add(u2);

            context.Create(interest);
        }

        [TearDown]
        public void DropBrand()
        {
            foreach (Interest item in SetupFixture.dbContext.Interests)
            {
                SetupFixture.dbContext.Interests.Remove(item);
            }

            SetupFixture.dbContext.SaveChanges();
        }

        [Test]
        public void Create()
        {
            Interest newInterest = new Interest("spane");

            int InterestsBefore = SetupFixture.dbContext.Interests.Count();
            context.Create(newInterest);

            int brandsAfter = SetupFixture.dbContext.Interests.Count();
            Assert.IsTrue(InterestsBefore + 1 == brandsAfter, "Create() does not work!");
        }

        [Test]
        public void Read()
        {
            Interest readInterest = context.Read(interest.InterestID);

            Assert.AreEqual(interest, readInterest, "Interest does not return the same object!");
        }

        [Test]
        public void ReadWithNavigationalProperties()
        {
            Interest readInterest = context.Read(interest.InterestID);

            Assert.That(readInterest.Users.Contains(u1) && readInterest.Users.Contains(u2), "U1 and U2 is not in the User list!");
        }


        [Test]
        public void ReadAll()
        {
            List<Interest> brands = (List<Interest>)context.ReadAll();

            Assert.That(brands.Count != 0, "ReadAll() does not return interests!");
        }


        public void Update()
        {
            Interest changedInterest = context.Read(interest.InterestID);

            changedInterest.Name = "Updated " + interest.Name;

            context.Update(changedInterest);

            interest = context.Read(interest.InterestID);

            Assert.AreEqual(changedInterest, interest, "Update() does not work!");
        }

        [Test]
        public void Delete()
        {
            int interestsBefore = SetupFixture.dbContext.Interests.Count();

            context.Delete(interest.InterestID);
            int brandsAfter = SetupFixture.dbContext.Interests.Count();

            Assert.IsTrue(interestsBefore - 1 == brandsAfter, "Delete() does not work! ????");
        }

        //[Test]
        public void TestMethod()
        {
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }


    }


}