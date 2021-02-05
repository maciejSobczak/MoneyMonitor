using MoneyMonitor.API.Domain.Models;
using MoneyMonitor.API.Domain.Repositories;
using MoneyMonitor.API.Domain.Services;
using MoneyMonitor.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyMonitor.API.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssetService(IAssetRepository assetRepository, IUnitOfWork unitOfWork)
        {
            _assetRepository = assetRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveAssetResponse> DeleteAsync(int Id)
        {
            var assetToDelete = await _assetRepository.FindByIdAsync(Id);

            if(assetToDelete == null)
            {
                return new SaveAssetResponse($"Asset with Id = {Id} does not exist.");
            }

            try
            {
                _assetRepository.Delete(assetToDelete);
                await _unitOfWork.CompleteAsync();

                return new SaveAssetResponse(assetToDelete);
            }
            catch(Exception ex)
            {
                return new SaveAssetResponse($"An error occured while deleting the asset: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Asset>> ListAsync()
        {
            return await _assetRepository.ListAsync();
        }

        public async Task<SaveAssetResponse> SaveAsync(Asset asset)
        {
            try
            {
                await _assetRepository.AddAsync(asset);
                await _unitOfWork.CompleteAsync();

                return new SaveAssetResponse(asset);
            }
            catch (Exception ex)
            {
                return new SaveAssetResponse($"An error occured when saving the asset: {ex.Message}");
            }
        }

        public async Task<SaveAssetResponse> UpdateAsync(int Id, Asset asset)
        {
            var existingAsset = await _assetRepository.FindByIdAsync(Id);

            if (existingAsset == null)
            {
                return new SaveAssetResponse("Resource not found.");
            }

            existingAsset.Name = asset.Name;
            existingAsset.ShortName = asset.ShortName;
            existingAsset.TypeId = asset.TypeId;


            try
            {
                _assetRepository.Update(existingAsset);
                await _unitOfWork.CompleteAsync();

                return new SaveAssetResponse(existingAsset);
            }
            catch (Exception ex)
            {
                return new SaveAssetResponse($"An error occured when updating the asset: {ex.Message}");
            }
        }
    }
}
