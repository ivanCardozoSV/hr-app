using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Stage
{
    public class CreateStageInvalidException : BusinessValidationException
    {
        protected override int SubErrorCode => (int)StageValidationExceptionCodes.CreateContractInvalid;
        public CreateStageInvalidException(List<KeyValuePair<string, string>> messages) : base(messages)
        {
        }
    }

    public class UpdateStageInvalidException : BusinessValidationException
    {
        protected override int SubErrorCode => (int)StageValidationExceptionCodes.UpdateContractInvalid;
        public UpdateStageInvalidException(List<KeyValuePair<string, string>> messages) : base(messages)
        {
        }
    }
}
