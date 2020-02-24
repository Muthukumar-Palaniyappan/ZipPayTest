using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Repositories.Write
{
    public class AccountWriteRepository : IAccountWriteRepository
    {
        private readonly ZipEntities _zipEntities = null;

        public AccountWriteRepository()
        {
            _zipEntities = new ZipEntities();
        }

        public async Task CreateAccountAsync(AccountEntity account)
        {
            await _zipEntities.AccountEntities.AddAsync(account);
            await _zipEntities.SaveChangesAsync();
        }
    }
}
