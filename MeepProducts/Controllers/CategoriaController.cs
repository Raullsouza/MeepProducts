using AutoMapper;
using MeepProducts.Dto;
using MeepProducts.Interfaces;
using MeepProducts.Models;
using MeepProducts.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeepProducts.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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

        [HttpGet("ById/{categoryId}")]
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

        [HttpGet("ByName/{nomeCategoria}")]
        [ProducesResponseType(200, Type = typeof(Categoria))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoria(string nomeCategoria)
        {
            if (!_categoriaRepository.ExistsByName(nomeCategoria))
                return NotFound();

            var categoria = _mapper.Map<CategoriaDto>
                (_categoriaRepository.GetCategoria(nomeCategoria));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categoria);
        }


        [HttpGet("produtoByCategoria/{categoriaId}")]
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategoria([FromBody] CategoriaDto categoriaCreate)
        {
            if (categoriaCreate == null)
                return BadRequest(ModelState);

            var categoria = _categoriaRepository.GetCategorias()
                .Where(c => c.Nome.Trim().ToUpper() == categoriaCreate.Nome.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (categoria != null) 
            {
                ModelState.AddModelError("", "Categoria já existe!");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var categoriaMap = _mapper.Map<Categoria>(categoriaCreate);
            
            if(!_categoriaRepository.CreateCategoria(categoriaMap))
            {
                ModelState.AddModelError("", "Algo deu errado ao salvar");
                return StatusCode(500, ModelState);
            }

            return Ok("Categoria criada!");
        }


        [HttpPut("{categoriaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategoria(int categoriaId, [FromBody] CategoriaDto updateCategoria)
        {
            if(updateCategoria == null) 
                return BadRequest(ModelState);

            if(categoriaId != updateCategoria.Id)
                return BadRequest(ModelState);

            if (!_categoriaRepository.CategoriaExists(categoriaId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var categoriaMap = _mapper.Map<Categoria>(updateCategoria);

            if(!_categoriaRepository.UpdateCategoria(categoriaMap))
            {
                ModelState.AddModelError("", "Ocorreu um erro ao atualizar a categoria");
                return StatusCode(500, ModelState);
            }

            return Ok("Categoria Atualizada");
        }

        [HttpDelete("categoriaId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteCategoria(int categoriaId)
        {
            if (!_categoriaRepository.CategoriaExists(categoriaId))
            {
                return NotFound();
            }

            var categoriaToDelete = _categoriaRepository.GetCategoria(categoriaId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_categoriaRepository.DeleteCategoria(categoriaToDelete))
            {
                ModelState.AddModelError("", "Ocorreu um erro ao excluir o produto");
            }

            return Ok("Categoria excluida");
        }

    }
}
