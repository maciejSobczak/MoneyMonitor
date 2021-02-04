using System.ComponentModel;

namespace MoneyMonitor.API.Domain.Models
{
    public enum EOperationType : byte
    {
        [Description("BUY")]
        Buy = 1,

        [Description("SELL")]
        Sell = 2
    }
}
