﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.DaysOff
{
    public class DaysOffException : BusinessException
    {
        protected override int MainErrorCode => (int)ApplicationErrorMainCodes.DaysOff;

        public DaysOffException(string message)
            : base(string.IsNullOrEmpty(message) ? "There is a days off related error" : message)
        {
        }
    }

    public class InvalidDaysOffException : DaysOffException
    {
        public InvalidDaysOffException(string message)
            : base(string.IsNullOrEmpty(message) ? "The days off is not valid" : message)
        {
        }
    }


    public class DeleteDaysOffNotFoundException : InvalidDaysOffException
    {
        protected override int SubErrorCode => (int)DaysOffErrorSubCodes.DeleteDaysOffNotFound;
        public DeleteDaysOffNotFoundException(int daysOffId)
            : base($"Days off not found for the DaysOffId: {daysOffId}")
        {
            DaysOffId = daysOffId;
        }

        public int DaysOffId { get; set; }
    }

    public class DaysOffDeletedException : InvalidDaysOffException
    {
        protected override int SubErrorCode => (int)DaysOffErrorSubCodes.DaysOffDeleted;
        public DaysOffDeletedException(int id, string name)
            : base($"The days off {name} was deleted")
        {
            DaysOffId = id;
            Name = name;
        }

        public int DaysOffId { get; set; }
        public string Name { get; set; }
    }
    public class InvalidUpdateException : InvalidDaysOffException
    {
        protected override int SubErrorCode => (int)DaysOffErrorSubCodes.InvalidUpdate;
        public InvalidUpdateException(string message)
            : base($"The update request is not valid for the DaysOff.")
        {
        }
    }

    public class UpdateDaysOffNotFoundException : InvalidUpdateException
    {
        protected override int SubErrorCode => (int)DaysOffErrorSubCodes.UpdateDaysOffNotFound;
        public UpdateDaysOffNotFoundException(int daysOffId, Guid clientSystemId)
            : base($"Days off {daysOffId} and Client System Id {clientSystemId} was not found.")
        {
            DaysoffId = daysOffId;
            ClientSystemId = clientSystemId;
        }
  
        public int DaysoffId { get; }
        public Guid ClientSystemId { get; }
    }

    public class UpdateHasNotChangesException : InvalidUpdateException
    {
        protected override int SubErrorCode => (int)DaysOffErrorSubCodes.UpdateHasNotChanges;
        public UpdateHasNotChangesException(int daysOffId, Guid clientSystemId, string name)
            : base($"Days off {name} has not changes.")
        {
            DaysOffId = daysOffId;
            ClientSystemId = clientSystemId;
        }

        public int DaysOffId { get; }
        public Guid ClientSystemId { get; }
    }

    public class DaysOffNotFoundException : InvalidDaysOffException
    {
        protected override int SubErrorCode => (int)DaysOffErrorSubCodes.DaysOffNotFound;
        public DaysOffNotFoundException(int daysOffId) : base($"The days Off {daysOffId} was not found.")
        {
            DaysOffId = daysOffId;
        }

        public int DaysOffId { get; }
    }

}

