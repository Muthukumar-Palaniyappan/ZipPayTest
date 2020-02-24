using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZipPay.Data.Entities;
using ZipPay.DataContract;

namespace ZipPay.Business.Mapper
{
    public class AccountMappingProfile:Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<AccountEntity, AccountDetail>().ReverseMap();
        }

    }
}
