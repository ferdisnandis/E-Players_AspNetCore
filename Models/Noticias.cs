using System;
using System.Collections.Generic;
using System.IO;
using E_Players_AspNETCore.Interfaces;

namespace E_Players_AspNETCore.Models
{
    public class Noticias : EPlayersBase , INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/Noticia.csv";

        /// <summary>
        /// Criar PATH
        /// </summary>
        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }

        public void Criar(Noticias n)
        {
            string[] linha = { PrepararLinhas (n) };
            File.AppendAllLines(PATH, linha);;
         }

        private string PrepararLinhas( Noticias n)
        {
            return $"{n.IdNoticia};{n.Titulo};{n.Imagem};";
        }

        /// <summary>
        /// Lê todas as linhas do CSV
        /// </summary>
        /// <returns>Lista de Notícias</returns>
        public List<Noticias> Ler()
        {
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Imagem = linha [2];

                noticias.Add(noticia);
            }
            return noticias;
        }
        /// <summary>
        /// Altera a notícia
        /// </summary>
        /// <param name="n">Notícia alterada</param>
        public void Alterar(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinhas(n) );
            RewriteCSV(PATH, linhas);
        }

        public void Deletar( int IdNoticia )
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}

