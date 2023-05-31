// Project Prolog
// Name: Andrew Campbell
// CS3260 Section 001
// Project: Lab #04 Banking Program
// Date: 2/10/23
// Purpose: <The purpose of the project is to learn how to use interfaces, inheritance and classes together>
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------
using BankingApp4;
using System.Security.Principal;

namespace BankingApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 04: Banking Application Phase 3\n");
            AccountManager Manager = new AccountManager();//creating an account manager
            string inValue;
            string inName;
            string inAddress;

            while (true)//looping through asking if user wants to create an account or quit
            {
                Console.WriteLine("\nWould you like to add an account or quit?\nPress:\n" +
                    "(A) to Add Account  or\n" +
                    "(F) to Finish Adding Accounts");
                inValue = Console.ReadLine();
                if (inValue.ToUpper() == "F")
                {
                    break;
                }
                else if (inValue.ToUpper() == "A")
                {
                    while (true)//getting name and error validation
                    {
                        Console.WriteLine("\nPlease enter the name for the account: ");
                        inName = Console.ReadLine();
                        if (inName == "")//error validation
                        {
                            Console.WriteLine("You did not enter a name please try again: ");
                        }
                        else if (int.TryParse(inName, out int value))
                        {
                            Console.WriteLine("You did not enter a name please try again: ");
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true)//getting address and error validation
                    {
                        Console.WriteLine("\nPlease enter the Address for the account: ");
                        inAddress = Console.ReadLine();
                        if (inAddress == "")//error validation
                        {
                            Console.WriteLine("You did not enter a Address please try again: ");
                        }
                        else if (int.TryParse(inAddress, out int value))
                        {
                            Console.WriteLine("You did not enter a Address please try again: ");
                        }
                        else
                        {
                            break;
                        }
                    }
                    while (true)//getting what type of account and error validation
                    {
                        Console.WriteLine("What Type of account would you like, Press: 1 - for Checkings, 2 - for Savings, 3 - for CD ");
                        string inOption = Console.ReadLine();
                        if (inOption == "1" || inOption == "2" || inOption == "3")//giving only 3 options to choose from
                        {
                            if (inOption == "1")//For Checking
                            {
                                while (true)// getting initial deposit and error checking
                                {
                                    decimal finalAmount;
                                    Console.WriteLine("How much do you want to start out with?");
                                    string inDeposit = Console.ReadLine();
                                    if (inDeposit == "")
                                    {
                                        Console.WriteLine("You did not enter a correct amount please try again.\n");
                                    }
                                    else if (decimal.TryParse(inDeposit, out decimal value))
                                    {
                                        finalAmount = value;
                                        if (finalAmount < 10)
                                        {
                                            Console.WriteLine("You need to deposit at least 10$ for checking please try again.");
                                        }
                                        else//setting up account
                                        {
                                            CheckingAccount account = new CheckingAccount();
                                            account.CheckSetBalance(finalAmount);
                                            account.accountServiceFee = 5;
                                            account.CheckSetBalance(value);
                                            account.SetName(inName);
                                            account.SetAddress(inAddress);
                                            Manager.StoreAccount(account.AccountNumber(), account);
                                            Console.WriteLine($"Account Number Generated: {account.accountNumber}");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You did not enter a correct amount please try again.\n");
                                    }

                                }
                                break;

                            }
                            else if (inOption == "2")//For saving
                            {
                                while (true)//getting initial balance and error validation
                                {
                                    decimal finalAmount;
                                    Console.WriteLine("How much do you want to start out with?");
                                    string inDeposit = Console.ReadLine();
                                    if (inDeposit == "")
                                    {
                                        Console.WriteLine("You did not enter a correct amount please try again.\n");
                                    }
                                    else if (decimal.TryParse(inDeposit, out decimal value))
                                    {
                                        finalAmount = value;
                                        if (finalAmount < 100)
                                        {
                                            Console.WriteLine("You need to deposit at least 100$ for checking please try again.");
                                        }
                                        else//setting up account
                                        {
                                            SavingAccount account = new SavingAccount();
                                            account.SaveSetBalance(finalAmount);
                                            account.accountServiceFee = 0;
                                            account.SaveSetBalance(value);
                                            account.SetName(inName);
                                            account.SetAddress(inAddress);
                                            Manager.StoreAccount(account.AccountNumber(), account);
                                            Console.WriteLine($"Account Number Generated: {account.accountNumber}");
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You did not enter a correct amount please try again.\n");
                                    }

                                }
                                break;

                            }
                            else//For CD
                            {
                                while (true)//gettting initial deposit and error validation
                                {
                                    decimal finalAmount;
                                    Console.WriteLine("How much do you want to start out with?");
                                    string inDeposit = Console.ReadLine();
                                    if (inDeposit == "")
                                    {
                                        Console.WriteLine("You did not enter a correct amount please try again.\n");
                                    }
                                    else if (decimal.TryParse(inDeposit, out decimal value))
                                    {
                                        finalAmount = value;
                                        if (finalAmount < 500)
                                        {
                                            Console.WriteLine("You need to deposit at least 500$ for checking please try again.");
                                        }
                                        else//setting up account
                                        {
                                            CDAccount account = new CDAccount();
                                            account.CDSetBalance(finalAmount);
                                            account.accountServiceFee = 8;
                                            account.CDSetBalance(value);
                                            account.SetName(inName);
                                            account.SetAddress(inAddress);
                                            Manager.StoreAccount(account.AccountNumber(), account);
                                            Console.WriteLine($"Account Number Generated: {account.accountNumber}");
                                            break;

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You did not enter a correct amount please try again.\n");
                                    }

                                }
                                break;

                            }
                        }
                        else
                        {
                            Console.WriteLine("You have entered an invalid option, please try again.");//error validation
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You entered an incorrect selection please try again");
                }



            }

            Console.WriteLine("\n-Account Selection-\n");
            string searchAccountNumber;
            Console.WriteLine("\n\nAccount Details-\n");
            while (true)//looping through asking if user wants to create an account or quit
            {
                Console.WriteLine("\nWould you like to search for a account or quit?\nPress:\n" +
                    "(S) to Search for a Account  or\n" +
                    "(Q) to Quit");
                searchAccountNumber = Console.ReadLine();
                if (searchAccountNumber.ToUpper() == "Q")
                {
                    break;
                }
                else if (searchAccountNumber.ToUpper() == "S")
                {
                    string searchAccount;
                    while (true)//looping through asking if user wants to create an account or quit
                    {


                        Console.WriteLine("\nPlease enter a account number or enter (Q) to quit?\nPress:\n");//searching by account number
                        searchAccount = Console.ReadLine().ToUpper();

                        Account currentSelectedAccount = Manager.FindAccount(searchAccount);

                        if (searchAccount != null && searchAccount == "Q")
                        {
                            break;
                        }
                        else
                        {
                            if (currentSelectedAccount == null)
                            {
                                Console.WriteLine("Wrong account number please try again.\n");
                            }
                            else if (currentSelectedAccount.accountNumber == searchAccount)
                            {
                                /////////////////account processing/////////////////////////

                                if (currentSelectedAccount.accountNumber[4].ToString() == "S")// savings account withdraw/deposit
                                {
                                    while (true)//gettting initial deposit and error validation
                                    {
                                        Console.WriteLine($"Balance: {currentSelectedAccount.balance}");
                                        Console.WriteLine("What would you like to do?\nPress:\n(W) to Withdraw\n(D) to deposit\n(S) to switch account");
                                        string inAnswer = Console.ReadLine().ToUpper();
                                        if (inAnswer == "S")
                                        {
                                            break;
                                        }
                                        else if (inAnswer == "D")//depositing savings account
                                        {
                                            Console.WriteLine("How much do you want to deposit?");
                                            string deposit = Console.ReadLine();
                                            if (decimal.TryParse(deposit, out decimal decValue) && (decValue > 0))
                                            {
                                                SavingAccount save = new SavingAccount();
                                                currentSelectedAccount.PayInFunds(decValue);//depositing money from balance in account
                                                currentSelectedAccount.SetBalance(currentSelectedAccount.balance * save.getInterest());//giving interest

                                            }
                                            else
                                            {
                                                Console.WriteLine("Incorrect input or amount please try again.\n");
                                            }
                                        }
                                        else if (inAnswer == "W")//withdrawing savings account
                                        {
                                            Console.WriteLine("How much do you want to withdraw?");
                                            string withdraw = Console.ReadLine();
                                            if (decimal.TryParse(withdraw, out decimal decValue) && (currentSelectedAccount.balance - decValue >= 0) && decValue > 0)
                                            {
                                                currentSelectedAccount.WithdrawFunds(decValue);//withdrawing money from balance in account
                                            }
                                            else
                                            {
                                                Console.WriteLine("Incorrect input please try again.\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have enterend a wrong selection please try again.\n");
                                        }
                                    }
                                }
                                else if (currentSelectedAccount.accountNumber[4].ToString() == "C")//checking account withdrawl/depositing
                                {
                                    while (true)//gettting initial deposit and error validation
                                    {
                                        Console.WriteLine($"Balance: {currentSelectedAccount.balance}");
                                        Console.WriteLine("What would you like to do?\nPress:\n(W) to Withdraw\n(D) to deposit\n(S) to switch account");
                                        string inAnswer = Console.ReadLine().ToUpper();
                                        if (inAnswer == "S")
                                        {
                                            break;
                                        }
                                        else if (inAnswer == "D")//depositing checking account
                                        {
                                            Console.WriteLine("How much do you want to deposit?");
                                            string deposit = Console.ReadLine();
                                            if (decimal.TryParse(deposit, out decimal decValue) && (decValue > 0))
                                            {
                                                currentSelectedAccount.PayInFunds(decValue);//depositing money from balance in accoun
                                            }
                                            else
                                            {
                                                Console.WriteLine("Incorrect input or amount please try again.\n");
                                            }
                                        }
                                        else if (inAnswer == "W")//withdrawing checking account
                                        {
                                            Console.WriteLine("How much do you want to withdraw?");
                                            string withdraw = Console.ReadLine();
                                            if (decimal.TryParse(withdraw, out decimal decValue) && (currentSelectedAccount.balance - decValue >= 5) && decValue > 0)
                                            {
                                                if (currentSelectedAccount.balance - decValue < 100)
                                                {
                                                    Console.WriteLine("You have been charged a 5$ overdraft fee.");
                                                    currentSelectedAccount.balance -= 5;// charging overdraft fee
                                                }
                                                currentSelectedAccount.WithdrawFunds(decValue);//withdrawing money from balance in account
                                            }
                                            else
                                            {
                                                Console.WriteLine("Incorrect input please try again.\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have enterend a wrong selection please try again.\n");
                                        }
                                    }
                                }

                                else if (currentSelectedAccount.accountNumber[4].ToString() == "D")//cd account
                                {
                                    while (true)//gettting initial deposit and error validation
                                    {
                                        Console.WriteLine($"Balance: {currentSelectedAccount.balance}");
                                        Console.WriteLine("What would you like to do?\nPress:\n(W) to Withdraw\n(S) to switch account");
                                        string inAnswer = Console.ReadLine().ToUpper();
                                        if (inAnswer == "S")
                                        {
                                            break;
                                        }
                                        else if (inAnswer == "W")//withdrawing CD account
                                        {
                                            Console.WriteLine("How much do you want to withdraw?");
                                            string withdraw = Console.ReadLine();
                                            if (decimal.TryParse(withdraw, out decimal decValue) && (currentSelectedAccount.balance - decValue >= 0) && decValue > 0)
                                            {
                                                currentSelectedAccount.WithdrawFunds(decValue);//withdrawing money from balance in account
                                            }
                                            else
                                            {
                                                Console.WriteLine("Incorrect input please try again.\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have enterend a wrong selection please try again.\n");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong account number please try again.\n");
                            }
                        }

                    }
                }
                else { Console.WriteLine("You have entered a wrong selection please try again.\n"); }

            }
            //Console.WriteLine(Manager);//printing out account details
        }
    }
}