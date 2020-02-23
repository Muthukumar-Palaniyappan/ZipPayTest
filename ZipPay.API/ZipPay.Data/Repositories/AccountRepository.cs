using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ZipEntities _zipEntities = null;

        public AccountRepository()
        {
            _zipEntities = new ZipEntities();
        }

        public async Task<List<AccountEntity>> GetAccountListAsync()
        {
            return await _zipEntities.AccountEntities.ToListAsync();
        }

        
    }
}
