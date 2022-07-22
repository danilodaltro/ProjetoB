using System.Threading.Tasks;
using ProjetoB.Application.Models.Request.Produto;
using ProjetoB.Application.Models.Response.Produto;
using ProjetoB.Common.Enum;

namespace ProjetoB.Application.Contract
{
    public interface IProdutoService
    {
        Task<GetAllProdutoResponse> GetAllAsync();
        Task<GetByIdProdutoResponse> GetByIdAsync(int id);
        Task<GetByNomeProdutoResponse> GetByNomeAsync(string nome);
        Task<GetByStatusResponse> GetByStatusAsync(Status status);
        Task<CreateProdutoResponse> CreateAsync(CreateProdutoRequest request);
        Task<UpdateProdutoResponse> UpdateAsync(int id, UpdateProdutoRequest request);
        Task<DeleteProdutoResponse> DeleteAsync(int id);
    }
}