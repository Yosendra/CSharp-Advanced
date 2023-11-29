
List<BankAccount> bankAccounts = DataStorage.GetBankAccounts();
BankAccount firstBankAccount = bankAccounts[0];

double balance = DataStorage.GetCurrentBalance(firstBankAccount);

Console.WriteLine($"AccountNumber: {firstBankAccount.AccountNumber}, Balance: {balance}");
Console.ReadKey();

// Instread of using Class, we use readonly struct here
readonly struct BankAccount
{
    #region Fields

    private readonly int _accountNumber;
    private readonly double _currentBalance; 

    #endregion of Fields

    #region Properties

    public int AccountNumber { get; init; }
    public double CurrentBalance{ get; init; }

    #endregion of Properties

    // Has to update the TargetFramework to get C# 11 language version to be able to use this technique 
    public BankAccount()
    {
        this._accountNumber = 0;
        this._currentBalance = 0;
    }

    // Has to update the TargetFramework to get C# 11 language version to be able to use this technique 
    public BankAccount(int accountNumber, double currentBalance)
    {
        this._accountNumber = accountNumber;
        this._currentBalance = currentBalance;
    }

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

