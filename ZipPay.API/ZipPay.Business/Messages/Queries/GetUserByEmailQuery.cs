
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZipPay.DataContract;

namespace ZipPay.Business.Messages.Queries
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string EmailAddress { get; set; }
        public GetUserByEmailQuery(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
