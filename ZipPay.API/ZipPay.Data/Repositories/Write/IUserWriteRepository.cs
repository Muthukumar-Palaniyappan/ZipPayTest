using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Repositories.Write
{
    public interface IUserWriteRepository
    {
        Task CreateUserAsync(UserEntity user);
        
    }
}
