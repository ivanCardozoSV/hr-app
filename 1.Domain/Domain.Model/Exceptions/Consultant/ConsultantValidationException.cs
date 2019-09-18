using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Consultant
{
    public class CreateContractInvalidException : BusinessValidationException
    {
        protected override int SubErrorCode => (int)ConsultantValidationExceptionCodes.CreateContractInvalid;
        public CreateContractInvalidException(List<KeyValuePair<string, string>> messages) : base(messages)
        {
        }
    }

    public class UpdateContractInvalidException : BusinessValidationException
    {
        protected override int SubErrorCode => (int)ConsultantValidationExceptionCodes.UpdateContractInvalid;
        public UpdateContractInvalidException(List<KeyValuePair<string, string>> messages) : base(messages)
        {
        }
    }
}
