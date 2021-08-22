using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Openings;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class OpeningService : IOpeningService
    {
        private readonly IOpeningRepository _openingRepository;
        private readonly IMapper _mapper;

        public OpeningService(IOpeningRepository openingRepository,
            IMapper mapper)
        {
            _openingRepository = openingRepository;
            _mapper = mapper;
        }

        public async Task<OpeningsDetailResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _openingRepository.GetByIdAsync(id);

            var dto = _mapper.Map<OpeningsDetailResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<OpeningResponseDto>> ListAllAsync()
        {
            var result = await _openingRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<OpeningResponseDto>>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _openingRepository.DeleteAsync(id);
        }

        public async Task<OpeningsDetailResponseDto> AddAsync(OpeningsRequestDto openingsRequest)
        {
            var openingEntity = _mapper.Map<Opening>(openingsRequest);

            var result = await _openingRepository.AddAsync(openingEntity);
            var dto = _mapper.Map<OpeningsDetailResponseDto>(result);
            return dto;
        }

        public async Task<OpeningsDetailResponseDto> UpdateAsync(OpeningsRequestDto openingsRequest)
        {
            var openingEntity = _mapper.Map<Opening>(openingsRequest);
            var result = await _openingRepository.UpdateAsync(openingEntity);
            var dto = _mapper.Map<OpeningsDetailResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<OpeningsDetailResponseDto>> SearchByNameAsync(string name)
        {
            var openingEntity = await _openingRepository.SearchByNameAsync(name);
            return _mapper.Map<IEnumerable<OpeningsDetailResponseDto>>(openingEntity);
        }

    }
}
