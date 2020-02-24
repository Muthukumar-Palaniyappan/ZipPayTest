using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZipPay.Business.Mapper
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
                cfg.AddProfile(new AccountMappingProfile());
            });

            return config;
        }
    }
}
