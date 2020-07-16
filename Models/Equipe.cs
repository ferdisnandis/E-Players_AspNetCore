using System;
using System.Collections.Generic;
using System.IO;
using E_Players_AspNETCore.Interfaces;

namespace E_Players_AspNETCore.Models
{
    public class Equipe : EPlayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/Equipe.csv";

        /// <summary>
        /// Criar PATH
        /// </summary>
        public Equipe(){
            CreateFolderAndFile(PATH);
        }
        
        /// <summary>
        /// Criar a pasta
        /// </summary>
        /// <param name="e">Equipe</param>
        public void Criar(Equipe e)
        {
            string[] linha = { PrepararLinhas(e) };
            File.AppendAllLines(PATH, linha);;
        }

        /// <summary>
        /// Preparar linhas para CSV
        /// </summary>
        /// <param name="e">Equipe</param>
        /// <returns></returns>
        private string PrepararLinhas(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem};";
        }

        /// <summary>
        /// Ler todas as linhas dos CSV
        /// </summary>
        /// <returns>Lista de equipes</returns>
        public List<Equipe> Ler()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha [2];

                equipes.Add(equipe);
            }
            return equipes;
        }
        /// <summary>
        /// Alterar linha do CSV
        /// </summary>
        /// <param name="e">Equipe</param>
        public void Alterar(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add( PrepararLinhas(e) );
            RewriteCSV(PATH, linhas);
        }
        /// <summary>
        /// Excluir a linha pelo Id
        /// </summary>
        /// <param name="idEquipe">Código da Equipe</param>
        public void Excluir(int idEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}