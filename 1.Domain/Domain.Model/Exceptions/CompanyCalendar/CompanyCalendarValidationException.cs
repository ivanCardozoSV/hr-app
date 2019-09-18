using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.CompanyCalendar
{
    public class CreateContractInvalidException : BusinessValidationException
    {
        protected override int SubErrorCode => (int)CompanyCalendarValidationExceptionCodes.CreateContractInvalid;
        public CreateContractInvalidException(List<KeyValuePair<string, string>> messages) : base(messages)
        {
        }
    }

    public class UpdateContractInvalidException : BusinessValidationException
    {
        protected override int SubErrorCode => (int)CompanyCalendarValidationExceptionCodes.UpdateContractInvalid;
        public UpdateContractInvalidException(List<KeyValuePair<string, string>> messages) : base(messages)
        {
        }
    }
}
