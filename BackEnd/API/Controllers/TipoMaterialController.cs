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
    public class TipoMaterialController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoMaterialController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoMaterialDto>>> Get()
        {
            var TipoMateriales = await _unitOfWork.TipoMateriales.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<TipoMaterialDto>>(TipoMateriales);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoMaterialDto>> Post(TipoMaterialDto TipoMaterialDto)
        {
            var TipoMaterial = _mapper.Map<Tipomaterial>(TipoMaterialDto);
            this._unitOfWork.TipoMateriales.Add(TipoMaterial);
            await _unitOfWork.SaveAsync();
            if (TipoMaterial == null)
            {
                return BadRequest();
            }
            TipoMaterialDto.Id = TipoMaterial.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoMaterialDto.Id }, TipoMaterialDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoMaterialDto>> Get(int id)
        {
            var TipoMaterial = await _unitOfWork.TipoMateriales.GetByIdAsync(id);
            if (TipoMaterial == null)
            {
                return NotFound();
            }
            return _mapper.Map<TipoMaterialDto>(TipoMaterial);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoMaterialDto>> Put(int id, [FromBody] TipoMaterialDto TipoMaterialDto)
        {
            if (TipoMaterialDto == null)
            {
                return NotFound();
            }
            var TipoMateriales = _mapper.Map<Tipomaterial>(TipoMaterialDto);
            _unitOfWork.TipoMateriales.Update(TipoMateriales);
            await _unitOfWork.SaveAsync();
            return TipoMaterialDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var TipoMaterial = await _unitOfWork.TipoMateriales.GetByIdAsync(id);
            if (TipoMaterial == null)
            {
                return NotFound();
            }
            _unitOfWork.TipoMateriales.Remove(TipoMaterial);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}