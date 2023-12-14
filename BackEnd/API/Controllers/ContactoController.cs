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
    public class ContactoController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ContactoDto>>> Get()
        {
            var Contactos = await _unitOfWork.Contactos.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<ContactoDto>>(Contactos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoDto>> Post(ContactoDto ContactoDto)
        {
            var Contacto = _mapper.Map<Contacto>(ContactoDto);
            this._unitOfWork.Contactos.Add(Contacto);
            await _unitOfWork.SaveAsync();
            if (Contacto == null)
            {
                return BadRequest();
            }
            ContactoDto.Id = Contacto.Id;
            return CreatedAtAction(nameof(Post), new { id = ContactoDto.Id }, ContactoDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactoDto>> Get(int id)
        {
            var Contacto = await _unitOfWork.Contactos.GetByIdAsync(id);
            if (Contacto == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContactoDto>(Contacto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactoDto>> Put(int id, [FromBody] ContactoDto ContactoDto)
        {
            if (ContactoDto == null)
            {
                return NotFound();
            }
            var Contactos = _mapper.Map<Contacto>(ContactoDto);
            _unitOfWork.Contactos.Update(Contactos);
            await _unitOfWork.SaveAsync();
            return ContactoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Contacto = await _unitOfWork.Contactos.GetByIdAsync(id);
            if (Contacto == null)
            {
                return NotFound();
            }
            _unitOfWork.Contactos.Remove(Contacto);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}