using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZipPay.Data.Entities;
using ZipPay.Data.Repositories.Read;

namespace ZipPay.Data.Repositories.Write
{
    public class UserWriteRepository : IUserWriteRepository
    {
        private readonly ZipEntities _zipEntities = null;
        

        public UserWriteRepository(IUserReadRepository userReadRepository)
        {
            _zipEntities = new ZipEntities();
        }

        public async Task CreateUserAsync(UserEntity user)
        {
            await _zipEntities.UserEntities.AddAsync(user);
            await _zipEntities.SaveChangesAsync();
        }
    }
}
