using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp4
{
    public enum AccountState
    {
        /// <summary>
        /// This enum contains all the states of the account
        /// </summary>
        New,
        Active,
        UnderAudit,
        Frozen,
        Closed
    }
    public abstract class Account : IAccount
    ///<summary>
    /// This class models a bank account. It contains key information
    /// about a account and methods to manage that data/// </summary>
    {
        public string name;//variables
        public string address;
        public string accountNumber;
        public decimal balance;
        const int InitialBalance = 100;
        public AccountState state;//enum variable
        public static int incAccNum = 1000;

        public Account()
        /// <summary>
        /// Purpose: Constructor to initialize account with set state and balance
        /// </summary>
        /// <param state="AccountState.New">setting to New enum</param>
        /// <param balance="InitialBalance">starting out all account holders with 100$</param>

        {
            state = AccountState.New;
            balance = InitialBalance;

        }
        public override string ToString()
        /// <summary>
        /// Purpose: To override the printing of the account to a customized one
        /// </summary>
        /// <returns>A structured output string</returns>
        {
            return
                $"Account Holder's Name: {name}\n" +
                $"Address: {address}\n" +
                $"Account Number: {accountNumber}\n" +
                $"Current Balance: {balance}\n";
        }

        public bool SetName(string inName)
        /// <summary>
        /// Purpose: To set the account holders name
        /// </summary>
        /// <param name="inName">any valid string</param>
        /// <returns>boolean</returns>
        {
            name = inName;
            if (name == null || name == "")
            {
                return false;
            }
            else { return true; }
        }

        public string GetName()
        {
            /// <summary>
            /// Purpose: To return the account holder name
            /// </summary>
            /// <returns>name</returns>
            return name;
        }

        public bool SetAddress(string inAddress)
        /// <summary>
        /// Purpose: To set account holders address
        /// </summary>
        /// <param address="inAddress">any valid string value</param>
        /// <returns>boolean</returns>
        {
            address = inAddress;
            if (address == null || address == "")
            {
                return false;
            }
            return true;
        }

        public string GetAddress()
        /// <summary>
        /// Purpose: To address of account holder
        /// </summary>
        /// <returns>address</returns>
        {
            return address;
        }

        public bool PayInFunds(decimal amount)
        /// <summary>
        /// Purpose: To deposit funds into account balance
        /// </summary>
        /// <param amount>any valid decimal value thats not negative</param>

        /// <returns>balance + amount</returns>
        {
            if (amount < 0)
            {
                return false;
            }
            balance = amount + balance;
            return true;
        }

        public bool WithdrawFunds(decimal amount)
        /// <summary>
        /// Purpose: To withdraw money from account balance
        /// </summary>
        /// <param amount>any valid decimal value thats not more than whats in the account</param>
        /// <returns>balance - amount</returns>
        {
            if (balance - amount < 0)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }

        public bool SetBalance(decimal inBalance)
        /// <summary>
        /// Purpose: To set the account balance
        /// </summary>
        /// <param inBalance="balance">any valid double value >= 0</param>
        /// <returns>boolean</returns>
        {
            if (inBalance < 0) { return false; }
            balance = inBalance;
            return true;
        }

        public decimal GetBalance()
        /// <summary>
        /// Purpose: To return the account balance
        /// </summary>
        /// <returns>balance</returns>
        {
            return balance;
        }

        public void SetState(AccountState state)
        /// <summary>
        /// Purpose: To return the accounts state
        /// </summary>
        /// <param AccountState="state">any enum declared in AccountState</param>
        {
            this.state = state;
        }
    }
    /////////////////////////////////////////////////////////////////////////
    public class CheckingAccount : Account
    ///<summary>
    /// This class models checking account whose parent is account/// </summary>
    {
        public decimal _accountServiceFee = 5m;
        public CheckingAccount()
        {
        }
        public string AccountNumber()
        /// <summary>
        /// Purpose: set the account number depending on this account type
        {

            incAccNum = incAccNum + 1;
            accountNumber = incAccNum.ToString() + "C";
            return accountNumber;
        }
        public decimal accountServiceFee
        /// <summary>
        /// Purpose: get and set the account service fee depending on this account type
        /// Returns: the service fee amount.
        {
            get
            {
                return _accountServiceFee;
            }
            set
            {
                _accountServiceFee = value;
            }
        }
        public bool CheckSetBalance(decimal inBalance)
        /// <summary>
        /// Purpose: checks the initial balance to make sure there is enout put in
        /// parameters: initial deposit amount
        /// Returns: true or false

        {
            if (inBalance < 100)
            {
                Console.WriteLine("Starting Balance must be at least $100, please try again.");
                return false;
            }
            balance = inBalance;
            return true;
        }
    }
    public class SavingAccount : Account
    ///<summary>
    /// This class models a savings account whose parent is the account class/// </summary>
    {
        public decimal _accountServiceFee;
        const decimal interest = 1.01m;

        public decimal getInterest()
        {
            return interest;
        }
        public string AccountNumber()
        /// <summary>
        /// Purpose: set the account number depending on this account type
        {
            incAccNum = incAccNum + 1;
            accountNumber = incAccNum.ToString() + "S";
            return accountNumber;
        }
        public decimal accountServiceFee
        /// <summary>
        /// Purpose: get and set the account service fee depending on this account type
        /// Returns: the service fee amount.
        {
            get
            {
                return _accountServiceFee;
            }
            set
            {
                _accountServiceFee = value;
            }
        }
        public bool SaveSetBalance(decimal inBalance)
        /// <summary>
        /// Purpose: checks the initial balance to make sure there is enout put in
        /// parameters: initial deposit amount
        /// Returns: true or false

        {
            if (inBalance < 500)
            {
                Console.WriteLine("Starting Balance must be at least $500, please try again.");
                return false;
            }
            balance = inBalance;
            return true;
        }
    }
    public class CDAccount : Account
    ///<summary>
    /// This class models a CD account whose parent is the account class/// </summary>
    {
        public decimal _accountServiceFee;

        public string AccountNumber()
        /// <summary>
        /// Purpose: set the account number depending on this account type
        {
            incAccNum = incAccNum + 1;
            accountNumber = incAccNum.ToString() + "D";
            return accountNumber;
        }
        public decimal accountServiceFee
        /// <summary>
        /// Purpose: get and set the account service fee depending on this account type
        /// Returns: the service fee amount.
        {
            get
            {
                return _accountServiceFee;
            }
            set
            {
                _accountServiceFee = value;
            }
        }
        public bool CDSetBalance(decimal inBalance)
        /// <summary>
        /// Purpose: checks the initial balance to make sure there is enout put in
        /// parameters: initial deposit amount
        /// Returns: true or false
        {
            if (inBalance < 500)
            {
                Console.WriteLine("Starting Balance must be at least $500, please try again.\n");
                return false;
            }
            balance = inBalance;
            return true;
        }
    }

}
