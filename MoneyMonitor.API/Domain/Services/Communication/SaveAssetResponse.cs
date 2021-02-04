using MoneyMonitor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMonitor.API.Domain.Services.Communication
{
    public class SaveAssetResponse : BaseResponse
    {
        public Asset Asset { get; private set; }

        public SaveAssetResponse(bool success, string message, Asset asset) : base(success, message)
        {
            Asset = asset;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveAssetResponse(Asset asset) : this(true, string.Empty, asset)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveAssetResponse(string message) : this(false, message, null)
        {
        }
    }
}
