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

        public LocalController(ILocalRepository localRepository)
        {
           _localRepository = localRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Local>))]
        public IActionResult GetLocals()
        {
            var locais = _localRepository.GetLocals();

            if(!ModelState.IsValid)         
                return BadRequest(ModelState);

            return Ok(locais);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Local))]
        [ProducesResponseType(400)]
        public IActionResult GetLocal(int id)
        {
            if(!_localRepository.LocalExists(id))
                return NotFound();

            var local = _localRepository.GetLocal(id);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(local);
        }

        [HttpGet("[action]/{cidade}")]
        [ProducesResponseType(200, Type = typeof(Local))]
        [ProducesResponseType(400)]
        public IActionResult GetLocal(string cidade)
        {
            if(!_localRepository.ExistsByName(cidade))
                return NotFound();
            var local = _localRepository.GetLocal(cidade);
                return Ok(local);  
        }

    }
}
