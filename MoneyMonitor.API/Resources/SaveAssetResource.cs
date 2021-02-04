using MoneyMonitor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyMonitor.API.Resources
{
    public class SaveAssetResource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required for Asset")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short Name is required for Asset")]
        [MaxLength(3)]
        public string ShortName { get; set; }

        [Required]
        public int TypeId { get; set; }
    }
}
