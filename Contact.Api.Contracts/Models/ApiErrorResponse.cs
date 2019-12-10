using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Contracts.Models
{
    public class ApiErrorResponse
    { 
        public string Message { get; set; }

        public int Code { get; set; }

        public string Status { get; set; }
        

        public ApiErrorResponse()
        {
            this.Status = Constants.Failure;
        }

        public ApiErrorResponse(string message)
        {
            this.Message = message;
            this.Status = Constants.Failure;
        }

        public ApiErrorResponse(int code, string message)
        {
            this.Code = code;
            this.Message = message;
            this.Status = Constants.Failure;
        }

       
    }
}

