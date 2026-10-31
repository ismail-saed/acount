using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acount
{
    class Program
    {
        static void Main(string[] args)
        {
          
            SavingsAccount savings = new SavingsAccount("أحمد", 1000.0, 5.0);
            savings.Deposit(100.0);
            Console.WriteLine($"{savings.Name} Balance: ${savings.Balance}");

            CheckingAccount checking = new CheckingAccount("سارة", 500.0);
            checking.Withdraw(100.0); 
            Console.WriteLine($"{checking.Name} Balance: ${checking.Balance}");

            TrustAccount trust = new TrustAccount("علي", 10000.0, 3.0);
            trust.Deposit(5000.0);
            trust.Withdraw(1000.0); 
            Console.WriteLine($"{trust.Name} Balance: ${trust.Balance}");
        }
    }
}
