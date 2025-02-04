




using System.Text;
//Console.OutputEncoding = Encoding.Unicode;

List<Card> cards = new();
List<string> faces = new() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
List<string> suits = new() { "♠", "♥", "♦", "♣" };

string[] cardsDeck = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
for (int i = 0; i < cardsDeck.Length; i++)
{
    string[] tokens = cardsDeck[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string face = tokens[0];
    string suitInput = tokens[1];

    string suit = GetSymbols(suitInput);

    try
    {
        cards.Add(CreateCard(face, suit));

    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

foreach (Card card in cards)
{
    Console.Write(card.ToString());
}

Card CreateCard(string face, string suit)
{

    if (!faces.Contains(face) || !suits.Contains(suit))
    {
        throw new ArgumentException("Invalid card!");
    }

    Card card = new(face, suit);
    return card;
}

string GetSymbols(string suit)
{
    if (suit == "S")
    {
        suit = "♠";
    }
    else if (suit == "H")
    {
        suit = "♥";
    }
    else if (suit == "D")
    {
        suit = "♦";
    }
    else if (suit == "C")
    {
        suit = "♣";
    }

    return suit;
}

public class Card
{
    private string suit;
    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face { get; private set; }

    public string Suit { get; private set; }


    public List<string> Faces { get; private set; }


    public override string ToString()
    {
        return $"[{Face}{Suit}] ";
    }


}