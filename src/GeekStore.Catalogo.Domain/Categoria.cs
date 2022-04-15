using GeekStore.Core.DomainObjects;

namespace GeekStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

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