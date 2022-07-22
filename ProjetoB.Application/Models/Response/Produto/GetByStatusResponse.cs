using System.Collections.Generic;
using ProjetoB.Application.Common;
using ProjetoB.Application.Models.Dto;

namespace ProjetoB.Application.Models.Response.Produto
{
    public class GetByStatusResponse: BaseResponse
    {
        public IEnumerable<ProdutoDto> ProdutosByStatus { get; set; }
    }
}