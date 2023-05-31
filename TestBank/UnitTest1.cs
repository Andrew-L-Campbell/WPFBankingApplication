using BankingApp4;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TestBank
{
    [TestClass]
    public class UnitTest1
    {
        private static CheckingAccount checkingAccount1;
        private static SavingAccount savingsAccount1;
        private static CDAccount cdAccount1;

        private static CheckingAccount checkingAccountManager1;
        private static SavingAccount savingsAccountManager1;
        private static CDAccount cdAccount1Manager1;

        private static CheckingAccount checkingAccountNullInputs1;
        private static SavingAccount savingsAccountNullInputs1;
        private static CDAccount cdAccountNullInputs1;

        private static AccountManager manager1;

        private static decimal tempDecimal;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            ///Good accounts///
            checkingAccount1 = new CheckingAccount();
            checkingAccount1.AccountNumber();

            savingsAccount1 = new SavingAccount();
            savingsAccount1.AccountNumber();

            cdAccount1 = new CDAccount();
            cdAccount1.AccountNumber();

            manager1 = new AccountManager();

            checkingAccountManager1 = new CheckingAccount();
            checkingAccountManager1.AccountNumber();

            savingsAccountManager1 = new SavingAccount();
            savingsAccountManager1.AccountNumber();

            cdAccount1Manager1 = new CDAccount();
            cdAccount1Manager1.AccountNumber();

            ///error checking accounts
            checkingAccountNullInputs1 = new CheckingAccount();
            checkingAccountNullInputs1.AccountNumber();

            savingsAccountNullInputs1 = new SavingAccount();
            savingsAccountNullInputs1.AccountNumber();

            cdAccountNullInputs1 = new CDAccount();
            cdAccountNullInputs1.AccountNumber();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
        }
        [TestInitialize]
        public void TestSetup()
        {
            checkingAccount1.CheckSetBalance(500m);
            checkingAccount1.SetName("Andrew");
            checkingAccount1.SetAddress("123 One Street");
            checkingAccount1.accountServiceFee = 5;

            savingsAccount1.SetName("Andrew");
            savingsAccount1.SetAddress("123 One Street");
            savingsAccount1.SaveSetBalance(600m);

            cdAccount1.CDSetBalance(600);
            cdAccount1.SetName("Andrew");
            cdAccount1.SetAddress("123 One Street");
            cdAccount1.accountServiceFee = 5;

            checkingAccountManager1.CheckSetBalance(700m);
            checkingAccountManager1.accountServiceFee = 5;
            checkingAccountManager1.SetName("Andrew");
            checkingAccountManager1.SetAddress("744 view");

            savingsAccountManager1.SaveSetBalance(700m);
            savingsAccountManager1.accountServiceFee = 0;
            savingsAccountManager1.SetName("Andrew Campbell");
            savingsAccountManager1.SetAddress("8844 west");

            cdAccount1Manager1.CDSetBalance(700m);
            cdAccount1Manager1.accountServiceFee = 8;
            cdAccount1Manager1.SetName("Lincoln");
            cdAccount1Manager1.SetAddress("548 ddd");

            manager1.StoreAccount(checkingAccountManager1.AccountNumber(), checkingAccountManager1);

        }
        /// <summary>
        /// Checking Account.cs and IAccount.cs
        /// </summary>
        //Correct Checking Account Inputs/////////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestCheckingAccountSetName()
        {
            Assert.AreEqual(checkingAccount1.name,"Andrew");
        }

        [TestMethod]
        public void TestCheckingAccountSetAddress()
        {
            Assert.AreEqual(checkingAccount1.address, "123 One Street");
        }
        [TestMethod]
        public void TestCheckingAccountSetNumber()
        {
            Assert.AreEqual(checkingAccount1.accountNumber, "1001C");

        }
        [TestMethod]
        public void TestCheckingAccountSetBalance()
        {
            Assert.AreEqual(checkingAccount1.balance, 500);
        }
        [TestMethod]
        public void TestCheckingAccountToString()
        {
            Assert.AreEqual(checkingAccount1.ToString(), $"Account Holder's Name: {checkingAccount1.name}\n" +
                $"Address: {checkingAccount1.address}\n" +
                $"Account Number: {checkingAccount1.accountNumber}\n" +
                $"Current Balance: {checkingAccount1.balance}\n" );
        }
        [TestMethod]
        public void TestCheckingAccountPayInFunds()
        {
            checkingAccount1.PayInFunds(100.5m);
            Assert.AreEqual(checkingAccount1.balance, 600.5m);
        }
        [TestMethod]
        public void TestCheckingAccountWithdrawFunds()
        {
            tempDecimal = checkingAccount1.balance;
            checkingAccount1.WithdrawFunds(100m);
            
            Assert.AreEqual(checkingAccount1.balance, tempDecimal - 100m);
        }
        public void TestCheckingAccountSetState()
        {
            checkingAccount1.SetState(AccountState.New);
            Assert.AreEqual(checkingAccount1.state, AccountState.New);
        }
        [TestMethod]
        public void TestCheckingAccountServiceFee()
        {
            Assert.AreEqual(checkingAccount1._accountServiceFee, 5m);
        }
        //Incorrect Checking Account Inputs/////////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestCheckingAccountSetNameWrong()
        {
            Assert.AreEqual(checkingAccountNullInputs1.SetName(""), false);
        }
        [TestMethod]
        public void TestCheckingAccountSetAddressWrong()
        {
            Assert.AreEqual(checkingAccountNullInputs1.SetAddress(""), false);
        }
        [TestMethod]
        public void TestCheckingAccountSetBalanceWrong1()
        {
            Assert.AreEqual(checkingAccountNullInputs1.CheckSetBalance(-50), false);
        }
        [TestMethod]
        public void TestCheckingAccountSetBalanceWrong2()
        {
            Assert.AreEqual(checkingAccountNullInputs1.CheckSetBalance(50), false);
        }
        [TestMethod]
        public void TestCheckingAccountPayInFundsWrong()
        {
            checkingAccount1.PayInFunds(100.5m);
            Assert.AreEqual(checkingAccountNullInputs1.PayInFunds(-50),false);
        }
        [TestMethod]
        public void TestCheckingAccountWithdrawFundsWrong()
        {
            checkingAccountNullInputs1.CheckSetBalance(100);
            Assert.AreEqual(checkingAccountNullInputs1.WithdrawFunds(105m),false);
        }

        //savings account///////////////////////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestSavingsAccountSetName()
        {
            Assert.AreEqual(savingsAccount1.name, "Andrew");
        }

        [TestMethod]
        public void TestSavingsAccountSetAddress()
        {
            Assert.AreEqual(savingsAccount1.address, "123 One Street");
        }
        [TestMethod]
        public void TestSavingsAccountSetNumber()
        {
            Assert.AreEqual(savingsAccount1.accountNumber, "1002S");
        }
        [TestMethod]
        public void TestSavingsAccountSetBalance()
        {
            Assert.AreEqual(savingsAccount1.balance, 600);
        }
        [TestMethod]
        public void TestSavingsAccountToString()
        {
            Assert.AreEqual(savingsAccount1.ToString(), $"Account Holder's Name: {savingsAccount1.name}\n" +
                $"Address: {savingsAccount1.address}\n" +
                $"Account Number: {savingsAccount1.accountNumber}\n" +
                $"Current Balance: {savingsAccount1.balance}\n");
        }
        [TestMethod]
        public void TestSavingsAccountPayInFunds()
        {
            savingsAccount1.PayInFunds(100.5m);
            Assert.AreEqual(savingsAccount1.balance, 700.5m);
        }
        [TestMethod]
        public void TestSavingsAccountWithdrawFunds()
        {
            tempDecimal = savingsAccount1.balance;
            savingsAccount1.WithdrawFunds(100m);

            Assert.AreEqual(savingsAccount1.balance, tempDecimal - 100m);
        }
        public void TestSavingsAccountSetState()
        {
            checkingAccount1.SetState(AccountState.New);
            Assert.AreEqual(savingsAccount1.state, AccountState.New);
        }
        [TestMethod]
        public void TestSavingsInterestRate()
        {
            Assert.AreEqual(savingsAccount1.getInterest(),1.01m);
        }
        //Incorrect Savings Account Inputs/////////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestSavingAccountSetNameWrong()
        {
            Assert.AreEqual(savingsAccountNullInputs1.SetName(""), false);
        }
        [TestMethod]
        public void TestSavingAccountSetAddressWrong()
        {
            Assert.AreEqual(savingsAccountNullInputs1.SetAddress(""), false);
        }
        [TestMethod]
        public void TestSavingAccountSetBalanceWrong1()
        {
            Assert.AreEqual(savingsAccountNullInputs1.SaveSetBalance(-50), false);
        }
        [TestMethod]
        public void TestSavingAccountSetBalanceWrong2()
        {
            Assert.AreEqual(savingsAccountNullInputs1.SaveSetBalance(50), false);
        }
        [TestMethod]
        public void TestSavingAccountPayInFundsWrong()
        {
            checkingAccount1.PayInFunds(100.5m);
            Assert.AreEqual(savingsAccountNullInputs1.PayInFunds(-50), false);
        }
        [TestMethod]
        public void TestSavingAccountWithdrawFundsWrong()
        {
            savingsAccountNullInputs1.SaveSetBalance(500);
            Assert.AreEqual(savingsAccountNullInputs1.WithdrawFunds(505m), false);
        }

        //CDAccount///////////////////////////////////////////////////////
        [TestMethod]
        public void TestCDAccountSetName()
        {
            Assert.AreEqual(cdAccount1.name, "Andrew");
        }

        [TestMethod]
        public void TestCDAccountSetAddress()
        {
            Assert.AreEqual(cdAccount1.address, "123 One Street");
        }
        [TestMethod]
        public void TestCDAccountSetNumber()
        {
            Assert.AreEqual(cdAccount1.accountNumber, "1003D");
        }
        [TestMethod]
        public void TestCDAccountSetBalance()
        {
            Assert.AreEqual(cdAccount1.GetBalance(), 600);
        }
        [TestMethod]
        public void TestCDAccountToString()
        {
            Assert.AreEqual(cdAccount1.ToString(), $"Account Holder's Name: {cdAccount1.name}\n" +
                $"Address: {cdAccount1.address}\n" +
                $"Account Number: {cdAccount1.accountNumber}\n" +
                $"Current Balance: {cdAccount1.balance}\n");
        }

        [TestMethod]
        public void TestCDAccountWithdrawFunds()
        {
            tempDecimal = cdAccount1.balance;
            cdAccount1.WithdrawFunds(100m);

            Assert.AreEqual(cdAccount1.balance, tempDecimal - 100m);
        }
        public void TestCDAccountSetState()
        {
            cdAccount1.SetState(AccountState.New);
            Assert.AreEqual(cdAccount1.state, AccountState.New);
        }
        [TestMethod]
        public void TestCDAccountServiceFee()
        {
            Assert.AreEqual(cdAccount1._accountServiceFee, 5m);
        }
        //Incorrect CDAccount Inputs/////////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestCDAccountAccountSetNameWrong()
        {
            Assert.AreEqual(cdAccountNullInputs1.SetName(""), false);
        }
        [TestMethod]
        public void TestCDAccountAccountSetAddressWrong()
        {
            Assert.AreEqual(cdAccountNullInputs1.SetAddress(""), false);
        }
        [TestMethod]
        public void TestCDAccountAccountSetBalanceWrong1()
        {
            Assert.AreEqual(cdAccountNullInputs1.CDSetBalance(-50), false);
        }
        [TestMethod]
        public void TestCDAccountAccountSetBalanceWrong2()
        {
            Assert.AreEqual(cdAccountNullInputs1.CDSetBalance(50), false);
        }
        [TestMethod]
        public void TestCDAccountAccountPayInFundsWrong()
        {
            cdAccountNullInputs1.PayInFunds(100.5m);
            Assert.AreEqual(cdAccountNullInputs1.PayInFunds(-50), false);
        }
        [TestMethod]
        public void TestCDAccountAccountWithdrawFundsWrong()
        {
            cdAccountNullInputs1.CDSetBalance(500);
            Assert.AreEqual(cdAccountNullInputs1.WithdrawFunds(505m), false);
        }
        /// <summary>
        /// Checking AccountManager.cs
        /// </summary>
        
        //AccountManager//////////////////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestStoreAccount()
        {
            Assert.AreEqual(manager1.StoreAccount(checkingAccountManager1.AccountNumber(), checkingAccountManager1), true);
            Assert.AreEqual(manager1.StoreAccount(savingsAccountManager1.AccountNumber(), savingsAccountManager1), true);
            Assert.AreEqual(manager1.StoreAccount(cdAccount1Manager1.AccountNumber(), cdAccount1Manager1), true);
        }
        [TestMethod]
        public void TestFindAccount()
        {
            Account currentSelectedAccount = manager1.FindAccount("1037C");
            Assert.AreEqual(currentSelectedAccount.accountNumber, "1037C");


        }
        [TestMethod]
        public void TestToString()
        {
            Assert.AreEqual(checkingAccountManager1.ToString(),
            $"Account Holder's Name: {checkingAccountManager1.GetName()}\n" +
            $"Address: {checkingAccountManager1.address}\n" +
            $"Account Number: {checkingAccountManager1.accountNumber}\n" +
            $"Current Balance: {checkingAccountManager1.balance}\n");
        }

        //Account Manager wrong inputs //////////////////////////////////////////////////////////////
        [TestMethod]
        public void TestFindAccountWrongAccountNumber()
        {

            Assert.AreEqual(manager1.FindAccount("9999C"), null);


        }

    }
}