using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        public ProdutoController() { }

        private static List<Produto> produtos = new List<Produto>();

        /// <summary>
        /// Retorna todos os dados de produtos.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [HttpGet("Get")]
        public ActionResult <IEnumerable<Produto>> GetProduto() 
        {
            return produtos;
        }

        /// <summary>
        /// Retornar o Id do produto.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpGet("GetId")]
        public ActionResult<Produto> GetIdProduto(int id) 
        {
            var produto = produtos.FirstOrDefault(x => x.Id == id);

            if(produto == null) 
                return NotFound();

            return Ok(produto);
        }

        /// <summary>
        /// Criar um produto novo.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult CreateProduto(Produto produto) 
        {
            produto.Id = produtos.Count() + 1;
            produtos.Add(produto);

            return CreatedAtAction(nameof(GetProduto), new {id = produto.Id}, produto);
        }

        /// <summary>
        /// Editar um produto pelo Id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="produto">Produto</param>
        /// <returns></returns>
        [HttpPut("Update")]
        public IActionResult EditProduto([FromRoute]int id, Produto produto) 
        {
            var existingProduto = produtos.FirstOrDefault(produto => produto.Id == id);

            if(existingProduto == null) 
                return NotFound();


            existingProduto.Nome = produto.Nome;
            existingProduto.Preco = produto.Preco;
            existingProduto.Decricao = produto.Decricao;

            return NoContent();
        }

        /// <summary>
        /// Deletar um produto pelo Id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public IActionResult DeleteProduto(int id) 
        {
            var produto = produtos.FirstOrDefault(produto => produto.Id == id);

            if(produto == null)
                return NotFound();

            produtos.Remove(produto);

            return NoContent();
        }
    }
}