using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Openings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IOpeningService
    {
        Task<IEnumerable<OpeningResponseDto>> ListAllAsync();
        Task<OpeningsDetailResponseDto> GetByIdAsync(Guid id);
        Task<OpeningsDetailResponseDto> AddAsync(OpeningsRequestDto eventRequest);
        Task<OpeningsDetailResponseDto> UpdateAsync(OpeningsRequestDto eventRequest);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<OpeningsDetailResponseDto>> SearchByNameAsync(string name);
    }
}
