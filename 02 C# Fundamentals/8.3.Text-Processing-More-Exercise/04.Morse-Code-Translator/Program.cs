






Dictionary<string, string> dictionary = new Dictionary<string, string>()
{
    {  ".-" ,"A" },
    {  "-...", "B" },
    {  "-.-.", "C" },
    {  "-..", "D" },
    {  "." ,"E" },
    {  "..-.", "F" },
    {  "--.", "G" },
    {  "....", "H" },
    {  "..", "I" },
    {  ".---", "J" },
    {  "-.-","K" },
    {  ".-..", "L" },
    {  "--", "M" },
    {  "-.", "N" },
    {  "---", "O" },
    {  ".--.", "P" },
    {  "--.-", "Q" },
    {  ".-.", "R" },
    {  "...", "S" },
    {  "-", "T" },
    {  "..-", "U" },
    {  "...-", "V" },
    {  ".--", "W" },
    {  "-..-", "X" },
    {  "-.--", "Y" },
    {  "--..", "Z" },
};
string result = "";
string text = "";

string[] codeWords = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
for (int i = 0; i < codeWords.Length; i++)
{
    string[] code = codeWords[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
    for (int j = 0; j < code.Length; j++)
    {


        if (dictionary.ContainsKey(code[j]))
        {
            result += dictionary[code[j]];
        }


    }
    text += result + " ";
    result = "";

}
Console.WriteLine(text);