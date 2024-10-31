using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnQuanLyThe_Click(object sender, EventArgs e)
        {
            BankCardForm bankCardForm = new BankCardForm();
            bankCardForm.Show();
        }

        //private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        //{
        //    UserAccountForm userManagementForm = new UserAccountForm();
        //    userManagementForm.Show();
        //}

        private void btnQuanLyLichSuGiaoDich_Click(object sender, EventArgs e)
        {
            TransactionForm transactionHistoryForm = new TransactionForm();
            transactionHistoryForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}

