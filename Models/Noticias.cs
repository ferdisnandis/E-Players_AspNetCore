using System;
using System.Collections.Generic;
using System.IO;
using E_Players_AspNETCore.Interfaces;

namespace E_Players_AspNETCore.Models
{
    public class Noticias : EPlayersBase , INoticias
    {
        public int IdNoticia { get; set; }
        public string Título { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/Equipe.csv";


        public void Alterar(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinhas(n) );
            RewriteCSV(PATH, linhas);
        }

        public void Criar(Noticias n)
        {
            throw new System.NotImplementedException();
        }
        private string PrepararLinhas(Noticias n){
            return $"{n.IdNoticia};{n.Título};{n.Imagem};{n.Texto};";
        }

        public void Excluir(int idNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Noticias> Ler()
        {
            List<Noticias> equipes = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Noticias equipe = new Noticias();
                equipe.IdNoticia = Int32.Parse(linha[0]);
                equipe.Título = linha[1];
                equipe.Imagem = linha [2];

                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}

