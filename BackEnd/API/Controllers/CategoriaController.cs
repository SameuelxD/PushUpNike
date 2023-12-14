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
    public class CategoriaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
        {
            var Categorias = await _unitOfWork.Categorias.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<CategoriaDto>>(Categorias);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Post(CategoriaDto CategoriaDto)
        {
            var Categoria = _mapper.Map<Categorium>(CategoriaDto);
            this._unitOfWork.Categorias.Add(Categoria);
            await _unitOfWork.SaveAsync();
            if (Categoria == null)
            {
                return BadRequest();
            }
            CategoriaDto.Id = Categoria.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoriaDto.Id }, CategoriaDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaDto>> Get(int id)
        {
            var Categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (Categoria == null)
            {
                return NotFound();
            }
            return _mapper.Map<CategoriaDto>(Categoria);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Put(int id, [FromBody] CategoriaDto CategoriaDto)
        {
            if (CategoriaDto == null)
            {
                return NotFound();
            }
            var Categorias = _mapper.Map<Categorium>(CategoriaDto);
            _unitOfWork.Categorias.Update(Categorias);
            await _unitOfWork.SaveAsync();
            return CategoriaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (Categoria == null)
            {
                return NotFound();
            }
            _unitOfWork.Categorias.Remove(Categoria);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}