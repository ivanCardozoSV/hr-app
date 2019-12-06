using AutoMapper;
using Core;
using Core.Persistance;
using Domain.Model;
using Domain.Model.Exceptions.Postulant;
using Domain.Services.Contracts.Postulant;
using Domain.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services.Impl.Services
{
    public class PostulantService : IPostulantService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Postulant> _postulantRepository;
        private readonly ILog<PostulantService> _log;
        private readonly IUnitOfWork _unitOfWork;

        public PostulantService(IMapper mapper,
            IRepository<Postulant> postulandRepository,
            ILog<PostulantService> log, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _postulantRepository = postulandRepository;
            _log = log;
            _unitOfWork = unitOfWork;
        }
        public ReadedPostulantContract Read(int id)
        {
            var postulantQuery = _postulantRepository
                .QueryEager()
                .Where(_ => _.Id == id);
            var postulantResult = postulantQuery.SingleOrDefault();
            return _mapper.Map<ReadedPostulantContract>(postulantResult);
        }
        public IEnumerable<ReadedPostulantContract> List()
        {
            var postulantQuery = _postulantRepository
                .QueryEager();
            var postulantResult = postulantQuery.ToList();
            return _mapper.Map<List<ReadedPostulantContract>>(postulantResult);
        }

        public void Delete(int id)
        {
            _log.LogInformation($"Searching postulant {id}");
            Postulant postulant = _postulantRepository.Query().Where(_ => _.Id == id).FirstOrDefault();

            if(postulant == null)
            {
                throw new DeletePostulantNotFoundException(id);
            }
            _log.LogInformation($"Deleting postulant {id}");
            _postulantRepository.Delete(postulant);

            _unitOfWork.Complete();
        }
    }
}
