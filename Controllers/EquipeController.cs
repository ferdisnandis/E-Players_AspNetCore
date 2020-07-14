using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Players_AspNETCore.Models;
using Microsoft.AspNetCore.Http;

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
            novaEquipe.Imagem = form["Imagem"];

            equipeModel.Criar(novaEquipe);
            ViewBag.Equipes = equipeModel.Ler();

            return LocalRedirect("~/Equipe");
        }

    }
}