using GeekStore.Core.DomainObjects;
using System;

namespace GeekStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Guid CategoriaId { get; private set; }
        public string Nome{ get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;

            Validar();
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao.Trim();
        }

        public void DebitarEstoque(int quantidade)
        {
            if(quantidade <=0 ) quantidade *= -1;

            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");

            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validations.ValidateIfEmpty(Nome, "O Campo Nome do produto não pode estar vazio");
            Validations.ValidateIfEmpty(Descricao, "O Campo Descricao do produto não pode estar vazio");
            Validations.ValidateIfDifferent(CategoriaId, Guid.Empty, "O Campo CategoriaId do produto não pode estar vazio");
            Validations.ValidateIfSmallerEqualsMinimum(Valor, 0, "O Campo Valor do produto precisa ser maior que 0");
            Validations.ValidateIfEmpty(Imagem, "O Campo Imagem do produto não pode estar vazio");
        }
    }
}
