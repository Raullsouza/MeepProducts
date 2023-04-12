using AutoMapper;
using MeepProducts.Dto;
using MeepProducts.Interfaces;
using MeepProducts.Models;
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
            var portais = _mapper.Map<List<PortalDto>>(_localRepository.GetPortalsByLocal(localId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(portais);
        }
    }
}
