using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ZipPay.DataContract;

namespace ZipPay.Business.Messages.Commands
{
    public class CreateUserCommand :IRequest<UserDetail>
    {
       
        public User _User { get; set; }

        public CreateUserCommand(User user)
        {
            _User = user??throw new ArgumentNullException(nameof(user));
        }


        // public CreateUserCommand(string userName, string emailAddress)
        // {
        //     UserName = userName;
        //     EmailAddress = emailAddress;
        // }


        // //[Required]
        // //[MaxLength(50)]
        // public string UserName { get; set; }


        // //[Required]
        // //[MaxLength(50)]
        // //[EmailAddress]
        // public string EmailAddress { get; set; }

        //// [Range(0, int.MaxValue, ErrorMessage = "Monthly Income must be positive")]
        // public decimal MonthlyIncome { get; set; }

        // //[Range(0, int.MaxValue, ErrorMessage = "Monthly expense must be positive")]
        // public decimal MonthlyExpense { get; set; }
    }
}
