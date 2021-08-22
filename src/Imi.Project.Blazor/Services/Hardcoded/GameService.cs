using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Hardcoded
{
    public class GameService : IGameService
    {
        static readonly UserItem user = new UserItem()
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Username = "Billy",
            FirstName = "Bill",
            LastName = "Billson",
            Email = "Bill.Billson@Gmail.com"
        };

        static readonly List<Move> moves = new List<Move>()
        {
            new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "d4",
                Turn = 1
            },
            new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "d5",
                Turn = 2
            },
            new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "c4",
                Turn = 3
            },
            new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "dxc4",
                Turn = 4
            },
            new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "e4",
                Turn = 5
            },new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "b5",
                Turn = 6
            },new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "a4",
                Turn = 7
            },new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "a6",
                Turn = 8
            },new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "axb5",
                Turn = 9
            },new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "axb5",
                Turn = 10
            },new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                MovePGN = "Rxa8",
                Turn = 11
            }
        };
        static readonly List<Move> moves2 = new List<Move>()
        {
            new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                MovePGN = "e4",
                Turn = 1
            },
            new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                MovePGN = "e6",
                Turn = 1
            },
            new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                MovePGN = "d4",
                Turn = 1
            },
            new Move()
            {
                GameId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                MovePGN = "d5",
                Turn = 1
            }
        };

        static List<GameItem> games = new List<GameItem>
        {
            new GameItem()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Game 1 bugged",
                DateAdded = DateTime.Now,
                PlayedAs = "White",
                User = user,
                IsBugged = true,
                Moves = moves
            },
            new GameItem()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Game bugged",
                DateAdded = DateTime.Now,
                PlayedAs = "Black",
                User = user,
                IsBugged = true,
                Moves = moves2
            },
            new GameItem()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Game not bugged",
                DateAdded = DateTime.Now,
                PlayedAs = "White",
                User = user,
                IsBugged = false
            }
        };

        public Task Create(GameItem item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GameItem> Get(Guid id)
        {
            return Task.FromResult(
                games.SingleOrDefault(x => x.Id == id)
            );
        }

        public Task<IEnumerable<GameItem>> GetGamesByUserId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GameListItem[]> GetList()
        {
            return Task.FromResult(
                games.Select(x => new GameListItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsBugged = x.IsBugged
                }).ToArray()
            );
        }

        public Task<GameItem> GetNew()
        {
            throw new NotImplementedException();
        }

        public Task Update(GameItem item)
        {
            var game = games.SingleOrDefault(x => x.Id == item.Id);
            if (game == null) throw new ArgumentException("Game not found!");
            game.IsBugged = !game.IsBugged;
            return Task.CompletedTask;
        }
    }
}
