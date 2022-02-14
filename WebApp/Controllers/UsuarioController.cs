using DBcontex;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
      
        private readonly AgendaContex db;
        public UsuarioController(AgendaContex db)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Usuario> listaUsuarios = db.usuarios;
            return View(listaUsuarios);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            db.usuarios.Add(usuario);
            db.SaveChanges();
            TempData["mensaje"] = $"El usuario {usuario.Nombre} a sido creado creado exitosamente";


            return RedirectToAction("Index");
        }

        //edition usuario
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //consultar usuario por medio id
            Usuario usuario = db.usuarios.Find(Id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            //consultar usuario por medio id
            db.usuarios.Update(usuario);
            db.SaveChanges();
            TempData["mensaje"] = $"El usuario {usuario.Nombre} a sido editado exitosamente";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //consultar usuario por medio id
            Usuario usuario = db.usuarios.Find(Id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Delete(Usuario usuario)
        {
            //consultar usuario por medio id
            db.usuarios.Remove(usuario);
            db.SaveChanges();
            TempData["mensaje"] = $"El usuario {usuario.Nombre} a sido creado borrado exitosamente";
            return RedirectToAction("Index");

        }

    }
}
