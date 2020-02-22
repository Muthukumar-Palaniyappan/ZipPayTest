using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZipPay.Data.Entities
{
    public class UserEntity
    {

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyIncome { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyExpense { get; set; }

        //public UserEntity()
        //{
        //    UserId = Guid.NewGuid();
        //}

    }
}
