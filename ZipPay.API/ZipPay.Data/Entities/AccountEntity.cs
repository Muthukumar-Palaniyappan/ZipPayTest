using System;
using System.Collections.Generic;
using System.Text;

namespace ZipPay.Data.Entities
{
    public class AccountEntity
    {
            public string Email { get; set; }
            public int AccountNumber { get; set; }
            public bool Active { get; set; }
    }
}
