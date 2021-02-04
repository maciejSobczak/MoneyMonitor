using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMonitor.API.Domain.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public EOperationType OperationType { get; set; }
        public double Amount { get; set; }
        public float Value { get; set; }
        public string BaseCurrency { get; set; }
        public float AdditionalCosts { get; set; }
        public string AdditionalInfo { get; set; }


        public int AssetId { get; set; }
        public Asset Asset { get; set; }
    }
}
