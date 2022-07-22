using System.Collections.Generic;
using ProjetoB.Application.Common;
using ProjetoB.Application.Models.Dto;

namespace ProjetoB.Application.Models.Response.Produto
{
    public class GetByNomeProdutoResponse: BaseResponse
    {
        public IEnumerable<ProdutoDto> ProdutosByNome { get; set; }
    }
}