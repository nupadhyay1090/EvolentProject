using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Contracts.Error.Exceptions
{
    public class ApiException : Exception
    {
        public int Code { get; set; }

        public int HttpStatusCode { get; set; }

        public ApiException(string message) : base(message)
        {
            this.HttpStatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
        }

        public ApiException(int code, string message) : base(message)
        {
            this.HttpStatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            this.Code = code;
        }

        public ApiException(int httpStatusCode, int code, string message) : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Code = code;
        }

        
    }
}
