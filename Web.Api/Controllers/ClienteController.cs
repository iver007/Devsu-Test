using Application.Dto;
using Application.Services;
using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Api.Controllers
{
    [Route("/Clientes")]
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IValidator<ClienteDto> _validator;
        public ClienteController(ClienteService clienteService, IPublishEndpoint _publishEndpoint, IValidator<ClienteDto> validator)
        {
            this._clienteService = clienteService;
            this._publishEndpoint = _publishEndpoint;
            this._validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddClienteAsync([FromBody] ClienteDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var data = await _clienteService.AddCliente(dto);
            if(data.IsFailed)
                return BadRequest(data);
            else
            {
               // await _publishEndpoint.Publish(dto);
                return Ok(data);
            }
        }
        [HttpGet]
        [Route("{codCliente}")]
        public async Task<ActionResult<ApiResponse>> GetClienteByCodClienteAsync(
           [FromRoute] Guid codCliente)
        {
            var data = await _clienteService.GetClienteByCodCliente(codCliente);
            if (data.IsFailed)
                return BadRequest(data);
            else
                return Ok(data);
        }
        [HttpPut]
        [Route("{codCliente}")]
        public async Task<ActionResult<ApiResponse>> UpdateClienteAsync(
            [FromRoute] Guid codCliente, [FromBody] ClienteDto dto)
        {
            var result = _validator.Validate(dto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var data = await _clienteService.UpdateCliente(codCliente, dto);
            if (data.IsFailed)
                return BadRequest(data);
            else
                return Ok(data);
        }
        [HttpDelete]
        [Route("{codCliente}")]
        public async Task<ActionResult<ApiResponse>> DeleteClienteAsync(
           [FromRoute] Guid codCliente)
        {
            var data = await _clienteService.DeleteCliente(codCliente);
            if (data.IsFailed)
                return BadRequest(data);
            else
                return Ok(data);
        }
    }
}
