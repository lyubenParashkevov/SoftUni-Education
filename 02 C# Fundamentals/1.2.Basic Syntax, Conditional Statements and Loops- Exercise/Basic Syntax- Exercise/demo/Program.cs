

int[] numbers = new int[] {1, 2, 3, 4, 5};
Console.WriteLine(string.Join(", ", numbers));

int[] odd = numbers.Where(x => x % 2 != 0).ToArray();

Console.WriteLine(string.Join(", ",odd));