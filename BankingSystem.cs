
namespace BankingApp
{
    enum AccountType
    {
        Saving,
        Current
    }

    class BankAccount
    {
        private int accountNumber;
        private string accountHolderName;
        private long phoneNumber;
        private AccountType accountType;
        private double balance;
        private static int accountCounter = 101;

        public int AccountNumber { get { return accountNumber; } }
        public string AccountHolderName { get { return accountHolderName; } }

        public BankAccount(string name, long phone, AccountType type)
        {
            accountNumber = accountCounter++;
            accountHolderName = name;
            phoneNumber = phone;
            accountType = type;
            balance = 0;
        }

        public void Deposit(double amount)
        {
            if (amount >= 500)
            {
                balance += amount;
                System.Console.WriteLine("Amount deposited successfully.");
            }
            else
            {
                System.Console.WriteLine("Minimum deposit amount is 500.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                if (amount >= 100)
                {
                    balance -= amount;
                    System.Console.WriteLine("Amount withdrawn successfully.");
                    System.Console.WriteLine("Current balance: " + balance);
                }
                else
                {
                    System.Console.WriteLine("Minimum withdrawal amount is 100.");
                }
            }
            else
            {
                System.Console.WriteLine("Insufficient balance.");
            }
        }

        public void CheckBalance()
        {
            System.Console.WriteLine("Current balance: " + balance);
        }

        public override string ToString()
        {
            return "Account Number: " + accountNumber + "\n" +
                   "Account Holder Name: " + accountHolderName + "\n" +
                   "Phone Number: " + phoneNumber + "\n" +
                   "Account Type: " + accountType + "\n" +
                   "Balance: " + balance;
        }
    }

    class BankingSystem
    {
        private static BankAccount[] accounts = new BankAccount[100];
        private static int accountCount = 0;

        public static void Main(string[] args)
        {
            while (true)
            {
                System.Console.WriteLine("1. Create Account");
                System.Console.WriteLine("2. Login");
                System.Console.WriteLine("3. Exit");
                System.Console.Write("Enter your choice: ");
                string choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        Login();
                        break;
                    case "3":
                        System.Console.WriteLine("Exiting...");
                        return;
                    default:
                        System.Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void CreateAccount()
        {
            System.Console.Write("Enter your name: ");
            string name = System.Console.ReadLine();
            System.Console.Write("Enter your phone number: ");
            long phone = long.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Select account type:");
            System.Console.WriteLine("1. Saving Account");
            System.Console.WriteLine("2. Current Account");
            System.Console.Write("Enter your choice: ");
            int typeChoice = int.Parse(System.Console.ReadLine());
            AccountType type = (AccountType)(typeChoice - 1);

            BankAccount account = new BankAccount(name, phone, type);
            accounts[accountCount++] = account;

            System.Console.WriteLine("\nAccount created successfully.");
            System.Console.WriteLine(account.ToString());
            System.Console.Write("Press Enter to continue...");
            System.Console.ReadLine();
        }

        private static void Login()
        {
            System.Console.Clear();
            System.Console.Write("Enter account number: ");
            int accountNumber = int.Parse(System.Console.ReadLine());

            BankAccount account = null;
            for (int i = 0; i < accountCount; i++)
            {
                if (accounts[i] != null && accounts[i].AccountNumber == accountNumber)
                {
                    account = accounts[i];
                    break;
                }
            }

            if (account != null)
            {
                System.Console.WriteLine("Welcome, " + account.AccountHolderName + "!");
                DisplayTransactionMenu(account);
            }
            else
            {
                System.Console.WriteLine("Error: Account does not exist.");
                System.Console.WriteLine("1. Retry");
                System.Console.WriteLine("2. Create new account");
                System.Console.Write("Enter your choice: ");
                string choice = System.Console.ReadLine();
                if (choice == "1")
                {
                    Login();
                }
                else if (choice == "2")
                {
                    CreateAccount();
                }
                else
                {
                    System.Console.WriteLine("Invalid choice.");
                }
            }
        }

        private static void DisplayTransactionMenu(BankAccount account)
        {
            while (true)
            {
                System.Console.WriteLine("\n1. Deposit");
                System.Console.WriteLine("2. Withdraw");
                System.Console.WriteLine("3. Check Balance");
                System.Console.WriteLine("4. Exit");
                System.Console.Write("Enter your choice: ");
                string choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        System.Console.Write("Enter deposit amount: ");
                        double depositAmount = double.Parse(System.Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;
                    case "2":
                        System.Console.Write("Enter withdrawal amount: ");
                        double withdrawalAmount = double.Parse(System.Console.ReadLine());
                        account.Withdraw(withdrawalAmount);
                        break;
                    case "3":
                        account.CheckBalance();
                        break;
                    case "4":
                        System.Console.WriteLine("Exiting...");
                        return;
                    default:
                        System.Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
