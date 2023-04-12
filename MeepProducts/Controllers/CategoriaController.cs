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
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Categoria>))]
        [ProducesResponseType(400)]

        public IActionResult GetCategorias()
        {
            var categorias = _mapper.Map<List<CategoriaDto>>(_categoriaRepository.GetCategorias());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categorias);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Categoria))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoria(int categoryId)
        {
            if (!_categoriaRepository.CategoriaExists(categoryId))
                return NotFound();

            var categoria = _mapper.Map<CategoriaDto>
                (_categoriaRepository.GetCategoria(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categoria);
        }


        [HttpGet("produto/{categoriaId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(400)]

        public IActionResult GetProdutosByCategoria(int categoriaId)
        {
            var produtos = _mapper.Map<List<ProdutoDto>>
                (_categoriaRepository.GetProdutosByCategoria(categoriaId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(produtos);
        }
    }
}
