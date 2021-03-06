using System;
using CrudSeries.Src.Domain.Enums;

namespace CrudSeries.Src.Domain.Entities
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;        
            Genero = genero;        
            Titulo = titulo;        
            Descricao = descricao;        
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = $"Gênero: {Genero}{Environment.NewLine}"
                           + $"Titulo: {Titulo}{Environment.NewLine}"
                           + $"Descricao: {Descricao}{Environment.NewLine}"
                           + $"Ano de Início: {Ano}{Environment.NewLine}";
            
            return retorno;
        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public int RetornaId()
        {
            return Id;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}