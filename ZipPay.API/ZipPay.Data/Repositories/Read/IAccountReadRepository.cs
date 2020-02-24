using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Repositories.Read
{
    public interface IAccountReadRepository
    {
        Task<List<AccountEntity>> GetAccountListAsync();
        Task<AccountEntity> GetAccountByUserIdAsync(Guid userId);
    }
}
