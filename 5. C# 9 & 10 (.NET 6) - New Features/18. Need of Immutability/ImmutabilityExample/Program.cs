

List<BankAccount> bankAccounts = DataStorage.GetBankAccounts();
BankAccount firstBankAccount = bankAccounts[0];

double balance = DataStorage.GetCurrentBalance(firstBankAccount);

Console.WriteLine($"AccountNumber: {firstBankAccount.AccountNumber}, balance: {balance}");
Console.ReadKey();

class BankAccount
{
    public int AccountNumber { get; set; }
    public double CurrentBalance { get; set; }
}

class DataStorage
{
    // Done by You (Developer 1)
    public static List<BankAccount> GetBankAccounts()
    {
        return new()
        {
            new(){ AccountNumber = 1, CurrentBalance = 1000 },
            new(){ AccountNumber = 2, CurrentBalance = 2000 },
        };
    }

    // Done by Other (Developer 2)
    public static double GetCurrentBalance(BankAccount bankAccount)
    {
        // Unexpectedly they change the value of Account Number.
        // Need immutability for AccountNumber to keep data integrity
        bankAccount.AccountNumber = 1000;
        return bankAccount.CurrentBalance;
    }
}

