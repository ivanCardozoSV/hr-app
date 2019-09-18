using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Role
{
    public class CreateContractInvalidException : BusinessValidationException
    {
        protected override int SubErrorCode => (int)RoleValidationExceptionCodes.CreateContractInvalid;
        public CreateContractInvalidException(List<KeyValuePair<string, string>> messages) : base(messages)
        {
        }
    }

    public class UpdateContractInvalidException : BusinessValidationException
    {
        protected override int SubErrorCode => (int)RoleValidationExceptionCodes.UpdateContractInvalid;
        public UpdateContractInvalidException(List<KeyValuePair<string, string>> messages) : base(messages)
        {
        }
    }
}
