using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using DoAn.Entities;

namespace DoAn.DataAccessLayer
{
    public class TransactionRepository
    {
        private ISession session;

        public TransactionRepository()
        {
            session = CassandraConnection.GetSession();
        }

        // Tìm kiếm các giao dịch theo số thẻ
        public List<Transaction> GetTransactionsByCardNumber(string soThe)
        {
            var transactions = new List<Transaction>();
            var query = $"SELECT * FROM lich_su_giao_dich WHERE so_the = '{soThe}' ORDER BY ngay_giao_dich DESC";
            var result = session.Execute(query);

            foreach (var row in result)
            {
                var transaction = new Transaction
                {
                    SoThe = row.GetValue<string>("so_the"),
                    MaGiaoDich = row.GetValue<System.Guid>("ma_giao_dich"),
                    NgayGiaoDich = row.GetValue<System.DateTime>("ngay_giao_dich"),
                    LoaiGiaoDich = row.GetValue<string>("loai_giao_dich"),
                    SoTien = row.GetValue<decimal>("so_tien"),
                    SoTheNhan = row.GetValue<string>("so_the_nhan"),
                    MoTa = row.GetValue<string>("mo_ta")
                };
                transactions.Add(transaction);
            }

            return transactions;
        }

        public void SaveTransaction(Transaction transaction)
        {
            var query = $"INSERT INTO lich_su_giao_dich (so_the, ma_giao_dich, ngay_giao_dich, loai_giao_dich, so_tien, so_the_nhan, mo_ta) " +
                        $"VALUES ('{transaction.SoThe}', {transaction.MaGiaoDich}, toTimestamp(now()), '{transaction.LoaiGiaoDich}', {transaction.SoTien}, '{transaction.SoTheNhan}', '{transaction.MoTa}')";

            session.Execute(query);
        }
    }
}

