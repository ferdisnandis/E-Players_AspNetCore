using E_Players_AspNETCore;
using E_Players_AspNETCore.Models;
using System.Collections.Generic;
namespace E_Players_AspNETCore.Interfaces
{
    public interface IEquipe
    {
        //Criar
        void Criar(Equipe e);
        //Ler
        List<Equipe> Ler();
        //Alterar
        void Alterar(Equipe e);
        //Excluir
        void Excluir (int idEquipe);
    }
}