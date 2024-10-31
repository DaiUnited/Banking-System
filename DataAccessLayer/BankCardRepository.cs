using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using DoAn.Entities;
using DoAn.DataAccessLayer;
using static System.Collections.Specialized.BitVector32;


namespace DoAn.DataAccessLayer
{
    public class BankCardRepository
    {
        private readonly ISession _session;

        public BankCardRepository()
        {
            _session = CassandraConnection.GetSession();
        }

        public List<BankCard> GetAll()
        {
            var query = "SELECT * FROM the_ngan_hang";
            var result = _session.Execute(query);
            return result.Select(row => new BankCard
            {
                SoThe = row.GetValue<string>("so_the"),
                TenChuThe = row.GetValue<string>("ten_chu_the"),
                NgayHetHan = row.GetValue<string>("ngay_het_han"),
                SoDu = row.GetValue<decimal>("so_du"),
            }).ToList();
        }

        // Thêm thẻ mới
        public void Add(BankCard card)
        {
            var query = $"INSERT INTO the_ngan_hang (so_the, ten_chu_the, ngay_het_han, ma_pin, so_du) " +
                $"VALUES ('{card.SoThe}', '{card.TenChuThe}', '{card.NgayHetHan}', '1', {card.SoDu})"; // Mã PIN mặc định là '1'
            _session.Execute(query);
        }

        // Cập nhật thẻ hiện có
        public void Update(BankCard card)
        {
            var query = $"UPDATE the_ngan_hang SET ten_chu_the = '{card.TenChuThe}', ngay_het_han = '{card.NgayHetHan}', so_du = {card.SoDu} WHERE so_the = '{card.SoThe}'";
            _session.Execute(query);
        }

        // Xóa thẻ
        public void Delete(string soThe)
        {
            var query = $"DELETE FROM the_ngan_hang WHERE so_the = '{soThe}'";
            _session.Execute(query);
        }

        public void ChangePin(string soThe, string newPin)
        {
            var query = $"UPDATE the_ngan_hang SET ma_pin = '{newPin}' WHERE so_the = '{soThe}'";
            _session.Execute(query);
        }

        public BankCard Login(string soThe, string maPin = null)
        {
            string query;
            if (maPin != null) // Đăng nhập
            {
                query = "SELECT * FROM the_ngan_hang WHERE so_the = ? AND ma_pin = ? ALLOW FILTERING";
            }
            else // Trường hợp không cần maPin (ví dụ: nạp tiền, rút tiền)
            {
                query = "SELECT * FROM the_ngan_hang WHERE so_the = ? ALLOW FILTERING";
            }

            var preparedStatement = _session.Prepare(query);
            BoundStatement boundStatement;

            if (maPin != null)
            {
                boundStatement = preparedStatement.Bind(soThe, maPin);
            }
            else
            {
                boundStatement = preparedStatement.Bind(soThe);
            }

            var resultSet = _session.Execute(boundStatement);
            var row = resultSet.FirstOrDefault();

            if (row != null)
            {
                return new BankCard
                {
                    SoThe = row.GetValue<string>("so_the"),
                    TenChuThe = row.GetValue<string>("ten_chu_the"),
                    SoDu = row.GetValue<decimal>("so_du")
                };
            }

            return null;
        }


        // Cập nhật số dư
        public void UpdateSoDu(string soThe, decimal soDuMoi)
        {
            var query = $"UPDATE the_ngan_hang SET so_du = {soDuMoi} WHERE so_the = '{soThe}'";
            _session.Execute(query);
        }

        // Nạp tiền
        public void NapTien(string soThe, decimal soTienNap)
        {
            var bankCard = Login(soThe, null); // Không cần maPin cho việc nạp tiền
            if (bankCard != null)
            {
                UpdateSoDu(soThe, bankCard.SoDu + soTienNap);
            }
        }

        // Rút tiền
        public void RutTien(string soThe, decimal soTienRut)
        {
            var bankCard = Login(soThe, null); // Không cần maPin cho việc rút tiền
            if (bankCard != null && bankCard.SoDu >= soTienRut)
            {
                UpdateSoDu(soThe, bankCard.SoDu - soTienRut);
            }
        }

        // Chuyển tiền
        public void ChuyenTien(string soTheGui, string soTheNhan, decimal soTienChuyen)
        {
            var theGui = Login(soTheGui, null);
            var theNhan = Login(soTheNhan, null);

            if (theGui != null && theGui.SoDu >= soTienChuyen && theNhan != null)
            {
                UpdateSoDu(soTheGui, theGui.SoDu - soTienChuyen);
                UpdateSoDu(soTheNhan, theNhan.SoDu + soTienChuyen);
            }
        }
    }
}
