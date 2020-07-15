using System;
using System.IO;
using E_Players_AspNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_AspNETCore.Controllers
{
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.Ler();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];

            //Upload Início
            var file = form.Files[0];
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");
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
            novaEquipe.Imagem = file.FileName;
        }
        else
        {
            novaEquipe.Imagem = "padrao.png";
        }
        //Upload Final

            equipeModel.Criar(novaEquipe);
            ViewBag.Equipes = equipeModel.Ler();

            return LocalRedirect("~/Equipe");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Excluir(id);
            ViewBag.Equipes = equipeModel.Ler();
            return LocalRedirect("~/Equipe");
        }
    }
}   