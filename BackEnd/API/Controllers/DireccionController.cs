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
    public class DireccionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DireccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DireccionDto>>> Get()
        {
            var Direcciones = await _unitOfWork.Direcciones.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<DireccionDto>>(Direcciones);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DireccionDto>> Post(DireccionDto DireccionDto)
        {
            var Direccion = _mapper.Map<Direccion>(DireccionDto);
            this._unitOfWork.Direcciones.Add(Direccion);
            await _unitOfWork.SaveAsync();
            if (Direccion == null)
            {
                return BadRequest();
            }
            DireccionDto.Id = Direccion.Id;
            return CreatedAtAction(nameof(Post), new { id = DireccionDto.Id }, DireccionDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DireccionDto>> Get(int id)
        {
            var Direccion = await _unitOfWork.Direcciones.GetByIdAsync(id);
            if (Direccion == null)
            {
                return NotFound();
            }
            return _mapper.Map<DireccionDto>(Direccion);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DireccionDto>> Put(int id, [FromBody] DireccionDto DireccionDto)
        {
            if (DireccionDto == null)
            {
                return NotFound();
            }
            var Direcciones = _mapper.Map<Direccion>(DireccionDto);
            _unitOfWork.Direcciones.Update(Direcciones);
            await _unitOfWork.SaveAsync();
            return DireccionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Direccion = await _unitOfWork.Direcciones.GetByIdAsync(id);
            if (Direccion == null)
            {
                return NotFound();
            }
            _unitOfWork.Direcciones.Remove(Direccion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}