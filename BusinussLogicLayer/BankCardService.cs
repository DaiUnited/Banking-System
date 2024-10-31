using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.DataAccessLayer;
using Cassandra;
using DoAn.Entities;

namespace DoAn.BusinessLogicLayer
{
    public class BankCardService
    {
        private readonly BankCardRepository _bankCardRepository;
        private TransactionRepository _transactionRepository;

        public BankCardService()
        {
            _bankCardRepository = new BankCardRepository();
            _transactionRepository = new TransactionRepository();
        }

        public IEnumerable<BankCard> GetAllBankCards()
        {
            return _bankCardRepository.GetAll();
        }


        public BankCard Login(string soThe, string maPin = null)
        {
            return _bankCardRepository.Login(soThe, maPin);
        }

        public void NapTien(string soThe, decimal soTienNap)
        {
            _bankCardRepository.NapTien(soThe, soTienNap);

            // Lưu lịch sử giao dịch
            var transaction = new Transaction
            {
                SoThe = soThe,
                MaGiaoDich = Guid.NewGuid(),
                LoaiGiaoDich = "Nạp tiền",
                SoTien = soTienNap,
                MoTa = "Nạp tiền vào thẻ"
            };
            _transactionRepository.SaveTransaction(transaction);
        }

        public void RutTien(string soThe, decimal soTienRut)
        {
            _bankCardRepository.RutTien(soThe, soTienRut);

            // Lưu lịch sử giao dịch
            var transaction = new Transaction
            {
                SoThe = soThe,
                MaGiaoDich = Guid.NewGuid(),
                LoaiGiaoDich = "Rút tiền",
                SoTien = soTienRut,
                MoTa = "Rút tiền từ thẻ"
            };
            _transactionRepository.SaveTransaction(transaction);
        }

        public void ChuyenTien(string soTheGui, string soTheNhan, decimal soTienChuyen)
        {
            _bankCardRepository.ChuyenTien(soTheGui, soTheNhan, soTienChuyen);

            // Lưu lịch sử giao dịch cho người gửi
            var transactionGui = new Transaction
            {
                SoThe = soTheGui,
                MaGiaoDich = Guid.NewGuid(),
                LoaiGiaoDich = "Chuyển tiền",
                SoTien = soTienChuyen,
                SoTheNhan = soTheNhan,
                MoTa = $"Chuyển tiền đến thẻ {soTheNhan}"
            };
            _transactionRepository.SaveTransaction(transactionGui);

            // Lưu lịch sử giao dịch cho người nhận
            var transactionNhan = new Transaction
            {
                SoThe = soTheNhan,
                MaGiaoDich = Guid.NewGuid(),
                LoaiGiaoDich = "Nhận tiền",
                SoTien = soTienChuyen,
                SoTheNhan = soTheGui,
                MoTa = $"Nhận tiền từ thẻ {soTheGui}"
            };
            _transactionRepository.SaveTransaction(transactionNhan);
        }
        public void AddBankCard(BankCard bankCard)
        {
            bankCard.maPin = "1";
            _bankCardRepository.Add(bankCard);
        }

        public void UpdateBankCard(BankCard bankCard)
        {
            _bankCardRepository.Update(bankCard);
        }

        public void DeleteBankCard(string cardNumber)
        {
            _bankCardRepository.Delete(cardNumber);
        }
        public void ChangePin(string soThe, string newPin)
        {
            _bankCardRepository.ChangePin(soThe, newPin);
        }

        public decimal TruyVanSoDu(string soThe)
        {
            // Truy vấn thẻ từ cơ sở dữ liệu
            var bankCard = _bankCardRepository.Login(soThe);

            // Trả về số dư hiện tại
            if (bankCard != null)
            {
                return bankCard.SoDu;
            }

            return 0; // Trả về 0 nếu không tìm thấy thẻ
        }

        private void ValidateBankCard(BankCard bankCard)
        {
            if (string.IsNullOrWhiteSpace(bankCard.SoThe) ||
                string.IsNullOrWhiteSpace(bankCard.TenChuThe) ||
                string.IsNullOrWhiteSpace(bankCard.NgayHetHan) ||
                bankCard.SoDu < 0)
            {
                throw new ArgumentException("Dữ liệu thẻ ngân hàng không hợp lệ.");
            }
        }
    }
}
