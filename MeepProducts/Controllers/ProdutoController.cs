using AutoMapper;
using MeepProducts.Dto;
using MeepProducts.Interfaces;
using MeepProducts.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeepProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(400)]
        public IActionResult GetProdutos()
        {
            var produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.GetProdutos());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok (produtos);
        }


        [HttpGet("ById/{produtoId}")]
        [ProducesResponseType(200, Type = typeof(Produto))]
        [ProducesResponseType(400)]
        public IActionResult GetProdutoById(int produtoId) 
        {
            if(!_produtoRepository.ProdutoExists(produtoId))
                return NotFound();

            var Produto = _mapper.Map<ProdutoDto>(_produtoRepository.GetProdutoById(produtoId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok (Produto);
        }


        [HttpGet("ByName/{produtoName}")]
        [ProducesResponseType(200, Type = typeof(Produto))]
        [ProducesResponseType(400)]
        public IActionResult GetProdutoByName(string produtoName)
        {
            if (!_produtoRepository.ProdutoExistsByName(produtoName))
                return NotFound();

            var Produto = _mapper.Map<ProdutoDto>(_produtoRepository.GetProdutoByName(produtoName));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Produto);
        }


        [HttpGet("GetProdutosByCategoria/{categoriaId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(400)]

        public IActionResult GetProdutosByCategoria(int categoriaId)
        {
            if(!_produtoRepository.CategoriaExists(categoriaId))
                return NotFound();

            var Produtos = _mapper.Map<List<ProdutoDto>>(_produtoRepository.GetProdutosByCategoria(categoriaId));
            if (!ModelState.IsValid) return
                    BadRequest();

            return Ok(Produtos);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateProduto([FromBody] ProdutoDto produtoCreate)
        {
            if(produtoCreate == null)
                return BadRequest(ModelState);

            var produto = _produtoRepository.GetProdutos()
                .Where(p => p.Nome.Trim().ToUpper() == produtoCreate.Nome.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (produto != null)
            {
                ModelState.AddModelError("", "Produto já existe");
                return StatusCode(422, ModelState);
            }
            if(!ModelState.IsValid) return BadRequest();

                var produtoMap = _mapper.Map<Produto>(produtoCreate);

            if(!_produtoRepository.CreateProduto(produtoMap))
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao salvar");
                    return StatusCode(500, ModelState);
                }

                return Ok("Produto cadastrado");        
        }
        [HttpPut("{produtoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProduto (int produtoId, [FromBody] ProdutoDto updateProduto)
        {
            if (updateProduto == null)
                return BadRequest(ModelState);

            if(produtoId != updateProduto.Id)
                return BadRequest(ModelState);

            if(!_produtoRepository.ProdutoExists(produtoId))
                return NotFound();

            if(!ModelState.IsValid) return BadRequest();

            var produtoMap = _mapper.Map<Produto>(updateProduto);

            if (!_produtoRepository.UpdateProduto(produtoMap))
            {
                ModelState.AddModelError("", "Algo deu errado ao atualizar o produto.");
                    return StatusCode(500, ModelState);
            }
            return Ok("Produto Atualizado");
        }

        [HttpDelete("produtoId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteProduto(int produtoId) 
        {
            if (!_produtoRepository.ProdutoExists(produtoId))
            {
                return NotFound();
            }

            var produtoToDelete = _produtoRepository.GetProdutoById(produtoId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_produtoRepository.DeleteProduto(produtoToDelete))
            {
                ModelState.AddModelError("", "Ocorreu um erro ao excluir o produto");
            }

            return Ok("Produto excluido");
        }
    }
}
