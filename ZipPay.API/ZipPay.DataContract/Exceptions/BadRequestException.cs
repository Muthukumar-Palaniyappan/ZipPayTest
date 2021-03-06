﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZipPay.DataContract.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException() { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception innerException) : base(message,innerException) { }
    }
}
