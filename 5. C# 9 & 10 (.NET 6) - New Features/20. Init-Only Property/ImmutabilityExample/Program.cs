
List<BankAccount> bankAccounts = DataStorage.GetBankAccounts();
BankAccount firstBankAccount = bankAccounts[0];

double balance = DataStorage.GetCurrentBalance(firstBankAccount);

Console.WriteLine($"AccountNumber: {firstBankAccount.AccountNumber}, balance: {balance}");
Console.ReadKey();

class BankAccount
{
    // Object initializer => new ClassName() { Property1 = "", Property2 = 0 }
    // Instead of get ride the 'set', we use 'init' here
    // It means we can only assign a value to property when object initializing operation, otherwise there will be an error
    // We can remove the fields and constructor from before
    #region Properties

    public int AccountNumber { get; init; }
    public double CurrentBalance{ get; init; }

    #endregion of Properties
}

class DataStorage
{
    // Done by You (Developer 1)
    public static List<BankAccount> GetBankAccounts()
    {
        return new()
        {
            // Here the part of object initializer
            new() { AccountNumber = 1, CurrentBalance = 1000 },
            new() { AccountNumber = 2, CurrentBalance = 2000 },
        };
    }

    // Done by Other (Developer 2)
    public static double GetCurrentBalance(BankAccount bankAccount)
    {
        // After implementing 'init' at property, this assignment become an error to compiler
        //bankAccount.AccountNumber = 1000;
        return bankAccount.CurrentBalance;
    }
}

