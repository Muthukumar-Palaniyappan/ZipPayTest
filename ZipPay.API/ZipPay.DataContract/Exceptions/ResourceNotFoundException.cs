using System;
using System.Collections.Generic;
using System.Text;

namespace ZipPay.DataContract.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() { }
        public ResourceNotFoundException(string message) : base(message) { }
        public ResourceNotFoundException(string message, Exception innerException) : base(message,innerException) { }
    }
}
