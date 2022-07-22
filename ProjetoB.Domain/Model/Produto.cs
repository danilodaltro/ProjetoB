using System;
using System.Linq;
using ProjetoB.Common.Enum;

namespace ProjetoB.Domain.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Status Status { get; set; }

        public Produto() { }

        public Produto(string nome, Status status)
        {
            this.Nome = nome;
            this.Status = status;
        }

        public static Produto Create(string nome, Status status)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                string errorMessage = string.Format("{0} inválido", nameof(nome));
                errorMessage = char.ToUpper(errorMessage.First()) + errorMessage.Substring(1);
                throw new ArgumentException(errorMessage);
            }

            if ((int)status == 0)
                throw new ArgumentException(string.Format("{0} inválido", nameof(status)));

            return new Produto(nome, status);
        }

        public void Update(string nome, Status status)
        {
            bool isNomeNullOrWhiteSpace = string.IsNullOrWhiteSpace(nome);

            if (!isNomeNullOrWhiteSpace)
                this.Nome = nome;

            if ((int)status > 0)
                this.Status = status;
        }
    }

}
