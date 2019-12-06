using Domain.Services.Contracts.Postulant;
using Domain.Services.Contracts.Seed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces.Services
{
    public interface IPostulantService
    {
       // CreatedPostulantContract Create(CreatePostulantContract contract);
        ReadedPostulantContract Read(int id);
        IEnumerable<ReadedPostulantContract> List();
        void Delete(int id);
    }
}
