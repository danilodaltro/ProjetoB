using ProjetoB.Common.Enum;

namespace ProjetoB.Application.Models.Request.Produto
{
    public class UpdateProdutoRequest
    {
        public string Nome { get; set; }
        public Status Status { get; set; }
    }
}