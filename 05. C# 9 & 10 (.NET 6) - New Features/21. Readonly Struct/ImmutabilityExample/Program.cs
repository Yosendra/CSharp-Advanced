
List<BankAccount> bankAccounts = DataStorage.GetBankAccounts();
BankAccount firstBankAccount = bankAccounts[0];

double balance = DataStorage.GetCurrentBalance(firstBankAccount);

Console.WriteLine($"AccountNumber: {firstBankAccount.AccountNumber}, Balance: {balance}");
Console.ReadKey();

// Instread of using Class, we use readonly struct here
readonly struct BankAccount
{
    #region Properties

    public int AccountNumber { get; init; }
    public double CurrentBalance{ get; init; }

    #endregion of Properties

    // struct doesn't support parameterless constructor
    //public BankAccount(){}
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
        // After implementing readonly struct, this assignment become an error to compiler
        //bankAccount.AccountNumber = 1000;
        return bankAccount.CurrentBalance;
    }
}

