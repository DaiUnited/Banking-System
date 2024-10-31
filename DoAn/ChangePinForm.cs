using DoAn.BusinessLogicLayer;
using DoAn.Entities;
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
    public partial class ChangePinForm : Form
    {
        private BankCardService service;
        private BankCard bankCard;

        public ChangePinForm(BankCard bankCard)
        {
            InitializeComponent();
            service = new BankCardService();
            this.bankCard = bankCard;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentPin = txtMaPinCu.Text;
            string newPin = txtMaPinMoi.Text;
            string confirmNewPin = txtXacNhanMaPin.Text;

            // Lấy thông tin thẻ từ cơ sở dữ liệu để kiểm tra mã PIN cũ
            var currentBankCard = service.Login(bankCard.SoThe, currentPin);

            // Kiểm tra mã PIN cũ có đúng không
            if (currentBankCard == null)
            {
                MessageBox.Show("Mã PIN cũ không chính xác.");
                return;
            }

            // Kiểm tra mã PIN mới và xác nhận mã PIN có khớp không
            if (newPin != confirmNewPin)
            {
                MessageBox.Show("Mã PIN mới và xác nhận mã PIN không khớp.");
                return;
            }

            // Thay đổi mã PIN
            service.ChangePin(bankCard.SoThe, newPin);
            MessageBox.Show("Thay đổi mã PIN thành công!");
            this.Close();
        }
    }
}
