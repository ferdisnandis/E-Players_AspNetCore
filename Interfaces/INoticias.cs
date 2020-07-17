using System.Collections.Generic;
using E_Players_AspNETCore.Models;

namespace E_Players_AspNETCore.Interfaces
{
    public interface INoticias
    {
        //Criar
        void Criar(Noticias n);
        //Ler
        List<Noticias> Ler();
        //Alterar
        void Alterar(Noticias n);
        //Excluir
        void Deletar (int idNoticia);
    }
}