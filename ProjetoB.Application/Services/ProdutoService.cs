using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoB.Application.Contract;
using ProjetoB.Application.Models.Dto;
using ProjetoB.Application.Models.Request.Produto;
using ProjetoB.Application.Models.Response.Produto;
using ProjetoB.Common.Enum;
using ProjetoB.Data;
using ProjetoB.Domain.Model;


namespace ProjetoB.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly SqlDbContext _db;

        public ProdutoService(SqlDbContext db)
        {
            this._db = db;
        }

        public async Task<CreateProdutoResponse> CreateAsync(CreateProdutoRequest request)
        {
            if (request == null)
                throw new ArgumentException("Requisição vazia!");

            var newProduto = Produto.Create(request.Nome, request.Status);

            _db.Produto.Add(newProduto);

            await _db.SaveChangesAsync();

            return new CreateProdutoResponse() { Id = newProduto.Id };
        }

        public async Task<UpdateProdutoResponse> UpdateAsync(int id, UpdateProdutoRequest request)
        {
            if (request == null)
                throw new ArgumentException("Requisição vazia!");

            var entity = await _db.Produto.FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.Status);
                await _db.SaveChangesAsync();
            }

            return new UpdateProdutoResponse();
        }

        public async Task<DeleteProdutoResponse> DeleteAsync(int id)
        {
            var entity = await _db.Produto.FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteProdutoResponse();
        }

        public async Task<GetAllProdutoResponse> GetAllAsync()
        {
            var entity = await _db.Produto.ToListAsync();

            return new GetAllProdutoResponse()
            {
                AllProdutos = entity != null ? entity.
                                                Select(c => (ProdutoDto)c).ToList()
                                        : new List<ProdutoDto>()
            };
        }

        public async Task<GetByIdProdutoResponse> GetByIdAsync(int id)
        {
            var response = new GetByIdProdutoResponse();

            var entity = await _db.Produto.FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null) response.ProdutoById = (ProdutoDto)entity;

            return response;
        }

        public async Task<GetByNomeProdutoResponse> GetByNomeAsync(string nome)
        {
            var response = new GetByNomeProdutoResponse();

            var entity = await _db.Produto.Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                                            .OrderBy(p => p.Nome)
                                            .ToListAsync();

            return new GetByNomeProdutoResponse()
            {
                ProdutosByNome = entity != null ? entity.
                                                    Select(c => (ProdutoDto)c).ToList()
                                                : new List<ProdutoDto>()
            };
        }

        public async Task<GetByStatusResponse> GetByStatusAsync(Status status)
        {
            var response = new GetByStatusResponse();

            var entity = await _db.Produto.Where(p => (int)p.Status == (int)status)
                                            .OrderBy(p => p.Nome)
                                            .ToListAsync();

            return new GetByStatusResponse()
            {
                ProdutosByStatus = entity != null ? entity.
                                                    Select(c => (ProdutoDto)c).ToList()
                                                : new List<ProdutoDto>()
            };
        }


    }
}

