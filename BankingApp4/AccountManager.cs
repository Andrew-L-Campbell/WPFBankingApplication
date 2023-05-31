using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp4
{
    public class AccountManager
    ///<summary>
    /// This class models a account manager. Its used to store the accounts/// </summary>
    {
        Dictionary<string, Account> accounts = new Dictionary<string, Account>();


        public  bool StoreAccount(string accountNumber, Account inAccount)
        {
            accounts[accountNumber] = inAccount;
            return true;
        }
        public Account FindAccount(string inAccountNumber)
        /// <summary>
        /// Purpose: searches for a account and returns it if found
        /// parameters: a account number
        /// Returns: the account thats found
        {
            foreach (var account in accounts)
            {
                if (account.Key == inAccountNumber)
                {
                    return account.Value;
                }
            }
            return null;

        }

        public override string ToString()
        /// <summary>
        /// Purpose: to print out the array of accounts and their info
        /// Returns: a string of detailed account info
        {
            string tempReturn = "";
            foreach (var account in accounts)
            {
                tempReturn = tempReturn + "Name: " + account.Value.name + "\n" +
                    "Address: " + account.Value.address + "\n" +
                    "Account Number: " + account.Key + "\n" +
                    "Balance: " + account.Value.balance + "\n\n";

            }
            return tempReturn;

        }

    }
}
