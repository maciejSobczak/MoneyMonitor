using MoneyMonitor.API.Domain.Models;
using System;

namespace MoneyMonitor.API.Resources
{
    public class AssetResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public AssetTypeResource AssetType { get; set; }

    }
}
