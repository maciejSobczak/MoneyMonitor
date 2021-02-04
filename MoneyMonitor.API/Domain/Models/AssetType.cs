using System;
using System.Collections.Generic;

namespace MoneyMonitor.API.Domain.Models
{
    public class AssetType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Asset> Assets { get; set; } = new List<Asset>();
    }
}
