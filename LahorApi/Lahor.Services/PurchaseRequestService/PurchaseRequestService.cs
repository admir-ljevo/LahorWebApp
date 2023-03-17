using Lahor.Core.Dto.PurchaseRequest;
using Lahor.Core.SearchObjects;
using Lahor.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lahor.Services.PurchaseRequestService
{
    public class PurchaseRequestService : IPurchaseRequestService
    {
        private readonly UnitOfWork unitOfWork;

        public PurchaseRequestService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }
        public async Task<PurchaseRequestDto> AddAsync(PurchaseRequestDto purchaseRequestDto)
        {
            purchaseRequestDto = await unitOfWork.PurchaseRequestRepository.AddAsync(purchaseRequestDto);
            await unitOfWork.SaveChangesAsync();
            return purchaseRequestDto;
        }

        public async Task<List<PurchaseRequestDto>> GetAllAsync()
        {
            return await unitOfWork.PurchaseRequestRepository.GetAllAsync();
        }

        public async Task<PurchaseRequestDto> GetByIdAsync(int id)
        {
            return await unitOfWork.PurchaseRequestRepository.GetByIdAsync(id);
        }

        public async Task<List<PurchaseRequestDto>> GetByNameAsync(string name)
        {
            return await unitOfWork.PurchaseRequestRepository.GetByName(name);
        }

        public  Task<List<PurchaseRequestDto>> GetForPaginationAsync(BaseSearchObject baseSearchObject, int pageSize, int offeset)
        {
            return unitOfWork.PurchaseRequestRepository.GetForPaginationAsync(baseSearchObject, pageSize, offeset);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await unitOfWork.PurchaseRequestRepository.RemoveByIdAsync(id, isSoft);
            await unitOfWork.SaveChangesAsync();
        }

        public void Update(PurchaseRequestDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<PurchaseRequestDto> UpdateAsync(PurchaseRequestDto purchaseRequest)
        {
            unitOfWork.PurchaseRequestRepository.Update(purchaseRequest);
            await unitOfWork.SaveChangesAsync();    
            return purchaseRequest;
        }
    }
}
