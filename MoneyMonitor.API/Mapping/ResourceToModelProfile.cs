using AutoMapper;
using MoneyMonitor.API.Domain.Models;
using MoneyMonitor.API.Resources;

namespace MoneyMonitor.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<AssetResource, Asset>();
            CreateMap<AssetTypeResource, AssetType>();
        }
    }
}
