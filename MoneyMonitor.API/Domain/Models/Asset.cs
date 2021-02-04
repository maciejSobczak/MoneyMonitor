using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneyMonitor.API.Domain.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public int TypeId { get; set; }
        public AssetType AssetType { get; set; }
        public IList<Deal> Deals { get; set; } = new List<Deal>();
    }
}
