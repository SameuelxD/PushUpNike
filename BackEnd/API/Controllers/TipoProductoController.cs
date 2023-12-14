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
    public class TipoProductoController : BaseController
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
        
            public TipoProductoController(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
        
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IEnumerable<TipoProductoDto>>> Get()
            {
                var TipoProductos = await _unitOfWork.TipoProductos.GetAllAsync();
        
                //var paises = await _unitOfWork.Paises.GetAllAsync();
                return _mapper.Map<List<TipoProductoDto>>(TipoProductos);
            }
        
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TipoProductoDto>> Post(TipoProductoDto TipoProductoDto)
            {
                var TipoProducto = _mapper.Map<Tipoproducto>(TipoProductoDto);
                this._unitOfWork.TipoProductos.Add(TipoProducto);
                await _unitOfWork.SaveAsync();
                if (TipoProducto == null)
                {
                    return BadRequest();
                }
                TipoProductoDto.Id = TipoProducto.Id;
                return CreatedAtAction(nameof(Post), new { id = TipoProductoDto.Id }, TipoProductoDto);
            }
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<TipoProductoDto>> Get(int id)
            {
                var TipoProducto = await _unitOfWork.TipoProductos.GetByIdAsync(id);
                if (TipoProducto == null){
                    return NotFound();
                }
                return _mapper.Map<TipoProductoDto>(TipoProducto);
            }
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<TipoProductoDto>> Put(int id, [FromBody] TipoProductoDto TipoProductoDto)
            {
                if (TipoProductoDto == null)
                {
                    return NotFound();
                }
                var TipoProductos = _mapper.Map<Tipoproducto>(TipoProductoDto);
                _unitOfWork.TipoProductos.Update(TipoProductos);
                await _unitOfWork.SaveAsync();
                return TipoProductoDto;
            }
        
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> Delete(int id)
            {
                var TipoProducto = await _unitOfWork.TipoProductos.GetByIdAsync(id);
                if (TipoProducto == null)
                {
                    return NotFound();
                }
                _unitOfWork.TipoProductos.Remove(TipoProducto);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
        }
}