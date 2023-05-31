using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp4
{
    public interface IAccount
    /// <summary>
    /// This interface contains the basis methods of what an account needs to have. 
    /// </summary>
    {
        public bool SetName(string inName);
        /// <summary>
        /// Purpose: To set the name of account holder
        /// </summary>
        /// <param name="inName">
        public string GetName();
        /// <summary>
        /// Purpose: To get the name of account holder
        /// </summary>
        public bool SetAddress(string inAddress);
        /// <summary>
        /// Purpose: To set the address of account holder
        /// </summary>
        /// <param address="inAddress">
        public string GetAddress();
        /// <summary>
        /// Purpose: To get the address of account holder
        /// </summary>
        public bool PayInFunds(decimal amount);
        /// <summary>
        /// Purpose: To deposit funds into account
        /// </summary>
        /// <param balance="amount">
        public bool WithdrawFunds(decimal amount);
        /// <summary>
        /// Purpose: To withdraw money from account
        /// </summary>
        /// <param balance="amount">
        public bool SetBalance(decimal inBalance);
        /// <summary>
        /// Purpose: To set the balance of account holder
        /// </summary>
        /// <param balance ="inBalance">
        public decimal GetBalance();
        /// <summary>
        /// Purpose: To get the balance of the account
        /// </summary>
        public void SetState(AccountState state);
        /// <summary>
        /// Purpose: To set the state of the account
        /// </summary>
        /// <param this.state="state">
    }
}