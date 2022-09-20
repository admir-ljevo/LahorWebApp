using Lahor.Shared.Constants;
using Lahor.Core.Dto.Service;
using Lahor.Core.Dto.ServicesLevelsPrices;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Core.Dto.TypeOfService;
using Lahor.Core.SearchObjects;

namespace Lahor.Services.ServicesService
{
    public class ServicesService : IServicesService
    {
        private readonly UnitOfWork _unitOfWork;

        public ServicesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task<ServiceDto> AddAsync(ServiceDto service)
        {
            var serviceGet = await _unitOfWork.ServicesRepository.AddAsync(service);
            await _unitOfWork.SaveChangesAsync();
            var levelOfServiceExecutions=await _unitOfWork.LevelOfServiceExecutionsRepository
                .GetAllAsync();
            var servicesLevelsPrice = new ServicesLevelsPriceDto();
            servicesLevelsPrice.ServiceId = serviceGet.Id;
            foreach (var item in levelOfServiceExecutions)
            {
                servicesLevelsPrice.LevelOfServiceExecutionId=item.Id;
                if(item.Name==LevelOfServiceExecutionNames.Pranje)
                {
                    servicesLevelsPrice.Price = service.Price1;
                }
                else if (item.Name == LevelOfServiceExecutionNames.Susenje)
                {
                    servicesLevelsPrice.Price = service.Price2;
                }
                else if (item.Name == LevelOfServiceExecutionNames.Peglanje)
                {
                    servicesLevelsPrice.Price = service.Price3;
                }
                else if (item.Name == LevelOfServiceExecutionNames.PranjeSusenje)
                {
                    servicesLevelsPrice.Price = service.Price4;
                }
                else if (item.Name == LevelOfServiceExecutionNames.SusenjePeglanje)
                {
                    servicesLevelsPrice.Price = service.Price5;
                }
                else if (item.Name == LevelOfServiceExecutionNames.PranjeSusenjePeglanje)
                {
                    servicesLevelsPrice.Price = service.Price6;
                }
                await _unitOfWork.ServicesLevelsPriceRepository.AddAsync(servicesLevelsPrice);
            }
            await _unitOfWork.SaveChangesAsync();
            return serviceGet;
        }

        public Task<ServiceDto> GetByIdAsync(int id)
        {
            return _unitOfWork.ServicesRepository.GetByIdAsync(id);
        }

        public Task<List<ServiceDto>> GetAllAsync()
        {
            return _unitOfWork.ServicesRepository.GetAllAsync();
        }

        public async Task<List<TypeOfServiceDto>> GetPriceList()
        {
            var typeOfServices = await _unitOfWork.TypeOfServicesRepository.GetAllAsync();
            return typeOfServices;

        }

        public Task<List<ServiceDto>> GetByNameAsync(string name)
        {
            return _unitOfWork.ServicesRepository.GetByName(name);
        }

        public async Task RemoveByIdAsync(int id, bool isSoft = true)
        {
            await _unitOfWork.ServicesRepository.RemoveByIdAsync(id, isSoft);
            var servicesLevelsPricesList = await _unitOfWork.ServicesLevelsPriceRepository.GetAllAsync();
            foreach (var item in servicesLevelsPricesList)
            {
                if(item.ServiceId==id)
                {
                    await _unitOfWork.ServicesLevelsPriceRepository.RemoveByIdAsync(item.Id, true);
                }
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async void Update(ServiceDto service)
        {
            _unitOfWork.ServicesRepository.Update<ServiceDto>(service);
            var servicesLevelsPrice = await _unitOfWork.ServicesLevelsPriceRepository.GetServicesLevelsByServiceId(service.Id);
            foreach (var item in servicesLevelsPrice)
            {
                if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.Pranje)
                {
                    item.Price = service.Price1;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.Susenje)
                {
                    item.Price = service.Price2;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.Peglanje)
                {
                    item.Price = service.Price3;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.PranjeSusenje)
                {
                    item.Price = service.Price4;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.SusenjePeglanje)
                {
                    item.Price = service.Price5;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.PranjeSusenjePeglanje)
                {
                    item.Price = service.Price6;
                }

                _unitOfWork.ServicesLevelsPriceRepository.Update<ServicesLevelsPriceDto>(item);
            }
            _unitOfWork.SaveChanges();
        }

        public async Task<ServiceDto> UpdateAsync(ServiceDto service)
        {
            _unitOfWork.ServicesRepository.Update<ServiceDto>(service);
            var servicesLevelsPrice = await _unitOfWork.ServicesLevelsPriceRepository.GetServicesLevelsByServiceId(service.Id);
            foreach (var item in servicesLevelsPrice)
            {
                item.Service = null;
                if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.Pranje)
                {
                    item.Price = service.Price1;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.Susenje)
                {
                    item.Price = service.Price2;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.Peglanje)
                {
                    item.Price = service.Price3;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.PranjeSusenje)
                {
                    item.Price = service.Price4;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.SusenjePeglanje)
                {
                    item.Price = service.Price5;
                }
                else if (item.LevelOfServiceExecution.Name == LevelOfServiceExecutionNames.PranjeSusenjePeglanje)
                {
                    item.Price = service.Price6;
                }

                _unitOfWork.ServicesLevelsPriceRepository.Update(item);
            }
            await _unitOfWork.SaveChangesAsync();
            return service;
        }

        public Task<List<ServiceDto>> GetForPaginationAsync(BaseSearchObject baseSearchObject, int pageSize, int offeset)
        {
            return _unitOfWork.ServicesRepository.GetForPaginationAsync(baseSearchObject, pageSize, offeset);
        }
    }
}
