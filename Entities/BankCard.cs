using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace DoAn.Entities
{
    public class BankCard
    {
        public string SoThe { get; set; }
        public string TenChuThe { get; set; }
        public string NgayHetHan { get; set; }
        public decimal SoDu { get; set; }
        public string maPin { get; set; }
    }
}
