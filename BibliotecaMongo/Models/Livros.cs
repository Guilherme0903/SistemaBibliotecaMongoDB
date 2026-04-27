using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace BibliotecaMongo.Models;

public class Livro
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }
    public string Genero { get; set; }
    public int Exemplares { get; set; }
    public List<string> Emprestimos { get; set; } = new List<string>();
}