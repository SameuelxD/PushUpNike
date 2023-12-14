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
    public class CiudadController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
        {
            var Ciudades = await _unitOfWork.Ciudades.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<CiudadDto>>(Ciudades);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CiudadDto>> Post(CiudadDto CiudadDto)
        {
            var Ciudad = _mapper.Map<Ciudad>(CiudadDto);
            this._unitOfWork.Ciudades.Add(Ciudad);
            await _unitOfWork.SaveAsync();
            if (Ciudad == null)
            {
                return BadRequest();
            }
            CiudadDto.Id = Ciudad.Id;
            return CreatedAtAction(nameof(Post), new { id = CiudadDto.Id }, CiudadDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var Ciudad = await _unitOfWork.Ciudades.GetByIdAsync(id);
            if (Ciudad == null)
            {
                return NotFound();
            }
            return _mapper.Map<CiudadDto>(Ciudad);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody] CiudadDto CiudadDto)
        {
            if (CiudadDto == null)
            {
                return NotFound();
            }
            var Ciudades = _mapper.Map<Ciudad>(CiudadDto);
            _unitOfWork.Ciudades.Update(Ciudades);
            await _unitOfWork.SaveAsync();
            return CiudadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Ciudad = await _unitOfWork.Ciudades.GetByIdAsync(id);
            if (Ciudad == null)
            {
                return NotFound();
            }
            _unitOfWork.Ciudades.Remove(Ciudad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}