using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Games;
using Imi.Project.Api.Core.Dtos.Moves;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameResponseDto>> ListAllAsync();
        Task<GameDetailResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<GameDetailResponse>> GetByUserId(Guid id);
        Task<GameDetailResponse> AddAsync(GameRequestDto gameRequest);
        Task<GameDetailResponse> UpdateAsync(GameRequestDto gameRequest);
        Task DeleteAsync(Guid id);
        Task<GameDetailResponse> UpdateGameMoves(Guid id, IEnumerable<MoveRequestDto> gameMoves);
    }
}
