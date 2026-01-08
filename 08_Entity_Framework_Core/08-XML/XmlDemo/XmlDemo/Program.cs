

using System.Xml.Linq;

string xml = @"<?xml version=""1.0""?>
<library name=""My Library"">
	<book>
		<title>I, Robot</title>
		<author>Isaac Asimov</author>
	</book>
	<book>
		<title>Dreaming Void</title>
		<author>Peter Hamilton</author>
	</book>
	<book>
		<title>Dune</title>
		<author>Frank Hurbert</author>
	</book>
</library>
";


XDocument xDocument = XDocument.Parse(xml);
var books = xDocument.Root.Elements();
Console.WriteLine(xDocument.Root.Attribute("name").Value);

foreach (var book in books)
{
    Console.WriteLine($"{book.Element("title").Value} ({book.Element("author").Value})");
}

Console.WriteLine("-----------------------------------------------------------");
var books2 = xDocument.Root.Elements()
                           .Where(b => b.Element("author").Value == "Isaac Asimov")
                           .Select(b => new
                           {
                               Title = b.Element("title").Value,
                               Author = b.Element("author").Value
                           });

foreach (var book in books2)
{
    Console.WriteLine($"{book.Title} - {book.Author}");

}