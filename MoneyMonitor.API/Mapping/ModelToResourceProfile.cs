using AutoMapper;
using MoneyMonitor.API.Domain.Models;
using MoneyMonitor.API.Resources;

namespace MoneyMonitor.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Asset, AssetResource>();
            CreateMap<Asset, SaveAssetResource>();
            CreateMap<AssetType, AssetTypeResource>();
        }
    }
}
