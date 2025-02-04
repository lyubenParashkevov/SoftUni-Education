
using System.Security.Principal;

Dictionary<int, double> accounts = new Dictionary<int, double>();
string command;
int accountToOperate = 0;
double moneyToOperate = 0;

string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < input.Length; i++)
{
    string[] accountInfo = input[i].Split('-', StringSplitOptions.RemoveEmptyEntries);

    int account = int.Parse(accountInfo[0]);
    double money = double.Parse(accountInfo[1]);
    accounts.Add(account, money);
}

while (true)
{
    string commands = Console.ReadLine();
    if (commands == "End")
    {
        break;
    }

    string[] tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    command = tokens[0];
    accountToOperate = int.Parse(tokens[1]);
    moneyToOperate = double.Parse(tokens[2]);
    try
    {
        CommandCheck();
        AccountCheck();
        if (command == "Deposit")
        {
            accounts[accountToOperate] += moneyToOperate;
        }

        else
        {
            MoneyToWithdrawCheck();
            accounts[accountToOperate] -= moneyToOperate;
        }

        Console.WriteLine($"Account {accountToOperate} has new balance: {accounts[accountToOperate]:f2}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);      
    }

    finally
    {
        Console.WriteLine("Enter another command");
    }
}

void CommandCheck()
{   
        if (command != "Deposit" && command != "Withdraw")
        {
            throw new ArgumentException("Invalid command!");
        }
}

void AccountCheck()
{
    if (!accounts.ContainsKey(accountToOperate))
    {
        throw new ArgumentException("Invalid account!");
    }
}

void MoneyToWithdrawCheck()
{
    if (accounts[accountToOperate] < moneyToOperate)
    {
        throw new ArgumentException("Insufficient balance!");
    }
}
        

   