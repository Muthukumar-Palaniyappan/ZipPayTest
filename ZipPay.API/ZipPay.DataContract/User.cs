using System;

namespace ZipPay.DataContract
{
    public class User 
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal MonthlyExpense { get; set; }
    }
}
