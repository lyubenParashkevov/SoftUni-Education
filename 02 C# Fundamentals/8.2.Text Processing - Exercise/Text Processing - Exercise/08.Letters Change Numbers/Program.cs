namespace _08.Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<char, int> alphabet = new Dictionary<char, int>();

            char[] letters = new char[52] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            for (int i = 0;  i <  26; i++)
            {
                alphabet.Add(letters[i], i + 1);
            }
            for (int j = 26; j < letters.Length; j++)
            {
                alphabet.Add(letters[j],j - 25 );
            }
            
            string[] lettersAndNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string numberAsString = string.Empty;
            double tempSum = 0;
            double finalSum = 0;
            for (int i = 0; i < lettersAndNumbers.Length; i++)
            {
                char firstChar = lettersAndNumbers[i][0];
                char secondChar = lettersAndNumbers[i][lettersAndNumbers[i].Length - 1];

                for (int j = 1; j < lettersAndNumbers[i].Length - 1; j++)
                {
                    numberAsString += lettersAndNumbers[i][j];
                }
                int number = int.Parse(numberAsString);
                numberAsString = string.Empty;
                
                int valueNum = 0;
                if ( char.IsUpper(firstChar))
                {
                    if (alphabet.ContainsKey(firstChar))
                    {
                        valueNum = alphabet[firstChar];
                    }
                    tempSum += (double)number / valueNum;
                }
                if (char.IsLower(firstChar))
                {
                    if (alphabet.ContainsKey(firstChar))
                    {
                        valueNum = alphabet[firstChar];
                    }
                    tempSum += number * valueNum;
                }
                if (char.IsUpper(secondChar))
                {
                    if (alphabet.ContainsKey(secondChar))
                    {
                        valueNum = alphabet[secondChar];
                    }
                    tempSum -=  valueNum;
                }
                if (char.IsLower(secondChar))
                {
                    if (alphabet.ContainsKey(secondChar))
                    {
                        valueNum = alphabet[secondChar];
                    }
                    tempSum += valueNum;
                }
                finalSum += tempSum;
                tempSum = 0;
            }


            Console.WriteLine($"{finalSum:f2}");
        }
    }
}