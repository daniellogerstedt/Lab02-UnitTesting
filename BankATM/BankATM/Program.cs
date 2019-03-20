using System;

namespace BankATM
{
    public class Program
    {
        public static int balance = 50000;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank");
            Console.WriteLine();
            Console.WriteLine("Your account balance has been loaded, please choose the desired option below:");
            Console.WriteLine();
            bool continueTransactions = true;
            string anotherTransaction = "";
            while(continueTransactions)
            {
                Console.WriteLine("What would  you like to do?");
                Console.WriteLine();
                Console.WriteLine("1. Check Balance");
                Console.WriteLine();
                Console.WriteLine("2. Deposit");
                Console.WriteLine();
                Console.WriteLine("3. Withdrawl");
                Console.WriteLine();
                Console.WriteLine("4. Exit");
                Console.WriteLine();
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Your current balance is: ${balance}");
                        Console.WriteLine();
                        Console.WriteLine("Would you like to make another transaction? (Y/N)");
                        Console.WriteLine();
                        anotherTransaction = Console.ReadLine();
                        Console.WriteLine();
                        if (!anotherTransaction.Equals("Y") && !anotherTransaction.Equals("y")) continueTransactions = false;
                        break;
                    case "2":
                        Console.WriteLine("How much would you like to deposit?");
                        Console.WriteLine();
                        string depositAmount = Console.ReadLine();
                        Console.WriteLine();
                        bool completedDeposit = Deposit(depositAmount);
                        if (completedDeposit) Console.WriteLine($"Deposit of {depositAmount} completed. Your new balance is: ${balance}");
                        else
                        {
                            if (int.TryParse(depositAmount, out int depositValue))
                            {
                                if (depositValue < 0)
                                    depositAmount = $"-${depositValue * -1}";
                                else
                                    depositAmount = $"${depositAmount}";
                            }
                            Console.WriteLine($"Deposit not possible. Requested value, {depositAmount}, is an invalid input.");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to make another transaction? (Y/N)");
                        Console.WriteLine();
                        anotherTransaction = Console.ReadLine();
                        Console.WriteLine();
                        if (!anotherTransaction.Equals("Y") && !anotherTransaction.Equals("y")) continueTransactions = false;
                        break;
                    case "3":
                        Console.WriteLine("How much would you like to withdrawl?");
                        Console.WriteLine();
                        string withdrawlAmount = Console.ReadLine();
                        Console.WriteLine();
                        bool completedWithdrawl = Withdrawl(withdrawlAmount);
                        if (completedWithdrawl) Console.WriteLine($"Withdrawl of {withdrawlAmount} completed. Your new balance is: ${balance}");
                        else
                        {
                            if (int.TryParse(withdrawlAmount, out int withdrawlValue))
                            {
                                if (withdrawlValue < 0)
                                    withdrawlAmount = $"-${withdrawlValue * -1}";
                                else
                                    withdrawlAmount = $"${withdrawlAmount}";
                            }
                            Console.WriteLine($"Withdrawl not possible. Requested value, {withdrawlAmount}, is an invalid input or may exceed current balance of: ${balance}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to make another transaction? (Y/N)");
                        Console.WriteLine();
                        anotherTransaction = Console.ReadLine();
                        Console.WriteLine();
                        if (!anotherTransaction.Equals("Y") && !anotherTransaction.Equals("y")) continueTransactions = false;
                        break;
                    case "4":
                        continueTransactions = false;
                        break;
                    default:
                        Console.WriteLine($"{choice} is not a valid option, please select another option.");
                        break;
                }
            }
            Console.WriteLine("Thank You, Have a nice day.");
        }

        /// <summary>
        /// Deposit method to take in deposit amount and add to the current balance. Will reject any values that are not positive numeric values.
        /// </summary>
        /// <param name="valueString">This is the value the user wishes to deposit, it is in string format.</param>
        /// <returns>A boolean value based on completion or rejection of the input value.</returns>
        public static bool Deposit(string valueString)
        {
            if (int.TryParse(valueString, out int valueInt))
            {
                if (valueInt > 0)
                {
                    balance += valueInt;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Withdrawl method to take in withdrawl amount and remove from current balance. Will reject any values that are not positive numeric values less than or equal to current balance in string format.
        /// </summary>
        /// <param name="valueString">This is the value the user wishes to withdrawl, it is in string format.</param>
        /// <returns>A boolean value based on completion or rejection of the input value.</returns>
        public static bool Withdrawl(string valueString)
        {
            if (int.TryParse(valueString, out int valueInt))
            {
                if (valueInt > 0 && valueInt <= balance)
                {
                    balance -= valueInt;
                    return true;
                }
            }
            return false;
        }
    }
}
