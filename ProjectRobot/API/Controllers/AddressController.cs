using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> Add(List<AddressModel> model)
        {
            await _service.Add(model);
            return Ok(new { Message = "Ceps cadastrados com Sucesso!"});
        }

        [HttpPut]
        [Route("UpdateData")]
        public async Task<IActionResult> UpdateData(AddressModel model)
        {
            await _service.UpdateData(model);
            return Ok(new { Message = "Ceps atualizados com Sucesso!" });
        }

        [HttpGet]
        [Route("GetCepProcess")]
        public async Task<IActionResult> GetCepProcess(string robot)
        {
            var cep = await _service.GetCepProcess(robot);
            return Ok(cep);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var ceps = await _service.List();
            return Ok(ceps);
        }
    }
}
