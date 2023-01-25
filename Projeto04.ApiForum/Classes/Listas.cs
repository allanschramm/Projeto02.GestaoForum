namespace Projeto04.ApiForum.Classes
{
    public class Listas
    {
        public  IEnumerable<Curso> ListarCursos()
        {
            return new List<Curso>
            {
                new Curso() { Id = 10, Descricao="Asp.Net", Ch=60, Preco=1000 },
                new Curso() { Id = 20, Descricao="Turismo", Ch=2000, Preco=400 },
                new Curso() { Id = 30, Descricao="Corte e Costura", Ch=200, Preco=1000 },
                new Curso() { Id = 40, Descricao="Culinaria", Ch=100, Preco=200 },
            };
        }
    }
}
