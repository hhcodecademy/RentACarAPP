//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using FluentValidation;
//using RentACarAPP.Application.Validotor;
//using RentACarAPP.Contract.Dtos;
//using RentACarAPP.Contract.Services;
//using RentACarAPP.Domain.Entity;
//using RentACarAPP.Domain.Repository;

//namespace RentACarAPP.Application.Services
//{
//    public class LogDataService : GenericService<LogData, LogDataDTO>, ILogDataService
//    {
//        public LogDataService(IGenericRepository<LogData> repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper, unitOfWork)
//        {
//        }

//        public async Task AddAsync(LogDataDTO dto)
//        {

//            var logData = new LogData
//            {
//                Source = dto.Source,
//                Level = dto.Level,
//                CreatedDate = DateTime.UtcNow,

//                Message = dto.Message,

//            };

//            await _repository.AddAsync(logData);

//        }
//    }
//}
