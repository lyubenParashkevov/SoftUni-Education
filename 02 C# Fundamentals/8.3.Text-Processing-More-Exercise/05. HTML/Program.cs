
string title = Console.ReadLine();

Console.WriteLine($"<h1> \n    {title}\n</h1>");

string article = Console.ReadLine();

Console.WriteLine($"<article> \n    {article}\n</article>");

string input;
while ((input = Console.ReadLine()) != "end of comments")
{
    Console.WriteLine($"<div> \n    {input}\n</div>");
}