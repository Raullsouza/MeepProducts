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
    }
}
