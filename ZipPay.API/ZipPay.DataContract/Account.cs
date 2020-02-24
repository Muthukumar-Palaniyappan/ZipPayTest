using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZipPay.DataContract.Filters;

namespace ZipPay.DataContract
{
    public class Account
    {
        [RequiredGuid]
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        
        
    }
    public class  AccountDetail:Account
    {
        public long AccountNo { get; set; }
        public bool IsAccountActive { get; set; }
    }
}
