using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Repositories.Read
{
    public class AccountReadRepository : IAccountReadRepository
    {
        private readonly ZipEntities _zipEntities = null;

        public AccountReadRepository()
        {
            _zipEntities = new ZipEntities();
        }

        public async Task<AccountEntity> GetAccountByUserIdAsync(Guid userId)
        {
            return await _zipEntities.AccountEntities
                .FirstOrDefaultAsync(u => u.UserId==userId && u.IsAccountActive);
        }

        public async Task<List<AccountEntity>> GetAccountListAsync()
        {
            return await _zipEntities.AccountEntities.ToListAsync();
        }

        
    }
}
