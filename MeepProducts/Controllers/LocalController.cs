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

        public LocalController(ILocalRepository localRepository1)
        {
           _localRepository = localRepository1;
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
    }
}
