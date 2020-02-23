using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;

namespace ZipPay.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ZipEntities _zipEntities = null;

        public UserRepository()
        {
            _zipEntities = new ZipEntities();
        }

        public async Task<UserEntity> GetUserByEmailAsync(string emailAddress)
        {
            return await _zipEntities.UserEntities
                .SingleOrDefaultAsync(u => string.Equals(u.EmailAddress,emailAddress,
                StringComparison.OrdinalIgnoreCase));
        }

        public async Task<List<UserEntity>> GetUserListAsync()
        {
            return await _zipEntities.UserEntities.ToListAsync();
        }
    }
}
