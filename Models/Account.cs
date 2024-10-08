using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppWIthHasARelationship.Models
{
    internal class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Balance {  get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public readonly double min_balance = 500;

        public Account(int id,string name,double amount) { 
            ID = id;
            Name = name;
            Balance = amount;
            if(amount<min_balance) 
                Balance = min_balance;

        }
        public static void AddTransaction(string type,Account account)
        {
            Random random = new Random();
            Transaction transaction = new Transaction()
            {
                Id = random.Next(101,999),
                Type = type,
                Amount = account.Balance,
                DateAndTime = DateTime.Now,
            };
            account.Transactions.Add(transaction);
        }

        public static string Deposite(double amount,Account account)
        {
            account.Balance += amount;
            AddTransaction("Deposite",account);
            return "Deposited sucessfully!";
        }

        public static string Withdraw(double amount,Account account)
        {
            if(account.Balance - amount <= 0)
            {
                return "Insufficient Balance!";
            }
            account.Balance -= amount;
            AddTransaction("Withdrw", account);
            return "Withdrawal sucessfully!";
        }

        public static string ShowAllTransaction(Account account)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Transaction transaction in account.Transactions) { 
                sb.Append(transaction.ToString()+"\n");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return $"==============================\n" +
                $"Id : {ID}\n" +
                $"Name : {Name}\n" +
                $"Balance : {Balance}";
        }
    }
}
