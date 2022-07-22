using ProjetoB.Common.Enum;
using ProjetoB.Domain.Model;

namespace ProjetoB.Application.Models.Dto
{
    public class ProdutoDto
    {
        public string Nome { get; set; }
        public Status Status { get; set; }

        public static implicit operator ProdutoDto(Produto produto)
        {
            return new ProdutoDto()
            {
                Nome = produto.Nome,
                Status = produto.Status
            };
        }
    }
}