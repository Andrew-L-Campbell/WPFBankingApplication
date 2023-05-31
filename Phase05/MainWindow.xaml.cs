using BankingApp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Phase05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccountManager Manager = new AccountManager();//creating an account manager
        string inName;
        string inAddress;
        int inType;
        decimal inStartingAmount;
        string searchAccountNumber;
        decimal withdrawAmount;
        decimal decValue;
        decimal depositAmount;
        public MainWindow()
        {
            InitializeComponent();


            AccountManager Manager = new AccountManager();//creating an account manager
            string inValue;
            string inName;
            string inAddress;
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {

            hideAll(sender, e);
            txtBoxName.IsEnabled = true;
            txtBoxName.Visibility = Visibility.Visible;
            txtBoxAddress.Text = default;
            lblName.IsEnabled = true;
            lblName.Visibility = Visibility.Visible;
            txtBoxAddress.IsEnabled = true;
            txtBoxAddress.Visibility = Visibility.Visible;
            txtBoxName.Text = default;
            lblAddress.IsEnabled = true;
            lblAddress.Visibility = Visibility.Visible;
            lblType.IsEnabled = true;
            lblType.Visibility = Visibility.Visible;
            dropBoxType.IsEnabled = true;
            dropBoxType.Visibility = Visibility.Visible;
            dropBoxType.Text = default;
            txtBoxHowMuch.IsEnabled = true;
            txtBoxHowMuch.Visibility = Visibility.Visible;
            txtBoxHowMuch.Text = default;
            lblAmount.IsEnabled = true;
            lblAmount.Visibility = Visibility.Visible;
            btnBack.IsEnabled = true;
            btnBack.Visibility = Visibility.Visible;
            btnCreateAccount.IsEnabled = true;
            btnCreateAccount.Visibility = Visibility.Visible;

        }

        private void txtBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txtBoxName.Text = "";
            inName = txtBoxName.Text.ToString();
        }

        private void txtBoxAddress1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txtBoxAddress.Text = "";
            inAddress = txtBoxAddress.Text.ToString();
        }

        private void dropBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int temp = dropBoxType.SelectedIndex;
            inType = temp;
        }

        private void txtBoxHowMuch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txtBoxHowMuch.Text = "";
            if (decimal.TryParse(txtBoxHowMuch.Text, out decimal value)){
                inStartingAmount = value;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            hideAll(sender, e);
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            if(inType == 0)//checking
            {
                CheckingAccount account = new CheckingAccount();
                account.CheckSetBalance(inStartingAmount);
                account.accountServiceFee = 5;
                account.SetName(inName);
                account.SetAddress(inAddress);
                Manager.StoreAccount(account.AccountNumber(), account);
                Console.WriteLine("added checking");
            }
            if (inType == 1)//"Saving Account"
            {
                SavingAccount account = new SavingAccount();
                account.SaveSetBalance(inStartingAmount);
                account.accountServiceFee = 0;
                account.SetName(inName);
                account.SetAddress(inAddress);
                Manager.StoreAccount(account.AccountNumber(), account);
                Console.WriteLine("added savings");
            }
            if (inType == 2)//"CD Account"
            {
                CDAccount account = new CDAccount();
                account.CDSetBalance(inStartingAmount);
                account.accountServiceFee = 8;
                account.SetName(inName);
                account.SetAddress(inAddress);
                Manager.StoreAccount(account.AccountNumber(), account);
                Console.WriteLine("added cd");
            }
            hideAll(sender, e);
            updateListBox(sender, e);


        }
        private void hideAll(object sender, RoutedEventArgs e)
        {
            txtBoxName.IsEnabled = false;
            txtBoxName.Visibility = Visibility.Hidden;
            lblName.IsEnabled = false;
            lblName.Visibility = Visibility.Hidden;
            txtBoxAddress.IsEnabled = false;
            txtBoxAddress.Visibility = Visibility.Hidden;
            lblAddress.IsEnabled = false;
            lblAddress.Visibility = Visibility.Hidden;
            lblType.IsEnabled = false;
            lblType.Visibility = Visibility.Hidden;
            dropBoxType.IsEnabled = false;
            dropBoxType.Visibility = Visibility.Hidden;
            txtBoxHowMuch.IsEnabled = false;
            txtBoxHowMuch.Visibility = Visibility.Hidden;
            lblAmount.IsEnabled = false;
            lblAmount.Visibility = Visibility.Hidden;
            btnBack.IsEnabled = false;
            btnBack.Visibility = Visibility.Hidden;
            btnCreateAccount.IsEnabled = false;
            btnCreateAccount.Visibility = Visibility.Hidden;
            lblEnterAccNumber.IsEnabled = false;
            lblEnterAccNumber.Visibility = Visibility.Hidden;
            txtBoxEnterAccNumber.Visibility = Visibility.Hidden;
            txtBoxEnterAccNumber.IsEnabled = false;
            btnFindAccount.IsEnabled = false;
            btnFindAccount.Visibility = Visibility.Hidden;

            btnDeposit.IsEnabled = false;
            btnDeposit.Visibility = Visibility.Hidden;
            btnWithdraw.IsEnabled = false;
            btnWithdraw.Visibility = Visibility.Hidden;
            btnSwitch.Visibility = Visibility.Hidden;
            btnSwitch.IsEnabled = false;
            lblWhatOptions.Visibility = Visibility.Hidden;
            lblWhatOptions.IsEnabled = false;
            btnBack.IsEnabled = false;
            btnBack.Visibility = Visibility.Hidden;
            lblDepositAmount.Visibility = Visibility.Hidden;
            lblDepositAmount.IsEnabled = false;
            txtBoxDepositAmount.Visibility = Visibility.Hidden;
            txtBoxDepositAmount.IsEnabled = false;
            btnDepositConfirm.Visibility = Visibility.Hidden;
            btnDepositConfirm.IsEnabled = false;

            lblWhatOptions.IsEnabled = true;
            lblWhatOptions.Visibility = Visibility.Visible;
            btnDeposit.IsEnabled = true;
            btnDeposit.Visibility = Visibility.Visible;
            btnWithdraw.IsEnabled = true;
            btnWithdraw.Visibility = Visibility.Visible;
            btnDeposit.Visibility = Visibility.Visible;
            btnWithdraw.IsEnabled = true;
            btnSwitch.IsEnabled = true;
            btnSwitch.Visibility = Visibility.Visible;

            lblWhatOptions.IsEnabled = false;
            lblWhatOptions.Visibility = Visibility.Hidden;
            btnDeposit.IsEnabled = false;
            btnDeposit.Visibility = Visibility.Hidden;
            btnWithdraw.IsEnabled = false;
            btnWithdraw.Visibility = Visibility.Hidden;
            btnDeposit.Visibility = Visibility.Hidden;
            btnWithdraw.IsEnabled = false;
            btnSwitch.IsEnabled = false;
            btnSwitch.Visibility = Visibility.Hidden;
            
            lblBalance.Visibility = Visibility.Hidden;
            lblBalance.IsEnabled= false;
            txtBoxBalance.Visibility = Visibility.Hidden;
            txtBoxBalance.IsEnabled=false;
            lblWithdrawAmount.Visibility = Visibility.Hidden;
            lblWithdrawAmount.IsEnabled=false;
            txtBoxWithdrawAmount.Visibility=Visibility.Hidden;
            txtBoxWithdrawAmount.IsEnabled=false;
            btnWithdrawConfirm.Visibility = Visibility.Hidden;
            btnWithdrawConfirm.IsEnabled= false;

        }

        private void updateListBox(object sender, RoutedEventArgs e)
        {
            lstBoxDisplay.Items.Clear();
            lstBoxDisplay.Items.Add(Manager.ToString());
        }

        private void btnSearchAccount_Click(object sender, RoutedEventArgs e)
        {
            hideAll(sender, e);
            btnBack.IsEnabled = true;
            btnBack.Visibility = Visibility.Visible;
            lblEnterAccNumber.Visibility = Visibility.Visible;
            lblEnterAccNumber.IsEnabled= true;
            txtBoxEnterAccNumber.Visibility = Visibility.Visible;
            txtBoxEnterAccNumber.IsEnabled= true;
            btnFindAccount.IsEnabled = true;
            btnFindAccount.Visibility = Visibility.Visible;

        }

        private void btnFindAccount_Click(object sender, RoutedEventArgs e)
        {

            searchAccountNumber = txtBoxEnterAccNumber.Text.ToString().ToUpper();
            Account currentSelectedAccount = Manager.FindAccount(searchAccountNumber);
            if (currentSelectedAccount != null)
            {
                hideAll(sender, e);
                lblSelAccNum.Visibility = Visibility.Visible;
                lblSelAccNum.IsEnabled= true;
                txtBoxSelAccNum.Visibility = Visibility.Visible;
                txtBoxSelAccNum.IsEnabled= true;
                txtBoxSelAccNum.Text = currentSelectedAccount.accountNumber.ToString();
                txtBoxBalance.Text = currentSelectedAccount.balance.ToString();
                hideAll(sender, e);
                lblBalance.Visibility = Visibility.Visible;
                lblBalance.IsEnabled= true;
                txtBoxBalance.Visibility = Visibility.Visible;
                txtBoxBalance.IsEnabled= true;
                btnDeposit.IsEnabled = true;
                btnDeposit.Visibility = Visibility.Visible;
                btnWithdraw.IsEnabled = true;
                btnWithdraw.Visibility = Visibility.Visible;
                btnSwitch.Visibility = Visibility.Visible;
                btnSwitch.IsEnabled = true;
                lblWhatOptions.Visibility = Visibility.Visible;
                lblWhatOptions.IsEnabled= true;


            }
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            hideAll(sender, e);
            lblWithdrawAmount.Visibility = Visibility.Visible;
            lblWithdrawAmount.IsEnabled= true;
            txtBoxWithdrawAmount.Visibility = Visibility.Visible;
            txtBoxWithdrawAmount.IsEnabled= true;
            btnWithdrawConfirm.Visibility = Visibility.Visible;
            btnWithdrawConfirm.IsEnabled= true;
            btnBack.IsEnabled = true;
            btnBack.Visibility = Visibility.Visible;
            lblBalance.Visibility = Visibility.Visible;
            lblBalance.IsEnabled= true;
            txtBoxBalance.Visibility = Visibility.Visible;
            txtBoxBalance.IsEnabled= true;
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            hideAll(sender, e);
            lblDepositAmount.Visibility = Visibility.Visible;
            lblDepositAmount.IsEnabled = true;
            txtBoxDepositAmount.Visibility = Visibility.Visible;
            txtBoxDepositAmount.IsEnabled = true;
            btnDepositConfirm.Visibility = Visibility.Visible;
            btnDepositConfirm.IsEnabled = true;
            btnBack.IsEnabled = true;
            btnBack.Visibility = Visibility.Visible;
            lblBalance.Visibility = Visibility.Visible;
            lblBalance.IsEnabled = true;
            txtBoxBalance.Visibility = Visibility.Visible;
            txtBoxBalance.IsEnabled = true;
        }

        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            hideAll(sender, e); 

        }

        private void btnDepositConfirm_Click(object sender, RoutedEventArgs e)
        {
            Account currentSelectedAccount = Manager.FindAccount(searchAccountNumber);
            if (decimal.TryParse( txtBoxDepositAmount.Text, out decimal depositAmount)  && depositAmount > 0)
            {

                currentSelectedAccount.PayInFunds(depositAmount);//withdrawing money from balance in account
                txtBoxBalance.Text = currentSelectedAccount.balance.ToString();
            }
        }

        private void btnWithdrawConfirm_Click(object sender, RoutedEventArgs e)
        {
            Account currentSelectedAccount = Manager.FindAccount(searchAccountNumber);
            if (decimal.TryParse(txtBoxWithdrawAmount.Text, out decimal withdrawAmount) && (currentSelectedAccount.balance - withdrawAmount >= 0) && withdrawAmount > 0)
            {

                currentSelectedAccount.WithdrawFunds(withdrawAmount);//withdrawing money from balance in account
                txtBoxBalance.Text=currentSelectedAccount.balance.ToString();
            }
        }
    }
}
