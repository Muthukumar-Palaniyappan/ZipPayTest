using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZipPay.Data.Entities
{
    public class AccountEntity
    {
        public Guid UserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool IsAccountActive { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
