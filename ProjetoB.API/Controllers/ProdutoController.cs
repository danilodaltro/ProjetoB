using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoB.Application.Contract;
using ProjetoB.Application.Models.Request.Produto;
using ProjetoB.Common.Enum;

namespace ProjetoB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService produtoService)
        {
            this._service = produtoService;
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoRequest request)
        {
            try
            {
                var action = await _service.CreateAsync(request);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> UpdateProduto([FromQuery] int id, [FromBody] UpdateProdutoRequest request)
        {
            try
            {
                var action = await _service.UpdateAsync(id, request);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpDelete]
        [Route("remover")]
        public async Task<IActionResult> RemoveProduto(int id)
        {
            try
            {
                var action = await _service.DeleteAsync(id);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAllProdutos()
        {
            try
            {
                var action = await _service.GetAllAsync();
                return Ok(action);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetProdutoById(int id)
        {
            try
            {
                var action = await _service.GetByIdAsync(id);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet]
        [Route("nome")]
        public async Task<IActionResult> GetProdutoByNome([FromQuery] string nome)
        {
            try
            {
                var action = await _service.GetByNomeAsync(nome);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> GetProdutoByStatus([FromQuery] Status status)
        {
            try
            {
                var action = await _service.GetByStatusAsync(status);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

    }
}