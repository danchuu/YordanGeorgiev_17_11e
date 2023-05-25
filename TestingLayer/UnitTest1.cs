using Business_Layer;
using Data_Layer;
using NUnit.Framework.Internal;

namespace TestLayer
{
    [TestFixture]
    public class InterestContextTest
    {
        private InterestContext context = new InterestContext(SetUpFixture.dbContext);
        private Interest interest;
        private User u1, u2;



        [SetUp]
        public void CreateInterest()
        {
            interest = new Interest("pluvane");

            u1 = new User("Georgi", "Ivanov", 20, "georgi123", "123456", "georgi@abv.bg");
            u2 = new User("Ivan", "Petrov", 22, "ivan321", "7654321", "ivan@abv.bg");

            interest.Users.Add(u1);
            interest.Users.Add(u2);

            context.Create(interest);
        }

        [TearDown]
        public void DropBrand()
        {
            foreach (Interest item in .dbContext.Interests)
            {
                SetupFixture.dbContext.Interests.Remove(item);
            }

            SetupFixture.dbContext.SaveChanges();
        }

        [Test]
        public void Create()
        {
            Interest newInterest = new Interest("powerlift");

            int InterestsBefore = SetupFixture.dbContext.Interests.Count();
            context.Create(newInterest);

            int brandsAfter = SetupFixture.dbContext.Interests.Count();
            Assert.IsTrue(InterestsBefore + 1 == brandsAfter, "Create() does not work!");
        }

        [Test]
        public void Read()
        {
            Interest readInterest = context.Read(interest.Id);

            Assert.AreEqual(interest, readInterest, "Interest does not return the same object!");
        }

        [Test]
        public void ReadWithNavigationalProperties()
        {
            Interest readInterest = context.Read(interest.Id);

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
            Interest changedInterest = context.Read(interest.Id);

            changedInterest.Name = "Updated " + interest.Name;

            context.Update(changedInterest);

            interest = context.Read(interest.Id);

            Assert.AreEqual(changedInterest, interest, "Update() does not work!");
        }

        [Test]
        public void Delete()
        {
            int interestsBefore = SetupFixture.dbContext.Interests.Count();

            context.Delete(interest.Id);
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