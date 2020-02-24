using System;
using System.ComponentModel.DataAnnotations;

namespace ZipPay.DataContract
{
    public class User 
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Range(0,10000000000)]
        public decimal MonthlyIncome { get; set; }
        [Required]
        [Range(0, 10000000000)]
        public decimal MonthlyExpense { get; set; }
    }
    public class UserDetail:User
    {
        public Guid UserId { get; set; }
    }
}
