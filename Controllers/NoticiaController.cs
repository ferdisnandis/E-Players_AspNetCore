using System;
using System.IO;
using E_Players_AspNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_AspNETCore.Controllers
{
    public class NoticiaController : Controller
    {
        Noticias noticiaModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.Ler();
            return View();
        }
 
        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticia = new Noticias();
            novaNoticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo = form["Titulo"];

            //Upload Início
            var file = form.Files[0];
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");
            if(file !=null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            novaNoticia.Imagem = file.FileName;
        }

        else
        {
            novaNoticia.Imagem = "padrao.png";
        }

        //Upload Final

            noticiaModel.Criar(novaNoticia);
            ViewBag.Noticia = noticiaModel.Ler();

            return LocalRedirect("~/Noticias");
        }

         [Route("Noticias/{id}")]
         public IActionResult Excluir(int id)
         {
             noticiaModel.Deletar(id);
             ViewBag.Noticias = noticiaModel.Ler();
             return LocalRedirect("~/Noticia");
         }
    }
}