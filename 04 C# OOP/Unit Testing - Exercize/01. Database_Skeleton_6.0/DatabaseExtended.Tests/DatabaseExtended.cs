namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    [TestFixture]
    public class ExtendedDatabaseTests
    {


        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Person person1 = new Person(23l, "Ivan");
            Person person2 = new Person(33l, "Pesho");

            Database database = new Database(person1, person2);
            int expectedCount = 2;

            Person actualPerson1 = database.FindByUsername(person1.UserName);
            Person actualPerson2 = database.FindByUsername(person2.UserName);

            Assert.AreEqual(person1, actualPerson1);
            Assert.AreEqual(person2, actualPerson2);

            Assert.AreEqual(expectedCount, database.Count);
        }


        [Test]
        public void ConstructorShouldThrowExceptionIfCountIsMoreeThan16()
        {
            Person person1 = new Person(23L, "Avan");
            Person person2 = new Person(33l, "Besho");
            Person person3 = new Person(24l, "Cvann");
            Person person4 = new Person(34l, "Deshoo");
            Person person5 = new Person(25l, "Evannn");
            Person person6 = new Person(35l, "Feshooo");
            Person person7 = new Person(26l, "Gvancho");
            Person person8 = new Person(36l, "Heshko");
            Person person9 = new Person(27l, "Ivanski");
            Person person10 = new Person(37l, "Jeshov");
            Person person11 = new Person(28l, "Kvanov");
            Person person12 = new Person(38l, "Leshov");
            Person person13 = new Person(29l, "Mvanoff");
            Person person14 = new Person(39l, "Neshoff");
            Person person15 = new Person(213l, "Ovanin");
            Person person16 = new Person(3322l, "Peshof");
            Person person17 = new Person(239l, "RvanIvan");

            Database database;

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => database = new Database(person1, person2, person3, person4, person5, person6,
               person7, person8, person9, person10, person11, person12, person13, person14, person15,
               person16, person17));

            Assert.AreEqual("Provided data length should be in range [0..16]!", ex.Message);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfWeTryToAddMoreThan16()
        {
            Person person1 = new Person(23, "Avan");
            Person person2 = new Person(33, "Besho");
            Person person3 = new Person(24, "Cvann");
            Person person4 = new Person(34, "Deshoo");
            Person person5 = new Person(25, "Evannn");
            Person person6 = new Person(35, "Feshooo");
            Person person7 = new Person(26, "Gvancho");
            Person person8 = new Person(36, "Heshko");
            Person person9 = new Person(27, "Ivanski");
            Person person10 = new Person(37, "Jeshov");
            Person person11 = new Person(28, "Kvanov");
            Person person12 = new Person(38, "Leshov");
            Person person13 = new Person(29, "Mvanoff");
            Person person14 = new Person(39, "Neshoff");
            Person person15 = new Person(213, "Ovanin");
            Person person16 = new Person(3322, "Peshof");
            Person person17 = new Person(239, "RvanIvan");

            Database database = new Database(person1, person2, person3, person4, person5, person6,
               person7, person8, person9, person10, person11, person12, person13, person14, person15,
               person16);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => database.Add(person17));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", ex.Message);
        }


        [Test]
        public void AddMethodShouldThrowExceptionIfWeTryToAddPersonWithSameName() //?
        {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");

            Person[] people = new Person[] { person1, person2 };
            Database database = new Database(people);

            Person person3 = new Person(55, "Ivan");


            foreach (Person person in people.Where(p => p.UserName == person3.UserName))
            {
                string expectedName = person3.UserName;

            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => database.Add(person3));

            Assert.AreEqual("There is already user with this username!", ex.Message);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfWeTryToAddPersonWithSameId() //?
        {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");

            Person[] people = new Person[] { person1, person2 };
            Database database = new Database(people);

            Person person3 = new Person(33, "Ivanov");


            foreach (Person person in people.Where(p => p.Id == person3.Id))
            {
                long expectedId = person3.Id;

            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => database.Add(person3));

            Assert.AreEqual("There is already user with this Id!", ex.Message);
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");

            Person[] people = new Person[] { person1, person2 };

            Database database = new Database(people);
                   
            database.Remove();
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, database.Count);           
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenCountIsZero()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

       [Test]
       [TestCase(null)]
       [TestCase("")]       // ? (" ") ne raboti
       public void FindByUsernameShouldThrowExceptionWhenNameIsNullOrWhiteSpace(string userName)
       {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");

            Database database = new Database(person1, person2);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                 () => database.FindByUsername(userName));

            Assert.AreEqual("Username parameter is null!", ex.ParamName );  //? ex.ParamName
       }

        [Test]
        [TestCase("Triun")]
        [TestCase("Mamula")]
        public void FindByUsernameShouldThrowExceptionIfUsernameIsNotFound(string userName)
        {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");

            Database database = new Database(person1, person2);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                 () => database.FindByUsername(userName));

            Assert.AreEqual("No user is present by this username!", ex.Message );
        }

        [Test]
        public void FindByUsernameShouldWorkCorrect()
        {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");
            Person[] people = new Person[] { person1, person2 };
            Database database = new Database(people);

            string expectedResult = "Ivan";
            string actualResult = database.FindByUsername("Ivan").UserName;

            Assert.AreEqual(expectedResult, actualResult );
        }

        [Test]
        public void FindByUsernameShouldBeCaseSensitive()
        {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");
            Person[] people = new Person[] { person1, person2 };
            Database database = new Database(people);

            string expectedResult = "iVAn";
            string actualResult = "Ivan";

            Assert.AreNotEqual(expectedResult, actualResult );
        }

        [Test]
        public void FindByIdSholdNotBeLessThanZero()
        {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");
            Person[] people = new Person[] { person1, person2 };
            Database database = new Database(people);

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(()
            => database.FindById(-1));

            Assert.AreEqual("Id should be a positive number!", exception.ParamName);
        }

        [Test]
        public void FindByIdShouldWorkCorrect()
        {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");
            Person[] people = new Person[] { person1, person2 };
            Database database = new Database(people);

            string expectedResult = "Pesho";
            string actualResult = database.FindById(33).UserName;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfIdIsWrong()
        {
            Person person1 = new Person(23, "Ivan");
            Person person2 = new Person(33, "Pesho");
            Person[] people = new Person[] { person1, person2 };
            Database database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => database.FindById(25));

            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }
    }
}