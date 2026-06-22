using AutoMapper;
using CRM.Application.Dtos.Deal;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;

namespace CRM.Infrastructure.Services
{
    public class DealService(IDealRepository dealRepository, IProductRepository productRepository, IMapper mapper) : IDealService
    {
        private readonly IDealRepository _dealRepository = dealRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateDealAsync(CreateDealDto createDealDto)
        {
            var deal = _mapper.Map<Domain.Entities.Deal>(createDealDto);
            await _dealRepository.AddAsync(deal);
        }

        public async Task DeleteDealAsync(Guid id)
        {
            await _dealRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DealDto>?> GetAllDealsAsync(int page = 1, int limit = 100, string? filter = null)
        {
            var deals = await _dealRepository.GetAllAsync(page, limit);
            if(filter is null)
            {
                return _mapper.Map<IEnumerable<DealDto>>(deals);
            }
            else
            {
                deals = await _dealRepository.GetAllAsync(page, limit, (_ => _.Name.Contains(filter) || _.Company.Name.Contains(filter) || _.Stage.Name.Contains(filter)));
            }
            return _mapper.Map<IEnumerable<DealDto>>(deals);
        }

        public async Task<DealDto?> GetDealByIdAsync(Guid id)
        {
            var deal = await _dealRepository.GetByIdAsync(id);
            return _mapper.Map<DealDto>(deal);
        }

        public async Task<IEnumerable<DealDto>?> GetDealsByStageIdAsync(Guid stageId)
        {
            var deals = await _dealRepository.GetDealsByStageIdAsync(stageId);
            return _mapper.Map<IEnumerable<DealDto>>(deals);
        }

        public async Task UpdateDealAsync(Guid id, UpdateDealDto updateDealDto)
        {
            var deal = await _dealRepository.GetByIdAsync(id);
            if(deal is not null)
            {
                await _dealRepository.UpdateAsync(_mapper.Map(updateDealDto, deal));
            }
        }
    }
}
