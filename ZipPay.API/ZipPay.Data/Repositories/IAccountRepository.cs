using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Repositories
{
    public interface IAccountRepository
    {
        Task<List<AccountEntity>> GetAccountListAsync();
    }
}
