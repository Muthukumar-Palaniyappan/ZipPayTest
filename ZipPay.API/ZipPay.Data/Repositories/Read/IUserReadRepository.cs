using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Repositories.Read
{
    public interface IUserReadRepository
    {
        Task<List<UserEntity>> GetUserListAsync();
        Task<UserEntity> GetUserByEmailAsync(string emailAddress);
        Task<UserEntity> GetUserByUserIdAsync(Guid userId);
    }
}
