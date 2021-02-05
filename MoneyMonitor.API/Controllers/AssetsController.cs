using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoneyMonitor.API.Domain.Models;
using MoneyMonitor.API.Domain.Services;
using MoneyMonitor.API.Extensions;
using MoneyMonitor.API.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyMonitor.API.Domain.Controllers
{
    [Route("/api/[controller]")]
    public class AssetsController : Controller
    {
        private readonly IAssetService _assetService;
        private readonly IMapper _mapper;

        public AssetsController(IAssetService assetService, IMapper mapper)
        {
            _assetService = assetService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AssetResource>> GetAllAsync()
        {
            var assets = await _assetService.ListAsync();
            var resource = _mapper.Map<IEnumerable<AssetResource>>(assets);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AssetResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var asset = _mapper.Map<Asset>(resource);
            var result = await _assetService.SaveAsync(asset);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var assetResource = _mapper.Map<AssetResource>(result.Asset);
            return Ok(assetResource);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] AssetResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var asset = _mapper.Map<Asset>(resource);
            var result = await _assetService.UpdateAsync(id, asset);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var assetResource = _mapper.Map<AssetResource>(result.Asset);
            return Ok(assetResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _assetService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var response = _mapper.Map<AssetResource>(result.Asset);
            return Ok(response);
        }
    }
}
