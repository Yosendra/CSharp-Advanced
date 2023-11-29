// Immutability Class => class that contain read-only fields and read-only properties.

List<BankAccount> bankAccounts = DataStorage.GetBankAccounts();
BankAccount firstBankAccount = bankAccounts[0];

double balance = DataStorage.GetCurrentBalance(firstBankAccount);

Console.WriteLine($"AccountNumber: {firstBankAccount.AccountNumber}, balance: {balance}");
Console.ReadKey();

class BankAccount
{
    // Use readonly modifier in the fields, can only be assigned a value on constructor
    #region Fields

    private readonly int _accountNumber;
    private readonly double _currentBalance;

    #endregion of Fields

    // Set prperties to be getter only
    #region Properties
    public int AccountNumber 
    {
        get => _accountNumber;
    }

    public double CurrentBalance
    {
        get => _currentBalance;
    }

    #endregion of Properties

    // Constructor
    public BankAccount(int accountNumber, double currentBalanca)
    {
        _accountNumber = accountNumber;
        _currentBalance = currentBalanca;
    }
}

class DataStorage
{
    // Done by You (Developer 1)
    public static List<BankAccount> GetBankAccounts()
    {
        return new()
        {
            new(1, 1000),
            new(2, 2000),
        };
    }

    // Done by Other (Developer 2)
    public static double GetCurrentBalance(BankAccount bankAccount)
    {
        // Unexpectedly they change the value of Account Number.
        // Need immutability for AccountNumber to keep data integrity
        
        // After implementing readonly property, this assignment become an error to compiler
        //bankAccount.AccountNumber = 1000;
        return bankAccount.CurrentBalance;
    }
}

