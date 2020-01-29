﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Candidate
{
    public class CandidateException : BusinessException
    {
        protected override int MainErrorCode => (int)ApplicationErrorMainCodes.Candidate;

        public CandidateException(string message)
            : base(string.IsNullOrEmpty(message) ? "Candidate related error" : message)
        {
        }
    }

    public class InvalidCandidateException : CandidateException
    {
        public InvalidCandidateException(string message)
            : base(string.IsNullOrEmpty(message) ? "Candidate is not valid" : message)
        {
        }
    }


    public class DeleteCandidateNotFoundException : InvalidCandidateException
    {
        protected override int SubErrorCode => (int)CandidateErrorSubCodes.DeleteCandidateNotFound;
        public DeleteCandidateNotFoundException(int candidateId)
            : base($"Candidate not found for the CandidateId: {candidateId}")
        {
            CandidateId = candidateId;
        }

        public int CandidateId { get; set; }
    }

    public class CandidateDeletedException : InvalidCandidateException
    {
        protected override int SubErrorCode => (int)CandidateErrorSubCodes.CandidateDeleted;
        public CandidateDeletedException(int id, string name)
            : base($"The candidate {name} was deleted")
        {
            CandidateId = id;
            Name = name;
        }

        public int CandidateId { get; set; }
        public string Name { get; set; }
    }
    public class InvalidUpdateException : InvalidCandidateException
    {
        protected override int SubErrorCode => (int)CandidateErrorSubCodes.InvalidUpdate;
        public InvalidUpdateException(string message)
            : base($"The update request is not valid for the candidate.")
        {
        }
    }

    public class UpdateCandidateNotFoundException : InvalidUpdateException
    {
        protected override int SubErrorCode => (int)CandidateErrorSubCodes.UpdateCandidateNotFound;
        public UpdateCandidateNotFoundException(int candidateId, Guid clientSystemId)
            : base($"Candidate {candidateId} and Client System Id {clientSystemId} was not found.")
        {
            CandidateId = candidateId;
            ClientSystemId = clientSystemId;
        }
  
        public int CandidateId { get; }
        public Guid ClientSystemId { get; }
    }

    public class UpdateHasNotChangesException : InvalidUpdateException
    {
        protected override int SubErrorCode => (int)CandidateErrorSubCodes.UpdateHasNotChanges;
        public UpdateHasNotChangesException(int candidateId, Guid clientSystemId, string name)
            : base($"Candidate {name} has not changes.")
        {
            CandidateId = candidateId;
            ClientSystemId = clientSystemId;
        }

        public int CandidateId { get; }
        public Guid ClientSystemId { get; }
    }

    public class CandidateNotFoundException : InvalidCandidateException
    {
        protected override int SubErrorCode => (int)CandidateErrorSubCodes.CandidateNotFound;
        public CandidateNotFoundException(int candidateId) : base($"Candidate {candidateId} was not found.")
        {
            CandidateId = candidateId;
        }

        public int CandidateId { get; }
    }

}

