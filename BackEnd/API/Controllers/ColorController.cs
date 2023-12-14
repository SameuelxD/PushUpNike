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
    public class ColorController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ColorDto>>> Get()
        {
            var Colores = await _unitOfWork.Colores.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<ColorDto>>(Colores);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ColorDto>> Post(ColorDto ColorDto)
        {
            var Color = _mapper.Map<Color>(ColorDto);
            this._unitOfWork.Colores.Add(Color);
            await _unitOfWork.SaveAsync();
            if (Color == null)
            {
                return BadRequest();
            }
            ColorDto.Id = Color.Id;
            return CreatedAtAction(nameof(Post), new { id = ColorDto.Id }, ColorDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ColorDto>> Get(int id)
        {
            var Color = await _unitOfWork.Colores.GetByIdAsync(id);
            if (Color == null)
            {
                return NotFound();
            }
            return _mapper.Map<ColorDto>(Color);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ColorDto>> Put(int id, [FromBody] ColorDto ColorDto)
        {
            if (ColorDto == null)
            {
                return NotFound();
            }
            var Colores = _mapper.Map<Color>(ColorDto);
            _unitOfWork.Colores.Update(Colores);
            await _unitOfWork.SaveAsync();
            return ColorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Color = await _unitOfWork.Colores.GetByIdAsync(id);
            if (Color == null)
            {
                return NotFound();
            }
            _unitOfWork.Colores.Remove(Color);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}