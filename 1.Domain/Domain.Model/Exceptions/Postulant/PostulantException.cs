using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model.Exceptions.Postulant
{
    public class PostulantException : BusinessException
    {
        protected override int MainErrorCode => (int)ApplicationErrorMainCodes.Postulant;

        public PostulantException(string message)
            : base(string.IsNullOrEmpty(message) ? "There is a postulant related error" : message)
        {
        }
       
    }

    public class InvalidPostulantException : PostulantException
    {
        public InvalidPostulantException(string message):
            base(string.IsNullOrEmpty(message) ? "The postulant is not valid " : message)
        {}
    }

    public class DeletePostulantNotFoundException : InvalidPostulantException
    {
        protected override int SubErrorCode => (int) PostulantErrorSubCodes.DeletePostulantNotFound;

        public DeletePostulantNotFoundException(int postulantId) :
            base($"Postulant not found for the PostulantId: {postulantId}")
        {
            PostulantId = postulantId;
        }
        public int PostulantId { get; set; }
    }
}
