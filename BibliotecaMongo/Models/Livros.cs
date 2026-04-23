namespace BibliotecaMongo.Models;

public class Livro
{
    public string Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }
    public string Genero { get; set; }
    public int Exemplares { get; set; }
    public List<string> Emprestimos { get; set; }
}