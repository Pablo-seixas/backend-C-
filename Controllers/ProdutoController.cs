using Microsoft.AspNetCore.Mvc;
using Estoque.Models;
using Estoque.Data;

namespace Estoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly EstoqueContext? _context;

        public ProdutoController(EstoqueContext context)
        {
            _context = context;
        }

        // GET /api/produto
        [HttpGet]
        public IActionResult Get()
        {
            if (_context == null || !_context.Produtos.Any())
            {
                var produtosMock = new[]
                {
                    new Produto { Id = 1, Nome = "Produto A", Quantidade = 100, Preco = 0 },
                    new Produto { Id = 2, Nome = "Produto B", Quantidade = 50, Preco = 0 }
                };
                return Ok(produtosMock);
            }

            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        // GET /api/produto/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (_context == null)
                return Problem("Banco de dados não disponível.");

            var produto = _context.Produtos.Find(id);
            if (produto == null)
                return NotFound($"Produto com ID {id} não encontrado.");

            return Ok(produto);
        }

        // POST /api/produto
        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            if (_context == null)
                return Problem("Banco de dados não disponível.");

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        // PUT /api/produto/{id}/baixar?quantidade=3
        [HttpPut("{id}/baixar")]
        public IActionResult BaixarEstoque(int id, [FromQuery] int quantidade)
        {
            if (_context == null)
                return Problem("Banco de dados não disponível.");

            var produto = _context.Produtos.Find(id);
            if (produto == null)
                return NotFound($"Produto com ID {id} não encontrado.");

            if (quantidade <= 0)
                return BadRequest("Quantidade para baixar deve ser maior que zero.");

            if (produto.Quantidade < quantidade)
                return BadRequest("Estoque insuficiente.");

            produto.Quantidade -= quantidade;
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
