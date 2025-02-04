namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            Database database = new Database(1, 3);
            int expectedCountResult = 2;
            int actualCountResult = database.Count;


            Assert.AreEqual(expectedCountResult, actualCountResult);
        }

        
        [Test]

        public void AddMethodShouldThrowExceptionIfWeTryToAddMoreThan16Ellements()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => database.Add(1));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);             

        }
        [Test]
        public void AddMethodShouldWorkProperly()
        {
            int[] expected = { 1, 2, 3, };

            Database database = new Database();

            foreach (int i in expected) 
            {
                database.Add(i);
            }

            int[] actual = database.Fetch();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Length, database.Count);

        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            Database database = new Database(1, 2);
            database.Remove();

            int[] expected = new int[] { 1 }; 
            int[] actual = database.Fetch();

            Assert.AreEqual(expected.Length, database.Count);

            Assert.AreEqual(1, database.Fetch().Single());

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void RemoveMethodShouldThrowExceptionIfCountIsLessThanZero()
        {
            Database database = new Database();
            

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => database.Remove());

            Assert.AreEqual("The collection is empty!", ex.Message);

        }

        [Test]
        public void FetchMethodShouldWorkProperly()
        {
            Database database = new Database(1,2,3);
            int[] expected = new int[] { 1, 2, 3 };
            int[] actual = database.Fetch();

            Assert.AreEqual(expected, actual);
        }

    }
}
