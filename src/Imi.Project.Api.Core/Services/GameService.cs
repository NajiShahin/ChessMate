using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Dtos.Games;
using Imi.Project.Api.Core.Dtos.Moves;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IOpeningRepository _openingRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository,
            IMapper mapper,
            IOpeningRepository openingRepository)
        {
            _gameRepository = gameRepository;
            _openingRepository = openingRepository;
            _mapper = mapper;
        }

        public async Task<GameDetailResponse> GetByIdAsync(Guid id)
        {
            var result = await _gameRepository.GetByIdAsync(id);
            if (result == null)
                return null;
            var dto = _mapper.Map<GameDetailResponse>(result);
            dto.Moves = dto.Moves.OrderBy(u => u.Turn).ToList();
            return dto;
        }

        public async Task<IEnumerable<GameResponseDto>> ListAllAsync()
        {
            var result = await _gameRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<GameResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<GameDetailResponse>> GetByUserId(Guid id)
        {
            var result = await _gameRepository.GetByUserId(id);

            var dto = _mapper.Map<IEnumerable<GameDetailResponse>>(result);
            return dto;
        }
        public async Task<GameDetailResponse> AddAsync(GameRequestDto gameRequest)
        {
            var gameEntity = _mapper.Map<Game>(gameRequest);

            gameEntity.OpeningId = GetOpening(gameEntity.Moves).Result.Id;

            SetMoves(gameEntity);

            var result = await _gameRepository.AddAsync(gameEntity);
            var dto = _mapper.Map<GameDetailResponse>(result);
            return dto;
        }

        public async Task<GameDetailResponse> UpdateAsync(GameRequestDto gameRequest)
        {
            var gameEntity = _mapper.Map<Game>(gameRequest);

            gameEntity.OpeningId = GetOpening(gameEntity.Moves).Result.Id;

            var result = await _gameRepository.UpdateAsync(gameEntity);
            var dto = _mapper.Map<GameDetailResponse>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _gameRepository.DeleteAsync(id);
        }

        //Needs pgn and sets longpgn and movePath
        private void SetMoves(Game game)
        {
            ChessConverter converter = new ChessConverter();
            var board = converter.GetStartingBoard();

            for (int i = 0; i < game.Moves.Count; i++)
            {
                if (i % 2 == 0)
                {
                    game.Moves.OrderBy(g => g.Turn).ToList()[i].MovePath = converter.GetBeginAndFinishPositionOfLastMove(game.Moves.OrderBy(g => g.Turn).ToList()[i].MovePGN, board, Turn.White);
                    //game.Moves.ToList()[i].LongPGN = converter.GetLongPGN(game.Moves.ToList()[i].MovePGN, board, Turn.White);
                    converter.convertPgnMoveToBoard(game.Moves.OrderBy(g => g.Turn).ToList()[i].MovePGN, board, Turn.White);
                }
                else
                {
                    game.Moves.OrderBy(g => g.Turn).ToList()[i].MovePath = converter.GetBeginAndFinishPositionOfLastMove(game.Moves.OrderBy(g => g.Turn).ToList()[i].MovePGN, board, Turn.Black);
                    //game.Moves.ToList()[i].LongPGN = converter.GetLongPGN(game.Moves.ToList()[i].MovePGN, board, Turn.Black);
                    converter.convertPgnMoveToBoard(game.Moves.OrderBy(g => g.Turn).ToList()[i].MovePGN, board, Turn.Black);

                }
            }
        }

        private async Task<Opening> GetOpening(ICollection<GameMove> moves)
        {
            Opening opening = new Opening();
            opening = _openingRepository.ListAllAsync().Result.FirstOrDefault(o => o.Name == "Uknown");
            Opening[] openingsList = _openingRepository.ListAllAsync().Result.ToArray();
            moves = moves.OrderBy(m => m.Turn).ToList();

            ChessConverter converter = new ChessConverter();
            var chessBoard = converter.GetStartingBoard();
            int turn = moves.Min(g => g.Turn);
            for (int i = 0; i < moves.Count; i++)
            {
                if (i % 2 == 0)
                {
                    converter.convertPgnMoveToBoard(moves.FirstOrDefault(g => g.Turn == turn).MovePGN, chessBoard, Turn.White);
                    string fenString = converter.GetFenString(chessBoard);
                    for (int j = 0; j < openingsList.Count(); j++)
                    {
                        if (fenString == openingsList[j].FenString)
                        {
                            opening = openingsList[j];
                        }
                    }

                }
                else
                {
                    converter.convertPgnMoveToBoard(moves.FirstOrDefault(t => t.Turn == turn).MovePGN, chessBoard, Turn.Black);
                    string fenString = converter.GetFenString(chessBoard);

                    for (int j = 0; j < openingsList.Count(); j++)
                    {
                        if (fenString == openingsList[j].FenString)
                        {
                            opening = openingsList[j];
                        }
                    }

                }
                turn++;
            }


            return await Task.FromResult(opening);
        }

        public async Task<GameDetailResponse> UpdateGameMoves(Guid id, IEnumerable<MoveRequestDto> gameMoves)
        {
            var gameEntity = await _gameRepository.GetByIdAsync(id);
            var moveEntity = _mapper.Map<IEnumerable<GameMove>>(gameMoves);

            gameEntity.OpeningId = GetOpening(gameEntity.Moves).Result.Id;
            SetMoves(gameEntity);
            var tempGame = new Game();
            tempGame.Moves = moveEntity.ToList();
            SetMoves(tempGame);
            gameEntity.Moves = tempGame.Moves;
            var result = await _gameRepository.UpdateGameMoves(id, moveEntity);
            var dto = _mapper.Map<GameDetailResponse>(result);
            return dto;
        }
    }
}
