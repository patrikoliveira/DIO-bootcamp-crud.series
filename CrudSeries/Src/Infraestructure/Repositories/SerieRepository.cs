using System.Collections.Generic;
using CrudSeries.Src.Domain.Entities;
using CrudSeries.Src.Domain.Repositories;

namespace CrudSeries.Src.Infraestructure.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        static List<Serie> listaSeries = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
          listaSeries[id] = entidade;
        }

        public void Excluir(int id)
        {
          listaSeries[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
          listaSeries.Add(entidade);
        }

        public List<Serie> Lista()
        {
          return listaSeries;
        }

        public Serie RetornaPorId(int id)
        {
          return listaSeries[id];
        }

        public int ProximoId()
        {
          return listaSeries.Count;
        }
  }
}