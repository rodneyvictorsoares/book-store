namespace BOOKSTORE.DOMAIN.Models
{
    public class Book : BaseEntity
    {
        public Book(string titulo, string genero, string autor, int anoPublicacao)
        {
            //ValidaCategoria(titulo, genero, autor, anoPublicacao);
            Titulo = titulo;
            Genero = genero;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
        }

        public String Titulo { get; private set; }
        public String Genero { get; private set; }
        public String Autor { get; private set; }
        public int AnoPublicacao { get; private set; }

        public void Update(string titulo, string genero, string autor, int anoPublicacao)
        {
            //ValidaCategoria(titulo, genero, autor, anoPublicacao);
        }

        //private void ValidaCategoria(string titulo, string genero, string autor, int anoPublicacao)
        //{
        //    if (string.IsNullOrEmpty(titulo))
        //        throw new InvalidOperationException("O Título é invalido.");

        //    if (string.IsNullOrEmpty(Genero))
        //        throw new InvalidOperationException("O Genero é invalido.");

        //    if (string.IsNullOrEmpty(Autor))
        //        throw new InvalidOperationException("O Autor é invalido.");

        //    if (anoPublicacao <= 0)
        //        throw new InvalidOperationException("O Ano é invalido.");

        //}
    }
}
