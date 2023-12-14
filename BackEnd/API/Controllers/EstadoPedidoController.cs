using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EstadoPedidoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoPedidoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoPedidoDto>>> Get()
        {
            var EstadoPedidos = await _unitOfWork.EstadoPedidos.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<EstadoPedidoDto>>(EstadoPedidos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoPedidoDto>> Post(EstadoPedidoDto EstadoPedidoDto)
        {
            var EstadoPedido = _mapper.Map<Estadopedido>(EstadoPedidoDto);
            this._unitOfWork.EstadoPedidos.Add(EstadoPedido);
            await _unitOfWork.SaveAsync();
            if (EstadoPedido == null)
            {
                return BadRequest();
            }
            EstadoPedidoDto.Id = EstadoPedido.Id;
            return CreatedAtAction(nameof(Post), new { id = EstadoPedidoDto.Id }, EstadoPedidoDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoPedidoDto>> Get(int id)
        {
            var EstadoPedido = await _unitOfWork.EstadoPedidos.GetByIdAsync(id);
            if (EstadoPedido == null)
            {
                return NotFound();
            }
            return _mapper.Map<EstadoPedidoDto>(EstadoPedido);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoPedidoDto>> Put(int id, [FromBody] EstadoPedidoDto EstadoPedidoDto)
        {
            if (EstadoPedidoDto == null)
            {
                return NotFound();
            }
            var EstadoPedidos = _mapper.Map<Estadopedido>(EstadoPedidoDto);
            _unitOfWork.EstadoPedidos.Update(EstadoPedidos);
            await _unitOfWork.SaveAsync();
            return EstadoPedidoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var EstadoPedido = await _unitOfWork.EstadoPedidos.GetByIdAsync(id);
            if (EstadoPedido == null)
            {
                return NotFound();
            }
            _unitOfWork.EstadoPedidos.Remove(EstadoPedido);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}