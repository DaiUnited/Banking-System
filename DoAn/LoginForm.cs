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
using DoAn.BusinessLogicLayer;

namespace DoAn
{
    public partial class LoginForm : Form
    {
        private BankCardService service;
        private int soLanNhapSai = 0; // Biến đếm số lần nhập sai
        private const int MAX_LAN_NHAP_SAI = 3; // Số lần nhập sai tối đa
        private Timer timer; // Timer để làm mới sau một khoảng thời gian
        private const int KHOA_THOI_GIAN = 10000;

        public LoginForm()
        {
            InitializeComponent();
            service = new BankCardService();
            txtMaPin.PasswordChar = '*';

            timer = new Timer();
            timer.Interval = KHOA_THOI_GIAN; // Thời gian chờ để mở khóa
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Reset số lần nhập sai và mở khóa
            soLanNhapSai = 0;
            timer.Stop(); // Dừng timer khi đã reset
            MessageBox.Show("Bạn có thể thử lại.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string soThe = txtSoThe.Text;
            string maPin = txtMaPin.Text;

            // Kiểm tra nếu số lần nhập sai vượt quá 3 lần
            if (soLanNhapSai >= MAX_LAN_NHAP_SAI)
            {
                MessageBox.Show("Tài khoản của bạn đã bị tạm khóa do nhập sai quá 3 lần. Vui lòng thử lại sau.");
                return;
            }

            if (soThe == "1111" && maPin == "Admin123")
            {
                MainForm mainForm = new MainForm(); // Hiển thị form quản lý Admin
                mainForm.Show();
                this.Hide();
            }
            else
            {
                var bankCard = service.Login(soThe, maPin);
                if (bankCard != null)
                {
                    KhachHangForm khachHangForm = new KhachHangForm(bankCard);
                    khachHangForm.Show();
                    this.Hide();
                }
                else
                {
                    // Tăng số lần nhập sai
                    soLanNhapSai++;
                    if (soLanNhapSai >= MAX_LAN_NHAP_SAI)
                    {
                        MessageBox.Show("Bạn đã nhập sai quá 3 lần. Tài khoản của bạn đã bị tạm khóa.");
                        timer.Start();
                    }
                    else
                    {
                        MessageBox.Show($"Đăng nhập thất bại. Bạn còn {MAX_LAN_NHAP_SAI - soLanNhapSai} lần thử.");
                    }
                }
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                
                txtMaPin.PasswordChar = '\0';
            }
            else
            {
                txtMaPin.PasswordChar = '*';
            }
        }
    }
}
