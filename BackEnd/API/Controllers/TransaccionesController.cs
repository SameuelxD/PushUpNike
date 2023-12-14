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
    public class TransaccionesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransaccionesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TransaccionesDto>>> Get()
        {
            var Transacciones = await _unitOfWork.Transacciones.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<TransaccionesDto>>(Transacciones);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TransaccionesDto>> Post(TransaccionesDto TransaccionesDto)
        {
            var Transacciones = _mapper.Map<Transaccione>(TransaccionesDto);
            this._unitOfWork.Transacciones.Add(Transacciones);
            await _unitOfWork.SaveAsync();
            if (Transacciones == null)
            {
                return BadRequest();
            }
            TransaccionesDto.Id = Transacciones.Id;
            return CreatedAtAction(nameof(Post), new { id = TransaccionesDto.Id }, TransaccionesDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TransaccionesDto>> Get(int id)
        {
            var Transacciones = await _unitOfWork.Transacciones.GetByIdAsync(id);
            if (Transacciones == null)
            {
                return NotFound();
            }
            return _mapper.Map<TransaccionesDto>(Transacciones);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TransaccionesDto>> Put(int id, [FromBody] TransaccionesDto TransaccionesDto)
        {
            if (TransaccionesDto == null)
            {
                return NotFound();
            }
            var Transacciones = _mapper.Map<Transaccione>(TransaccionesDto);
            _unitOfWork.Transacciones.Update(Transacciones);
            await _unitOfWork.SaveAsync();
            return TransaccionesDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Transacciones = await _unitOfWork.Transacciones.GetByIdAsync(id);
            if (Transacciones == null)
            {
                return NotFound();
            }
            _unitOfWork.Transacciones.Remove(Transacciones);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}