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
    public partial class ChuyenTien : Form
    {
        private BankCardService service;
        private BankCard bankCard;
        private KhachHangForm khachHangForm;

        public ChuyenTien(BankCard bankCard, KhachHangForm khachHangForm)
        {
            InitializeComponent();
            service = new BankCardService();
            this.bankCard = bankCard;
            this.khachHangForm = khachHangForm;
        }

        private void btnChuyenTien_Click(object sender, EventArgs e)
        {
            string soTheNhan = txtSoTheNhan.Text;
            decimal soTienChuyen = decimal.Parse(txtSoTienChuyen.Text);

            service.ChuyenTien(bankCard.SoThe, soTheNhan, soTienChuyen);
            MessageBox.Show("Chuyển tiền thành công!");

            // Hỏi người dùng có muốn in hóa đơn không
            DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn không?", "In Hóa Đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InHoaDon("Chuyển tiền", soTienChuyen);
            }

            khachHangForm.RefreshData(); // Gọi phương thức refresh để cập nhật số dư mới
            this.Close();
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
            gfx.DrawString($"Loại Giao Dịch: {loaiGiaoDich}", fontText, XBrushes.Black, new XRect(50, 330, page.Width, page.Height), XStringFormats.TopLeft);
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
