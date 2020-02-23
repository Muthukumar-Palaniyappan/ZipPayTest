using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZipPay.DataContract;

namespace ZipPay.Business.Messages.Queries
{
    public class GetUserListQuery:IRequest<List<User>>
    {
    }
}
