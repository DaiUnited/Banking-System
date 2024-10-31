using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
namespace DoAn.Entities
{
    public class Transaction
    {
        public Guid MaGiaoDich { get; set; } 
        public string SoThe { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public string LoaiGiaoDich { get; set; } // Nạp tiền, Rút tiền, Chuyển khoản, Thanh toán
        public decimal SoTien { get; set; }
        public string SoTheNhan { get; set; } // Dành cho chuyển khoản
        public string MoTa { get; set; }
    }
}
