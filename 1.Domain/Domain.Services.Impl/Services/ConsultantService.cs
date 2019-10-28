using AutoMapper;
using Core;
using Core.Persistance;
using Domain.Model;
using Domain.Services.Contracts.Consultant;
using Domain.Model.Exceptions.Consultant;
using Domain.Services.Impl.Validators;
using Domain.Services.Impl.Validators.Consultant;
using Domain.Services.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Domain.Services.Impl.Services
{
    public class ConsultantService : IConsultantService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Consultant> _consultantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog<ConsultantService> _logger;
        private readonly UpdateConsultantContractValidator _updateConsultantContractValidator;
        private readonly CreateConsultantContractValidator _createConsultantContractValidator;


        public ConsultantService(IMapper mapper,
            IRepository<Consultant> consultantRepository,
            IUnitOfWork unitOfWork,
            ILog<ConsultantService> log,
            UpdateConsultantContractValidator updateConsultantContractValidator,
            CreateConsultantContractValidator createConsultantContractValidator)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;
            _unitOfWork = unitOfWork;
            _logger = log;
            _updateConsultantContractValidator = updateConsultantContractValidator;
            _createConsultantContractValidator = createConsultantContractValidator;
        }

        public ReadedConsultantContract Read(int id)
        {
            var consultantQuery = _consultantRepository
                .QueryEager()
                .Where(_ => _.Id == id);

            var consultantResult = consultantQuery.SingleOrDefault();

            return _mapper.Map<ReadedConsultantContract>(consultantResult);
        }

        public IEnumerable<ReadedConsultantContract> List()
        {
            var consultantQuery = _consultantRepository
                .QueryEager();

            var consultantResult = consultantQuery.ToList();

            return _mapper.Map<List<ReadedConsultantContract>>(consultantResult);
        }

        public ReadedConsultantByNameContract GetConsultantsByName(string name)
        {
            var consultants = _consultantRepository.Query()
                .Where(x => x.Name.Contains(name) || x.LastName.Contains(name)).ToList();

            return _mapper.Map<ReadedConsultantByNameContract>(consultants);
        }

        public Consultant GetByEmail(string email)
        {
            Consultant consultant = _consultantRepository.Query()
                .Where(x => x.EmailAddress == email).FirstOrDefault();
            return _mapper.Map<Consultant>(consultant);
        }

        public CreatedConsultantContract Create(CreateConsultantContract contract)
        {
            _logger.LogInformation($"Validating contract {contract.Name}");
            ValidateContract(contract);
            ValidateExistence(0, contract.EmailAddress);

            _logger.LogInformation($"Mapping contract {contract.Name}");
            var consultant = _mapper.Map<Consultant>(contract);

            var createdConsultant = _consultantRepository.Create(consultant);
            _logger.LogInformation($"Complete for {contract.Name}");
            _unitOfWork.Complete();
            _logger.LogInformation($"Return {contract.Name}");
            return _mapper.Map<CreatedConsultantContract>(createdConsultant);
        }

        public void Delete(int id)
        {
            _logger.LogInformation($"Searching consultant {id}");
            Consultant consultant = _consultantRepository.Query().Where(_ => _.Id == id).FirstOrDefault();

            if (consultant == null)
            {
                throw new DeleteConsultantNotFoundException(id);
            }
            _logger.LogInformation($"Deleting consultant {id}");
            _consultantRepository.Delete(consultant);

            _unitOfWork.Complete();
        }

        public void Update(UpdateConsultantContract contract)
        {
            _logger.LogInformation($"Validating contract {contract.Name}");
            ValidateContract(contract);
            ValidateExistence(contract.Id, contract.EmailAddress);

            _logger.LogInformation($"Mapping contract {contract.Name}");
            var consultant = _mapper.Map<Consultant>(contract);

            var updatedConsultant = _consultantRepository.Update(consultant);
            _logger.LogInformation($"Complete for {contract.Name}");
            _unitOfWork.Complete();
        }

        private void ValidateContract(CreateConsultantContract contract)
        {
            try
            {
                _createConsultantContractValidator.ValidateAndThrow(contract,
                    $"{ValidatorConstants.RULESET_CREATE}");
            }
            catch (ValidationException ex)
            {
                throw new CreateContractInvalidException(ex.ToListOfMessages());
            }
        }

        private void ValidateContract(UpdateConsultantContract contract)
        {
            try
            {
                _updateConsultantContractValidator.ValidateAndThrow(contract,
                    $"{ValidatorConstants.RULESET_UPDATE}");
            }
            catch (ValidationException ex)
            {
                throw new CreateContractInvalidException(ex.ToListOfMessages());
            }
        }

        private void ValidateExistence(int id, string email)
        {
            try
            {
                Consultant consultant = _consultantRepository.Query().Where(_ => _.EmailAddress == email && _.Id != id).FirstOrDefault();
                if (consultant != null) throw new InvalidConsultantException("The email already exists .");
            }
            catch (ValidationException ex)
            {
                throw new CreateContractInvalidException(ex.ToListOfMessages());
            }
        }
    }
}
