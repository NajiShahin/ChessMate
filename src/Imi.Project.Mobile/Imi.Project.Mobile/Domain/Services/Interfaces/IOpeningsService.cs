using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Interfaces
{
    public interface IOpeningsService
    {
        Task<Opening> GetOpening(Guid id);
        Task<IQueryable<Opening>> GetAllOpenings();
        Task<Opening> UpdateOpening(Opening opening);
        Task<Opening> AddOpening(Opening opening);
        Task<Opening> DeleteOpening(Guid id);
    }
}
