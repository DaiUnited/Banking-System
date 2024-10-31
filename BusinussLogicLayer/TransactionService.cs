using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.DataAccessLayer;
using DoAn.Entities;

namespace DoAn.BusinessLogicLayer
{
    public class TransactionService
    {
        private TransactionRepository repository;

        public TransactionService()
        {
            repository = new TransactionRepository();
        }

        // Tìm kiếm các giao dịch theo số thẻ
        public List<Transaction> GetTransactionsByCardNumber(string soThe)
        {
            return repository.GetTransactionsByCardNumber(soThe);
        }
    }
}

