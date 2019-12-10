using Api.Contracts.Error.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Api.Contracts.Error.Resources;
namespace Api.Contracts.Error
{
    public static class ClientErrors
    {
        public static BadRequestException InvalidEmailId()
        {
            return new BadRequestException(Convert.ToInt32(FaultCode.InvalidEmailID), FaultMessage.InvalidEmailID);
        }

        public static BadRequestException InvalidFirstName()
        {
            return new BadRequestException(Convert.ToInt32(FaultCode.InvalidFirstName), FaultMessage.InvalidFirstName);
        }

        public static BadRequestException InvalidLastName()
        {
            return new BadRequestException(Convert.ToInt32(FaultCode.InvalidLastName), FaultMessage.InvalidLastName);
        }
    }
}
