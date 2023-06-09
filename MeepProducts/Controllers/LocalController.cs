﻿using AutoMapper;
using MeepProducts.Dto;
using MeepProducts.Interfaces;
using MeepProducts.Models;
using MeepProducts.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeepProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : Controller
    {
        private readonly ILocalRepository _localRepository;
        private readonly IMapper _mapper;

        public LocalController(ILocalRepository localRepository, IMapper mapper)
        {
           _localRepository = localRepository;
           _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Local>))]
        public IActionResult GetLocals()
        {
            var locais = _mapper.Map<List<LocalDto>>(_localRepository.GetLocals());

            if(!ModelState.IsValid)         
                return BadRequest(ModelState);

            return Ok(locais);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Local>))]
        [ProducesResponseType(400)]
        public IActionResult GetLocal(int id)
        {
            if(!_localRepository.LocalExists(id))
                return NotFound();

            var local = _mapper.Map<LocalDto>(_localRepository.GetLocal(id));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(local);
        }

        [HttpGet("cidade/{nome}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Local>))]
        [ProducesResponseType(400)]
        public IActionResult GetLocal(string nome)
        {
            if(!_localRepository.ExistsByName(nome))
                return NotFound();
            var local = _mapper.Map<LocalDto>(_localRepository.GetLocal(nome));

            if (!ModelState.IsValid)
                return BadRequest();
            
            return Ok(local);  

        }
        
        [HttpGet("portais/{localId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Portal>))]
        [ProducesResponseType(400)]

        public IActionResult GetPortalsByLocal(int localId) 
        { 
            var portais = _mapper.Map<List<PortalDto>>
                (_localRepository.GetPortaisByLocal(localId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(portais);
        }
        
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateLocal([FromBody] LocalDto  localCreate)
        {
            if (localCreate == null)
                return BadRequest(ModelState);

            var local = _localRepository.GetLocals()
                .Where(p => p.Cidade.Trim().ToUpper() == localCreate.Cidade.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(local != null)
            {
                ModelState.AddModelError("", "Local já existe");
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var localMap = _mapper.Map<Local>(localCreate);

            if(!_localRepository.CreateLocal(localMap))
            {
                ModelState.AddModelError("", "Ocorreu um erro ao salvar");
                    return StatusCode(500, ModelState);
            }
            return Ok("Local criado!");
        }

        [HttpPut("{localId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateLocal (int localId, [FromBody] LocalDto updateLocal )
        {
            if(updateLocal == null)
                return BadRequest(ModelState);

            if(localId != updateLocal.Id)
                return BadRequest(ModelState);

            if(!_localRepository.LocalExists(localId))
                return BadRequest(ModelState);

            if (!ModelState.IsValid) return BadRequest();

            var localMap = _mapper.Map<Local>(updateLocal);

            if (!_localRepository.UpdateLocal(localMap))
            {
                ModelState.AddModelError("", "Ocorreu um erro ao atualizar o Local");
                return StatusCode(500, ModelState );
            }
            return Ok("Local atualizado");
        }

        [HttpDelete("LocalId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteLocal(int localId)
        {
            if (!_localRepository.LocalExists(localId))
            {
                return NotFound();
            }

            var localToDelete = _localRepository.GetLocal(localId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_localRepository.DeleteLocal(localToDelete))
            {
                ModelState.AddModelError("", "Ocorreu um erro ao excluir o local");
            }

            return Ok("local excluido");
        }
    }
}
