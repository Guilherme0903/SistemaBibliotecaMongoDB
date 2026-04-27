using BibliotecaMongo.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BibliotecaMongo.Controllers
{
    public class LivroController : Controller
    {
        private readonly IMongoCollection<Livro> _livros;

        public LivroController()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("BibliotecaDB");
            _livros = database.GetCollection<Livro>("Livros");
        }

        // LISTAR
        public ActionResult Index()
        {
            var livros = _livros.Find(l => true).ToList();
            return View(livros);
        }

        // DETALHES
        public ActionResult Details(string id)
        {
            var livro = _livros.Find(l => l.Id == id).FirstOrDefault();
            return View(livro);
        }

        // TELA DE CRIAÇÃO
        public ActionResult Create()
        {
            return View();
        }

        // CRIAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
        {
            try
            {
                livro.Emprestimos = new List<string>();
                _livros.InsertOne(livro);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(livro);
            }
        }

        // TELA DE EDIÇÃO
        public ActionResult Edit(string id)
        {
            var livro = _livros.Find(l => l.Id == id).FirstOrDefault();
            return View(livro);
        }

        // EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Livro livroAtualizado)
        {
            try
            {
                _livros.ReplaceOne(l => l.Id == id, livroAtualizado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(livroAtualizado);
            }
        }

        // TELA DE DELETE
        public ActionResult Delete(string id)
        {
            var livro = _livros.Find(l => l.Id == id).FirstOrDefault();
            return View(livro);
        }

        // DELETAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Livro livro)
        {
            try
            {
                _livros.DeleteOne(l => l.Id == id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(livro);
            }
        }
    }
}