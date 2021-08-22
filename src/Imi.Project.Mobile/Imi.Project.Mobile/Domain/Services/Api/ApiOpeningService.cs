using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Api
{
    public class ApiOpeningService : IOpeningsService
    {
        private readonly string _baseUrl;

        public ApiOpeningService()
        {
            _baseUrl = Constants.BaseUrl;
        }

        public Task<Opening> AddOpening(Opening opening)
        {
            throw new NotImplementedException();
        }

        public Task<Opening> DeleteOpening(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Opening>> GetAllOpenings()
        {
            var bucketLists = await WebApiClient
                .GetApiResult<IEnumerable<Opening>>($"{_baseUrl}api/openings");
            return bucketLists.AsQueryable();
        }

        public async Task<Opening> GetOpening(Guid id)
        {
            return await WebApiClient
                .GetApiResult<Opening>($"{_baseUrl}api/openings/{id}");
        }

        public Task<Opening> UpdateOpening(Opening opening)
        {
            throw new NotImplementedException();
        }
    }
}
