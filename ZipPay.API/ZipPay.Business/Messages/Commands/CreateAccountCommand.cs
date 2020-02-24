using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZipPay.DataContract;

namespace ZipPay.Business.Messages.Commands
{
    public class CreateAccountCommand :IRequest<AccountDetail>
    {
       
        public Account _Account { get; set; }

        public CreateAccountCommand(Account account)
        {
            _Account = account??throw new ArgumentNullException(nameof(account));
        }

    }
}
