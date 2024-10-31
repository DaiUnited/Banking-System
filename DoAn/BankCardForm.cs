using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.BusinessLogicLayer;
using DoAn.Entities;

namespace DoAn
{
    public partial class BankCardForm : Form
    {
        private BankCardService service;

        public BankCardForm()
        {
            InitializeComponent();
            service = new BankCardService();
            LoadData(); // Tải dữ liệu khi form khởi chạy
        }

        // Phương thức để tải dữ liệu từ DB lên DataGridView
        private void LoadData()
        {
            var allCards = service.GetAllBankCards();
            dataGridView1.DataSource = allCards;
        }

        // Thêm thẻ mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            var bankCard = new BankCard
            {
                SoThe = txtSoThe.Text,
                TenChuThe = txtTenChuThe.Text,
                NgayHetHan = txtNgayHetHan.Text,
                SoDu = decimal.Parse(txtSoDu.Text)
            };
            service.AddBankCard(bankCard);
            LoadData(); // Refresh dữ liệu sau khi thêm
            MessageBox.Show("Thêm thẻ thành công!");
        }

        // Sửa thẻ hiện tại
        private void btnSua_Click(object sender, EventArgs e)
        {
            var bankCard = new BankCard
            {
                SoThe = txtSoThe.Text,
                TenChuThe = txtTenChuThe.Text,
                NgayHetHan = txtNgayHetHan.Text,
                SoDu = decimal.Parse(txtSoDu.Text)
            };

            service.UpdateBankCard(bankCard);
            LoadData(); // Refresh dữ liệu sau khi sửa
            MessageBox.Show("Cập nhật thẻ thành công!");
        }

        // Xóa thẻ
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string soThe = txtSoThe.Text;
            service.DeleteBankCard(soThe);
            LoadData(); // Refresh dữ liệu sau khi xóa
            MessageBox.Show("Xóa thẻ thành công!");
        }

        // Nạp lại dữ liệu
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Xử lý sự kiện chọn một hàng trong DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtSoThe.Text = row.Cells["SoThe"].Value.ToString();
                txtTenChuThe.Text = row.Cells["TenChuThe"].Value.ToString();
                txtNgayHetHan.Text = row.Cells["NgayHetHan"].Value.ToString();
                txtSoDu.Text = row.Cells["SoDu"].Value.ToString();
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtSoThe.Text = row.Cells["SoThe"].Value.ToString();
                txtTenChuThe.Text = row.Cells["TenChuThe"].Value.ToString();
                txtNgayHetHan.Text = row.Cells["NgayHetHan"].Value.ToString();
                txtSoDu.Text = row.Cells["SoDu"].Value.ToString();
            }
        }
    }
}

