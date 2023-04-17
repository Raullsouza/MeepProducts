 using AutoMapper;
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
    public class PortalController : Controller
    {
        private readonly IPortalRepository _portalRepository;
        private readonly IMapper _mapper;

        public PortalController(IPortalRepository portalRepository, IMapper mapper)
        {
            _portalRepository = portalRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Portal>))]
        [ProducesResponseType(400)]

        public IActionResult GetPortals()
        {
            var portais = _mapper.Map<List<PortalDto>>(_portalRepository.GetPortals());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(portais);
        }
        [HttpGet("ById/{portalId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Portal>))]
        [ProducesResponseType(400)]

        public IActionResult GetPortal(int portalId)
        {
            if (!_portalRepository.PortalExists(portalId))
                return NotFound();
            var portal = _mapper.Map<PortalDto>(_portalRepository.GetPortalById(portalId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(portal);
        }

        [HttpGet("ByName/{portalName}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Portal>))]
        [ProducesResponseType(400)]

        public IActionResult GetPortalByName(string portalName)
        {
            if (!_portalRepository.PortalExistsByName(portalName))
                return NotFound();
            var portal = _mapper.Map<PortalDto>(_portalRepository.GetPortalByName(portalName));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(portal);
        }

        [HttpGet("CategoriaByPortalId/{portalId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Categoria>))]
        [ProducesResponseType(400)]

        public IActionResult GetCategoriasByPortalId(int portalId)
        {
            if(!_portalRepository.PortalExists(portalId))
                return NotFound();

            var portal = _mapper.Map<List<CategoriaDto>>(_portalRepository.GetCategoriasByPortalId(portalId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(portal);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreatePortal([FromBody] PortalDto portalCreate)
        {
            if(portalCreate == null)    
                return BadRequest(ModelState);

            var portal = _portalRepository.GetPortals()
                .Where(p => p.Nome.Trim().ToUpper() == portalCreate.Nome.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(portal != null)
            {
                ModelState.AddModelError("", "Portal já existe");
                    return StatusCode(422, ModelState);
            }
            if(!ModelState.IsValid) return BadRequest();

            var portalMap = _mapper.Map<Portal>(portalCreate);

            if(!_portalRepository.CreatePortal(portalMap))
            {
                ModelState.AddModelError("", "Ocorreu um erro ao salvar");
                return StatusCode(500, ModelState);
            }

            return Ok( "Portal Cadastrado");
        }

        [HttpPut("{portalId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdatePortal(int portalID, [FromBody] PortalDto updatePortal)
        {
            if(updatePortal == null)
                return BadRequest(ModelState);

            if (portalID != updatePortal.Id)
                return BadRequest(ModelState);

            if(!_portalRepository.PortalExists(portalID))
                return NotFound();

            if(!ModelState.IsValid) return BadRequest();

            var portalMap = _mapper.Map<Portal>(updatePortal);

            if(!_portalRepository.UpdatePortal(portalMap))
            {
                ModelState.AddModelError("", "Ocorreu um erro ao atualizar o portal");
                return StatusCode(500, ModelState);
            }

            return Ok("Portal Atualizado");
        }

        [HttpDelete("portalId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeletePortal(int portalId)
        {
            if (!_portalRepository.PortalExists(portalId))
            {
                return NotFound();
            }

            var portalToDelete = _portalRepository.GetPortalById(portalId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_portalRepository.DeletePortal(portalToDelete))
            {
                ModelState.AddModelError("", "Ocorreu um erro ao excluir o portal");
            }

            return Ok("Portal excluido");
        }
    }
}
