using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;

namespace Imi.Project.Mobile.Domain.Services.Mocking
{
    public class MockOpeningService : IOpeningsService
    {
        private static List<Opening> openingList = new List<Opening>
        {
            new Opening{
                Id = Guid.Parse("f5a23d9f-96c9-48d2-a3d5-5ef183ea2864"), 
                Name = "Queen's Indian, Marienbad system",
                Moves = new List<OpeningMove>
                {
                                    new OpeningMove { Id = Guid.Parse("6bc34f91-4e30-4a5a-a6a5-f619ec06f540"), OpeningId = Guid.Parse("f5a23d9f-96c9-48d2-a3d5-5ef183ea2864"), MovePGN = "d4", Turn = 1 },
new OpeningMove { Id = Guid.Parse("e3b1b916-e8e4-464c-b251-122b3829e5ee"), OpeningId = Guid.Parse("f5a23d9f-96c9-48d2-a3d5-5ef183ea2864"), MovePGN = "Nf6", Turn = 2 },
new OpeningMove { Id = Guid.Parse("cdccacf4-f95b-446c-97a5-d14c360faae9"), OpeningId = Guid.Parse("f5a23d9f-96c9-48d2-a3d5-5ef183ea2864"), MovePGN = "Nf3", Turn = 3 },
new OpeningMove { Id = Guid.Parse("42e0528b-54c1-46de-a6b4-47d6eeb61c88"), OpeningId = Guid.Parse("f5a23d9f-96c9-48d2-a3d5-5ef183ea2864"), MovePGN = "b6", Turn = 4 },
new OpeningMove { Id = Guid.Parse("67a68ec2-45e3-4f48-ac13-773fa975d666"), OpeningId = Guid.Parse("f5a23d9f-96c9-48d2-a3d5-5ef183ea2864"), MovePGN = "g3", Turn = 5 },
new OpeningMove { Id = Guid.Parse("05bb5ad4-a0b8-40ea-92f7-addf05296476"), OpeningId = Guid.Parse("f5a23d9f-96c9-48d2-a3d5-5ef183ea2864"), MovePGN = "Bb7", Turn = 6 },
new OpeningMove { Id = Guid.Parse("2b9e776e-73e6-4282-888e-504df69536f8"), OpeningId = Guid.Parse("f5a23d9f-96c9-48d2-a3d5-5ef183ea2864"), MovePGN = "Bg2", Turn = 7 },
new OpeningMove { Id = Guid.Parse("a742d8d4-0e45-4d4a-b280-3681e91195ac"), OpeningId = Guid.Parse("f5a23d9f-96c9-48d2-a3d5-5ef183ea2864"), MovePGN = "c5", Turn = 8 }
                }
            },
                new Opening{
                Id = Guid.Parse("07281e75-4164-4b06-ab83-28e1f25b04a0"), 
                Name = "Amar gambit" ,
                Moves = new List<OpeningMove>
                {
                    new OpeningMove { Id = Guid.Parse("92c8848f-ef25-460a-b4af-edc5ebc5c377"), OpeningId = Guid.Parse("07281e75-4164-4b06-ab83-28e1f25b04a0"), MovePGN = "Nh3", Turn = 1 },
new OpeningMove { Id = Guid.Parse("a3c4966b-9c11-4857-96c0-88015a531a29"), OpeningId = Guid.Parse("07281e75-4164-4b06-ab83-28e1f25b04a0"), MovePGN = "d5", Turn = 2 },
new OpeningMove { Id = Guid.Parse("6f13f42f-6487-4e84-994b-3dfe743479de"), OpeningId = Guid.Parse("07281e75-4164-4b06-ab83-28e1f25b04a0"), MovePGN = "g3", Turn = 3 },
new OpeningMove { Id = Guid.Parse("6b02df0a-11c1-455f-929b-4965d294ddf2"), OpeningId = Guid.Parse("07281e75-4164-4b06-ab83-28e1f25b04a0"), MovePGN = "e5", Turn = 4 },
new OpeningMove { Id = Guid.Parse("7a2576c3-0ef5-4c3a-b922-c3f3b35338b4"), OpeningId = Guid.Parse("07281e75-4164-4b06-ab83-28e1f25b04a0"), MovePGN = "f4", Turn = 5 },
new OpeningMove { Id = Guid.Parse("8c54c579-bb07-4f89-8d7d-165d5331eb68"), OpeningId = Guid.Parse("07281e75-4164-4b06-ab83-28e1f25b04a0"), MovePGN = "Bxh3", Turn = 6 },
new OpeningMove { Id = Guid.Parse("42c7b1fa-42c7-4dae-80e9-d7ede5380faf"), OpeningId = Guid.Parse("07281e75-4164-4b06-ab83-28e1f25b04a0"), MovePGN = "Bxh3", Turn = 7 },
new OpeningMove { Id = Guid.Parse("04213a36-f198-4741-a0af-2f78aa599680"), OpeningId = Guid.Parse("07281e75-4164-4b06-ab83-28e1f25b04a0"), MovePGN = "exf4", Turn = 8 }
                }
            }
        };

        public async Task<Opening> AddOpening(Opening opening)
        {
            openingList.Add(opening);
            return await Task.FromResult(opening);
        }

        public async Task<Opening> DeleteOpening(Guid id)
        {
            var oldOpening = openingList.FirstOrDefault(e => e.Id == id);
            openingList.Remove(oldOpening);
            return await Task.FromResult(oldOpening);
        }

        public async Task<IQueryable<Opening>> GetAllOpenings()
        {
            var games = openingList.AsQueryable();
            return await Task.FromResult(games);
        }

        public async Task<Opening> GetOpening(Guid id)
        {
            var opening = openingList.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(opening);
        }

        public async Task<Opening> UpdateOpening(Opening opening)
        {
            var oldOpening = openingList.FirstOrDefault(e => e.Id == opening.Id);
            openingList.Remove(oldOpening);
            openingList.Add(opening);
            return await Task.FromResult(opening);
        }
    }
}
