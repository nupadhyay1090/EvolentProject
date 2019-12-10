using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Contracts.Error.Exceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(string message) : base(message)
        {
            this.HttpStatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        }

        public BadRequestException(int code, string message) : base(code, message)
        {
            this.HttpStatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            this.Code = code;
        }

        public BadRequestException(int httpStatusCode, int code, string message) : base(httpStatusCode, code, message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Code = code;
        }

        
    }
}
