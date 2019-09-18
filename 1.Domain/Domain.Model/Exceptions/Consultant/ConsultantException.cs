using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Consultant
{
    public class ConsultantException : BusinessException
    {
        protected override int MainErrorCode => (int)ApplicationErrorMainCodes.Consultant;

        public ConsultantException(string message)
            : base(string.IsNullOrEmpty(message) ? "There is a consultant related error" : message)
        {
        }
    }

    public class InvalidConsultantException : ConsultantException
    {
        public InvalidConsultantException(string message)
            : base(string.IsNullOrEmpty(message) ? "The consultant is not valid" : message)
        {
        }
    }

    public class InvalidUpdateException : InvalidConsultantException
    {
        protected override int SubErrorCode => (int)ConsultantErrorSubCodes.InvalidUpdate;
        public InvalidUpdateException(string message)
            : base($"The update request is not valid for the consultant.")
        {
        }
    }

    public class DeleteConsultantNotFoundException : InvalidConsultantException
    {
        protected override int SubErrorCode => (int)ConsultantErrorSubCodes.DeleteConsultantNotFound;
        public DeleteConsultantNotFoundException(int consultantId)
            : base($"Consultant not found for the ConsultantId: {consultantId}")
        {
            ConsultantId = consultantId;
        }

        public int ConsultantId { get; set; }
    }

    public class ConsultantDeletedException : InvalidConsultantException
    {
        protected override int SubErrorCode => (int)ConsultantErrorSubCodes.ConsultantDeleted;
        public ConsultantDeletedException(int id, string name)
            : base($"The consultant {name} was deleted")
        {
            ConsultantId = id;
            Name = name;
        }

        public int ConsultantId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateConsultantNotFoundException : InvalidUpdateException
    {
        protected override int SubErrorCode => (int)ConsultantErrorSubCodes.UpdateConsultantNotFound;
        public UpdateConsultantNotFoundException(int consultantId, Guid clientSystemId)
            : base($"Consultant {consultantId} and Client System Id {clientSystemId} was not found.")
        {
            ConsultantId = consultantId;
            ClientSystemId = clientSystemId;
        }

        public int ConsultantId { get; }
        public Guid ClientSystemId { get; }
    }

    public class ConsultantNotFoundException : InvalidConsultantException
    {
        protected override int SubErrorCode => (int)ConsultantErrorSubCodes.ConsultantNotFound;
        public ConsultantNotFoundException(int consultantId) : base($"The Consultant {consultantId} was not found.")
        {
            ConsultantId = consultantId;
        }

        public int ConsultantId { get; }
    }

}

