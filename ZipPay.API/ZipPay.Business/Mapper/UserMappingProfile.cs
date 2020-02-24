using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZipPay.Data.Entities;
using ZipPay.DataContract;

namespace ZipPay.Business.Mapper
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserEntity, UserDetail>().ReverseMap();
            CreateMap<User, UserEntity>();
                
        }

    }
}
