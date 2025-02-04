namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class Tests
    {
        private Book book;
        private Dictionary<int, string> bookNotesTest = new Dictionary<int, string>();

        [SetUp]
        public void StartUp()
        {
           book = new Book("Op", "LK");
        }

        [Test]
        public void BookConstructorShouldWorkCorrect()
        {
            string expectedName = "Op";
            string expectedAuthor = "LK";
            Assert.AreEqual(expectedName, book.BookName);
            Assert.AreEqual(expectedAuthor, book.Author);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void BookNameShouldNotBeNullOrEmpty(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Book(name, "LK") );
            Assert.AreEqual($"Invalid {nameof(this.book.BookName)}!", ex.Message);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void BookAuthorShouldNotBeNullOrEmpty(string author)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Book("Op", author));
            Assert.AreEqual($"Invalid {nameof(this.book.Author)}!", ex.Message);
        }

        [Test]

        public void FootnoteCountPropertyShouldWorkCorrect()
        {
            int expected = bookNotesTest.Count;
            int actual = book.FootnoteCount;

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void AddFootNoteShouldWorkCorrect()
        {
            book.AddFootnote(3, "aa");
            int expected = 1;
            Assert.AreEqual(expected, book.FootnoteCount);
        }

        [Test]

        public void AddFootNoteShouldThrowExceptionIfContainsElement()
        {
            book.AddFootnote(3, "aa");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException> (
                () => book.AddFootnote(3, "an"));

            Assert.AreEqual("Footnote already exists!", ex.Message);
        }

       //[Test]
       //
       //public void FindFootnoteShouldThrowExceptionIfDictionaryContainsNotKey()
       //{
       //    bookNotesTest.Add(3, "gk");
       //    int expected = 3;
       //    if (!bookNotesTest.ContainsKey(expected))
       //    {
       //        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
       //            () => bookNotesTest.ContainsKey(expected));
       //            Assert.AreEqual("Footnote doesn't exists!", ex.Message);
       //    }
       //}

        [Test]


    }
}