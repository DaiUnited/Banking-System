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
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DoAn
{
    public partial class KhachHangForm : Form
    {
        private BankCard bankCard;
        private BankCardService service;

        public KhachHangForm(BankCard bankCard)
        {
            InitializeComponent();
            this.bankCard = bankCard;
            service = new BankCardService();
            LoadData();
        }

        // Phương thức để load lại thông tin
        public void LoadData()
        {
            lblTenChuThe.Text = $"Xin chào: {bankCard.TenChuThe}";
            lblSoDu.Text = $"Số dư: {bankCard.SoDu} VND";
        }

        // Phương thức để refresh dữ liệu sau khi giao dịch
        public void RefreshData()
        {
            bankCard = service.Login(bankCard.SoThe); // Load lại dữ liệu mới từ DB
            LoadData(); // Cập nhật lại UI với dữ liệu mới
        }

        private void btnNapTien_Click(object sender, EventArgs e)
        {
            NapTien napTienForm = new NapTien(bankCard, this);
            napTienForm.Show();
        }

        private void btnRutTien_Click(object sender, EventArgs e)
        {
            RutTien rutTienForm = new RutTien(bankCard, this);
            rutTienForm.Show();
        }

        private void btnChuyenTien_Click(object sender, EventArgs e)
        {
            ChuyenTien chuyenTienForm = new ChuyenTien(bankCard, this);
            chuyenTienForm.Show();
        }

        private void btnThayDoiMaPin_Click(object sender, EventArgs e)
        {
            ChangePinForm changePinForm = new ChangePinForm(bankCard); // Truyền thông tin thẻ hiện tại
            changePinForm.Show();
        }

        private void btnTruyVanSoDu_Click(object sender, EventArgs e)
        {
            // Gọi hàm truy vấn số dư
            decimal soDuHienTai = service.TruyVanSoDu(bankCard.SoThe);

            // Hiển thị số dư
            MessageBox.Show($"Số dư hiện tại: {soDuHienTai} VND", "Truy vấn số dư", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Hỏi người dùng có muốn in hóa đơn không
            DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn truy vấn số dư không?", "In Hóa Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InHoaDon("Truy Vấn Số Dư", soDuHienTai);
            }
        }

        private void InHoaDon(string loaiGiaoDich, decimal soTien)
        {
            // Đường dẫn lưu file PDF vào thư mục HoaDon
            string folderPath = @"C:\Users\daiun\Downloads\Compressed\Demo\Demo\HoaDon";

            // Kiểm tra nếu thư mục chưa tồn tại thì tạo nó
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }

            // Tạo đường dẫn cho file PDF
            string filePath = System.IO.Path.Combine(folderPath, $"HoaDon_{DateTime.Now.Ticks}.pdf");

            // Tạo đối tượng PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Hóa đơn giao dịch";

            // Tạo một trang mới
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Đặt font cho văn bản
            XFont fontTitle = new XFont("Verdana", 20);
            XFont fontText = new XFont("Verdana", 12);
            XFont fontBold = new XFont("Verdana", 12);
            XFont fontItalic = new XFont("Verdana", 10);

            // Vẽ logo giả định (ở đây ta chỉ vẽ một hình chữ nhật, bạn có thể thay thế bằng hình ảnh logo thật)
            gfx.DrawRectangle(XBrushes.LightGray, new XRect(50, 20, 100, 50)); // Khu vực logo
            gfx.DrawString("NHOM7 BANK", fontText, XBrushes.Black, new XRect(50, 30, 100, 50), XStringFormats.Center);

            // Vẽ tiêu đề hóa đơn
            gfx.DrawString("HÓA ĐƠN GIAO DỊCH", fontTitle, XBrushes.Black, new XRect(0, 100, page.Width, 50), XStringFormats.Center);

            // Đường kẻ ngang
            gfx.DrawLine(XPens.Black, 50, 150, page.Width - 50, 150);

            // Vẽ thông tin giao dịch
            gfx.DrawString("Thông tin khách hàng:", fontBold, XBrushes.Black, new XRect(50, 180, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Tên Chủ Thẻ: {bankCard.TenChuThe}", fontText, XBrushes.Black, new XRect(50, 210, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Số Thẻ: {bankCard.SoThe}", fontText, XBrushes.Black, new XRect(50, 240, page.Width, page.Height), XStringFormats.TopLeft);

            gfx.DrawLine(XPens.Black, 50, 270, page.Width - 50, 270);

            gfx.DrawString("Chi tiết giao dịch:", fontBold, XBrushes.Black, new XRect(50, 300, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Loại Giao Dịch: Truy vấn số dư", fontText, XBrushes.Black, new XRect(50, 330, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Số Tiền: {soTien} VND", fontText, XBrushes.Black, new XRect(50, 360, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString($"Ngày Giao Dịch: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}", fontText, XBrushes.Black, new XRect(50, 390, page.Width, page.Height), XStringFormats.TopLeft);

            // Đường kẻ ngang
            gfx.DrawLine(XPens.Black, 50, 420, page.Width - 50, 420);

            // Vẽ lời cảm ơn và chữ ký giả
            gfx.DrawString("Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!", fontItalic, XBrushes.Black, new XRect(50, 450, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Ký tên:", fontBold, XBrushes.Black, new XRect(50, 500, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawLine(XPens.Black, 120, 520, 300, 520); // Dòng ký tên

            // Lưu file PDF
            document.Save(filePath);

            // Hiển thị thông báo thành công
            MessageBox.Show($"Hóa đơn đã được lưu tại: {filePath}", "In Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

