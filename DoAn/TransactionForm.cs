using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cassandra;
using DoAn.Entities;
using DoAn.BusinessLogicLayer;


namespace DoAn
{
    public partial class TransactionForm : Form
    {
        private TransactionService service;

        public TransactionForm()
        {
            InitializeComponent();
            service = new TransactionService();
        }

        // Sự kiện khi nhấn nút "Tra cứu lịch sử giao dịch"
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            string soThe = txtSoThe.Text;
            if (!string.IsNullOrEmpty(soThe))
            {
                // Lấy danh sách giao dịch từ TransactionService
                List<Transaction> transactions = service.GetTransactionsByCardNumber(soThe);
                if (transactions.Count > 0)
                {
                    dataGridView1.DataSource = transactions;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lịch sử giao dịch cho số thẻ này.");
                    dataGridView1.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số thẻ.");
            }
        }
    }
}
