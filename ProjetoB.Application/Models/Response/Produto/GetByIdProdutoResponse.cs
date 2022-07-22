using ProjetoB.Application.Common;
using ProjetoB.Application.Models.Dto;

namespace ProjetoB.Application.Models.Response.Produto
{
    public class GetByIdProdutoResponse: BaseResponse
    {
        public ProdutoDto ProdutoById { get; set; }
    }
}