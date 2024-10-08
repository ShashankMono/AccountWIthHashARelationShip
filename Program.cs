using AccountAppWIthHasARelationship.Models;
using System.Text;

namespace AccountAppWIthHasARelationship
{
    internal class Program
    {
        public static List<Account> accounts = new List<Account>();
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        public static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine($"\nWelcome to AccountApp!\n" +
                    $"1.Add account\n" +
                    $"2.Deposite\n" +
                    $"3.Withdraw\n" +
                    $"4.ShowAllTransactions\n" +
                    $"5.ShowAllAccountDetails\n" +
                    $"6.Exit\n");

                int choice = int.Parse( Console.ReadLine() );   
                ExecuteTask( choice );
            }
        }

        public static void ExecuteTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    CreateAccount();
                    break;

                case 2:
                    Deposite();
                    break;

                case 3:
                    Withdraw();
                    break;

                case 4:
                    ShowTransaction(); 
                    break;
                    
                case 5:
                    ShowAllAccountsDetails(); 
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("please enter correct choice");
                    break;
            }
        }

        public static Account FindAccount()
        {
            Console.WriteLine("Enter account id:");
            int id = int.Parse(Console.ReadLine());
            Account account = accounts.Where(account=> account.ID == id).FirstOrDefault();
            return account;
        }

        public static void ShowTransaction()
        {
            Account account = FindAccount();
            if(account == null)
            {
                Console.WriteLine("Invalid Account id:");
                return;
            }
            Console.WriteLine(Account.ShowAllTransaction(account));
        }

        public static void Deposite()
        {
            Account account = FindAccount();
            if (account == null)
            {
                Console.WriteLine("Invalid Account id:");
                return;
            }
            Console.WriteLine("Enter amount:");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine(Account.Deposite(amount, account));
        }

        public static void Withdraw()
        {
            Account account = FindAccount();
            if (account == null)
            {
                Console.WriteLine("Invalid Account id:");
                return;
            }
            Console.WriteLine("Enter amount:");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine(Account.Withdraw(amount, account));
        }

        public static void CreateAccount()
        {
            Console.WriteLine("Enter account number:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Account holder name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Opening balance should be non negative");
            double balance = double.Parse(Console.ReadLine());

            Account account = new Account(id,name,balance);
            Account.AddTransaction("Opening balance",account);
            accounts.Add(account);
            Console.WriteLine("Account created sucessfully!");
        }

        public static void ShowAllAccountsDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Account account in accounts)
            {
                stringBuilder.Append(account.ToString()+"\n");   
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
