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
    public class TipoPagoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoPagoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoPagoDto>>> Get()
        {
            var TipoPagos = await _unitOfWork.TipoPagos.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<TipoPagoDto>>(TipoPagos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPagoDto>> Post(TipoPagoDto TipoPagoDto)
        {
            var TipoPago = _mapper.Map<Tipopago>(TipoPagoDto);
            this._unitOfWork.TipoPagos.Add(TipoPago);
            await _unitOfWork.SaveAsync();
            if (TipoPago == null)
            {
                return BadRequest();
            }
            TipoPagoDto.Id = TipoPago.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoPagoDto.Id }, TipoPagoDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoPagoDto>> Get(int id)
        {
            var TipoPago = await _unitOfWork.TipoPagos.GetByIdAsync(id);
            if (TipoPago == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoPagoDto>(TipoPago);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPagoDto>> Put(int id, [FromBody] TipoPagoDto TipoPagoDto)
        {
            if (TipoPagoDto == null)
            {
                return NotFound();
            }
            var TipoPagos = _mapper.Map<Tipopago>(TipoPagoDto);
            _unitOfWork.TipoPagos.Update(TipoPagos);
            await _unitOfWork.SaveAsync();
            return TipoPagoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var TipoPago = await _unitOfWork.TipoPagos.GetByIdAsync(id);
            if (TipoPago == null)
            {
                return NotFound();
            }
            _unitOfWork.TipoPagos.Remove(TipoPago);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}