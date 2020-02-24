using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Repositories.Write
{
    public interface IAccountWriteRepository
    {
        Task CreateAccountAsync(AccountEntity account);
    }
}
