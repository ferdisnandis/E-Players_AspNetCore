
using System.Collections.Generic;
using System.IO;

namespace E_Players_AspNETCore
{
    public class EPlayersBase
    {
         public void CreateFolderAndFile(string _path)
         {

            string folder   = _path.Split("/")[0];
            string file     = _path.Split("/")[1];

            //Criar pasta 
            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path)){
                File.Create(_path).Close();
            }
        }
            /// <summary>
            /// Ler linhas do CSV
            /// </summary>
            /// <param name="PATH">CSV</param>
            /// <returns></returns>
            public List<string> ReadAllLinesCSV(string PATH){
            
            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
        /// <summary>
        /// Reescrever as linhas do CSV
        /// </summary>
        /// <param name="PATH">CSV</param>
        /// <param name="linhas">Linhas</param>
        public void RewriteCSV(string PATH, List<string> linhas)
        {
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
        
    }
    }