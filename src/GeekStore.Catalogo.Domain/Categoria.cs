using GeekStore.Core.DomainObjects;
using System.Collections.Generic;

namespace GeekStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        //EF Relation only
        public ICollection<Produto> Produtos { get; set; }

        //EF has problem with classes without open contructors
        protected Categoria() {}

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"Categoria: {Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validations.ValidateIfEmpty(Nome, "O Campo Nome do categoria não pode estar vazio");
            Validations.ValidateIfEquals(Codigo, 0, "O Campo Codigo da categoria não pode ser 0");
        }
    }
}